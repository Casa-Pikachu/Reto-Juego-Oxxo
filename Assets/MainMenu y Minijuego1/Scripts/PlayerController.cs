using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public LayerMask solidObjectLayer;

    private bool isMoving;
    private Vector2 input;
    private Vector2 buttonInput = Vector2.zero;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if (!isMoving)
        {
            // Lectura de teclado físico
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            // Si no hay teclado, usamos input táctil
            if (input == Vector2.zero && buttonInput != Vector2.zero)
            {
                input = buttonInput;
            }

            if (input != Vector2.zero)
            {
                TryMove(input);
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    private void TryMove(Vector2 direction)
    {
        if (isMoving) return;

        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);

        Vector3 targetPos = transform.position + new Vector3(direction.x, direction.y, 0);

        if (IsWalkable(targetPos))
        {
            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer) == null;
    }

    public void PressUp()    => buttonInput = Vector2.up;
    public void PressDown()  => buttonInput = Vector2.down;
    public void PressLeft()  => buttonInput = Vector2.left;
    public void PressRight() => buttonInput = Vector2.right;
    public void Release()    => buttonInput = Vector2.zero;
}
