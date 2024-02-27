using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel;
    
    public int timeInDay;
    public FishSpawner _FishSpawner;
    public UIController _UIController;
    public GameObject _FishingMechanicParent;

    private void Start()
    {
        _FishSpawner = FindObjectOfType<FishSpawner>();
        GameManager.Instance._LevelManager = this;
        GameManager.Instance._UIController = _UIController;
        GameManager.Instance._FishingMechanicParent = _FishingMechanicParent;
        
        SoundManager.Instance.PlayBGM(SoundManager.Instance.LevelBGM[currentLevel - 1]);
        
        GameManager.Instance.timeInDay = timeInDay * (GameManager.Instance.currentDay + 0.25f);
        GameManager.Instance.timeSinceStart = 0;
        GameManager.Instance.SetQuota(GameManager.Instance.currentDay);
    }
}
