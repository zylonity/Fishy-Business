using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

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

}
