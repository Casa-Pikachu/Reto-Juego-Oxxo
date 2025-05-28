using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] Timer timer1;
    
    [SerializeField] private int duration;
    private void Start()
    {
        timer1.SetDuration(duration).Begin();
    }
}
