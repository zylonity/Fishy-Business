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
    public AudioClip CatchFail;
    public AudioClip CatchingAFish;
    public AudioClip WinningALevel;
    public AudioClip Clicking;

    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}

