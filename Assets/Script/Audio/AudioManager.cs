using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SFX;

    [Header("Audio Clip")]
    public AudioClip MusicClip;
    public AudioClip ShotClip;
    public AudioClip ClickClip;
    public AudioClip ReLoadClip;
    public AudioClip RunningClip;
    public AudioClip ItemClip;
    public AudioClip CountdownClip;
    public AudioClip MonsterGrowlClip;
    public AudioClip PlayerDieClip;
    public AudioClip OutBulletClip;
    public AudioClip GameCompleClip;


    private void Start()
    {
        PlayLoopAudio(MusicClip);
    }

    public void PlayLoopAudio(AudioClip clip)
    {
        Music.clip = clip;
        Music.Play();
    } 
    
    public void StopAudio(AudioSource source)
    {
        if(source == null)
            return;
        source.Stop();
    } 
    
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }    
}
