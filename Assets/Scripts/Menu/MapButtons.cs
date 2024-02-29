using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapButtons : MonoBehaviour
{
    AudioManager audioManager;

    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("Level");
        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].interactable = false;
        }
        for(int i= 0; i < unlockedLevel; i++) 
        {
            buttons[i].interactable = true;
        }

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void GoToLevel(int sceneID)  //allows you to choose what level/scene each button goes to
    {

        SceneManager.LoadScene(sceneID);
        audioManager.PlaySFX(audioManager.Clicking);
    }

 
}
