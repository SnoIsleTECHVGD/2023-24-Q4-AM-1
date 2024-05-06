using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            
        }
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(SFXSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        myMixer.SetFloat ("Music", Mathf.Log(volume)*20);
        PlayerPrefs.SetFloat ("musicVolume", volume);
    }


    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat ("SFX", Mathf.Log(volume)*20);
        PlayerPrefs.SetFloat ("SFXVolume", volume);
    }

        private void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat ("musicVolume");
            SFXSlider.value = PlayerPrefs.GetFloat ("SFXVolume");

            SetMusicVolume(musicSlider.value);
            SetSFXVolume(SFXSlider.value);
        }
}
