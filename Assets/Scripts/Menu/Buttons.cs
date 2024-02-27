using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private void Start() //makes the music plat at the start of the game
    {
       if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void ExitGame() // exit button to close game
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void StartGame(int sceneID) // sets menu as the first scene so we can switch to the next scene (level 1) and start the game
    {
        SceneManager.LoadScene(sceneID);
    }

    public GameObject Panel;    // allow a popup for the options menu to be accessed
    public void OptionButton() // option button is toggleable, opens/closes the popup window
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public void SetMusicVolume() //uses audiomixer to control the music ui sliders
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    private void LoadVolume() //keeps vol settings and loads them back up 
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }


}
