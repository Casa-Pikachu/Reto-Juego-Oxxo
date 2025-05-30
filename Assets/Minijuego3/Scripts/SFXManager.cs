using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip coins;
    public void GetCoin()
    {
        AudioSource.PlayClipAtPoint(coins, Camera.main.transform.position, 0.5f);
    }
    
}