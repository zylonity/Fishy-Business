using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapButtons : MonoBehaviour
{
    public void GoToLevel(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }

}
