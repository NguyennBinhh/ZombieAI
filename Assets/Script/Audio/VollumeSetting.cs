using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VollumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
            LoadVollune();
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volMusic = MusicSlider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volMusic) * 20);
        PlayerPrefs.SetFloat("Music", volMusic);
    }

    public void SetSFXVolume()
    {
        float volSFX = SFXSlider.value;
         _audioMixer.SetFloat("SFX", Mathf.Log10(volSFX) * 20);;
        PlayerPrefs.SetFloat("SFX", volSFX);
    }

    public void LoadVollune()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        SetMusicVolume();
        SetSFXVolume();
    }    
}
