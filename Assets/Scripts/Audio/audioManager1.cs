using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    [Header("--------- Audio Clip --------")]
    public AudioClip bgm;
    public AudioClip lvl1bgm;
    public AudioClip lvl2bgm;
    public AudioClip lvl3bgm;
    public AudioClip lvl4bgm;
    public AudioClip lvl5bgm;

    private void StartMusic()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {

    }
}

