using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] Timer timer1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        timer1.SetDuration (45).Begin();
        
    }
}
