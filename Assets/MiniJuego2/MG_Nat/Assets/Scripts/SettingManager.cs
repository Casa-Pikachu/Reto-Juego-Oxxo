using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class SettingManager : MonoBehaviour
{
   
    public AudioMixer mainAudioMixer;
    public Slider masterS;
    public Slider musicS;
    public Slider sfxS;

    void Start()
    {
        float master = PlayerPrefs.GetFloat("Master", 1.0f);
        float music = PlayerPrefs.GetFloat("Music", 1.0f);
        float sfx = PlayerPrefs.GetFloat("SFX", 1.0f);

        masterS.value = master;
        musicS.value = music;
        sfxS.value = sfx; 

        ChangeMasterVolume(master);
        ChangeMusicVolume(music);
        ChangeSFXVolume(sfx);
    }

    public void ChangeSFXVolume(float level)
    {
        mainAudioMixer.SetFloat("SFX", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("SFX", level);
    }

    public void ChangeMusicVolume(float level)
    {
        mainAudioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("Music", level);
    }
    public void ChangeMasterVolume(float level)
    {
        mainAudioMixer.SetFloat("Master", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("Master", level);
    }
}
