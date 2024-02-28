using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapButtons : MonoBehaviour
{
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
    }

    public void GoToLevel(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }

 
}
