using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//This is my sexy test script for the UI element stuff


public class UITestButtons : MonoBehaviour
{
    public GameObject FloatingNumberPrefab;
    public UIController UIController;

    private void Awake()
    {
        UIController = FindObjectOfType<UIController>();
    }

    public void CatchFishButton()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.CatchFish);
    }
}
