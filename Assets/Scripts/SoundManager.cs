using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource sourcePrefab;
    public AudioSource musicSource;
    public AudioClip MainMenuBGM;
    public AudioClip[] LevelBGM;
    public AudioClip CatchFish, CatchFailed, CompleteLvl, AddCash;
    
    public float currentVolumeSFX, currentVolumeMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        currentVolumeMusic = PlayerPrefs.GetFloat("music", 0.5f);
        currentVolumeSFX = PlayerPrefs.GetFloat("sfx", 0.5f);

        musicSource.volume = currentVolumeMusic;
        
        //RestartMusic();
    }

    public void PlaySFX(AudioClip clip)
    {
        AudioSource source = Instantiate(sourcePrefab, transform);

        source.volume = currentVolumeSFX/1.5f;
        source.clip = clip;
        source.pitch = Random.Range(0.75f, 1.25f);
        
        source.Play();
        
        Destroy(source.gameObject, clip.length);
    }

    public void PlayBGM(AudioClip bgm)
    {
        StartCoroutine(Fade(0, 1));
        
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.clip = bgm;
        musicSource.Play();
        
        StartCoroutine(Fade(currentVolumeMusic, 1));
    }
    
    public void RestartMusic()
    {
        PlayBGM(MainMenuBGM);
    }

    IEnumerator Fade(float targetVolume, float duration)
    {
        float currentTime = 0;
        float start = musicSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        
        yield break;
    }
}
