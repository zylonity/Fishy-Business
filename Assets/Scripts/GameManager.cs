using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIController _UIController;
    public LevelManager _LevelManager;

    
    public GameObject _FishingMechanicParent;

    public int Upgrades;

    
    [Header("Quota")]
    public int currentDay = 1;
    public int currentQuota;
    public int currentCash;
    
    [Header("Timer")]
    public float timeSinceStart;
    public float timeInDay; //in seconds (Should probably be stored somewhere else)
    public bool dayFinished;

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

        _UIController = FindObjectOfType<UIController>();
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        dayFinished = false;
    }

    private void Update()
    {
        UpdateTimer();

        if (timeSinceStart > timeInDay && !dayFinished && !FindObjectOfType<Player>().hookedFish && !FindObjectOfType<Player>().caughtFish)
        {
            EndDay();
        }
    }

    public void SetQuota(int day)
    {
        if (day == 1)
        {
            currentQuota = 100;
        }
        else
        {
            currentQuota = Mathf.RoundToInt(currentQuota + (1 + Mathf.Pow(day, 2)  / 10) * UnityEngine.Random.Range(0.1f, 0.6f) * 250);
        }
        
        _UIController.UpdateQuotaUI(currentCash, currentQuota);
    }

    public void UpdateTimer()
    {
        if (timeSinceStart >= timeInDay) return; //Stops updating timer once day is done
        timeSinceStart += Time.deltaTime;
        
        _UIController.UpdateTimerUI(timeSinceStart, timeInDay);
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
        _UIController.UpdateQuotaUI(currentCash, currentQuota);

        _UIController.SpawnFloatingNumber(amount);
        
        SoundManager.Instance.PlaySFX(SoundManager.Instance.AddCash);
    }

    public void FishCaught(string fishID)
    {
        if (fishID == "Stickleback")
        {
            AddCash(UnityEngine.Random.Range(5, 16));
        }
        
        if (fishID == "Goldfish")
        {
            AddCash(UnityEngine.Random.Range(10, 31));
        }
        
        if (fishID == "Clownfish")
        {
            AddCash(UnityEngine.Random.Range(20, 46));
        }

        if (fishID == "Koi")
        {
            AddCash(UnityEngine.Random.Range(25, 61));
        }

        if (fishID == "Squid")
        {
            AddCash(10);
        }

        if (fishID == "Pufferfish")
        {
            AddCash(UnityEngine.Random.Range(500, 825));
        }

        if (fishID == "Starfish")
        {
            AddCash(10);
        }

        if (fishID == "Blobfish")
        {
            AddCash(UnityEngine.Random.Range(1000, 5000));
        }
        
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 10f));
        
        _LevelManager._FishSpawner.SpawnFish();
    }

    void EndDay()
    {
        dayFinished = true;

        if (currentCash >= currentQuota)
        {
            SuccessfulDay();
        }
        else
        {
            //Lose Day
        }
    }

    void SuccessfulDay()
    {
        _UIController.ShowSuccessPanel();
    }

    void UnlockUpgrade()
    {
        
    }
}
