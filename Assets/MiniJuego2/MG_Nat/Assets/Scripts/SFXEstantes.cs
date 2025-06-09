using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SFXEstantes : MonoBehaviour
{

    public AudioClip estante;
    public AudioClip drop;
    public AudioClip borrar;
    [SerializeField] AudioSource sfxSource;
     public AudioMixer mainAudioMixer;

    public void bien()
    {
        sfxSource.clip = estante;
        sfxSource.Play();
    }

    public void tirar()
    {
        sfxSource.clip = drop;
        sfxSource.Play();
    }


    public void mal()
    {
        sfxSource.clip = borrar;
        sfxSource.Play();
    }

    
}
