#if UNITY_EDITOR
using UnityEditor.Search;
#endif
using UnityEngine;

public class CashierSFX : MonoBehaviour
{
    public AudioClip scanner;
    public AudioClip completarCompra;
    public AudioClip error;
    public AudioClip correcto;
    [SerializeField] AudioSource audioSource;

    public void PlayScanner()
    {
        // Debug.Log("Scanner");
        audioSource.clip = scanner;
        audioSource.Play();
    }

    public void PlayCompletarCompra()
    {
        // Debug.Log("Completar Compra");
        audioSource.clip = completarCompra;
        audioSource.Play();
    }

    public void PlayError()
    {
        // Debug.Log("Error");
        audioSource.clip = error;
        audioSource.Play();
    }
    
    public void PlayCorrecto()
    {
        // Debug.Log("Correcto");
        audioSource.clip = correcto;
        audioSource.Play();
    }
}
