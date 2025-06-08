using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingManager : MonoBehaviour
{
   // public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    public void ChangeSFXVolume(float level)
    {
        mainAudioMixer.SetFloat("SFX", level);
    }

    public void ChangeMusicVolume(float level)
    {
        mainAudioMixer.SetFloat("Music", level);
    }
    public void ChangeMasterVolume(float level)
    {
        mainAudioMixer.SetFloat("Master", level);
    }
}
