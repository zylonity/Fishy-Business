using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void StartGame(int sceneID) // sets menu as the first scene so we can switch to the next scene (level 1) and start the game
    {
        audioManager.PlaySFX(audioManager.Clicking);
        SceneManager.LoadScene(sceneID);
    }

    public GameObject Panel;    // allow a popup for the options menu to be accessed
    public void OptionButton() // option button is toggleable, opens/closes the popup window
    {
        audioManager.PlaySFX(audioManager.Clicking);
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            audioManager.PlaySFX(audioManager.Clicking);
            Panel.SetActive(!isActive);

        }
    }

}
