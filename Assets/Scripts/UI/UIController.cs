using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Quota")]
    public int currentCash;
    public int quotaCash = 100;
    public Image barFill;
    public TextMeshProUGUI cashText;
    public GameObject FloatingNumberPrefab;

    [Header("Timer")] 
    public float timeSinceStart;
    public float timeInDay; //in seconds (Should probably be stored somewhere else)
    public GameObject timerHand;
    public Image timerFill;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateQuota();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void UpdateQuota()
    {
        barFill.fillAmount = (float)currentCash / quotaCash;
        cashText.text = currentCash.ToString() + "/" + quotaCash.ToString();
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
        UpdateQuota();
        
        //Spawns Floating UI
        GameObject temp = Instantiate(FloatingNumberPrefab, cashText.transform.parent.parent);
        temp.GetComponent<FloatingNumber>().SalePrice = amount;
    }

    public void fishCaught(string fishID)
    {
        if(fishID == "Undefined"){
            AddCash(10);
        }
        if(fishID == "Clownfish"){
            AddCash(UnityEngine.Random.Range(10,30));
        }
        if(fishID == "Stickleback"){
            AddCash(UnityEngine.Random.Range(5,15));
        }
        if(fishID == "Squid"){
            AddCash(UnityEngine.Random.Range(100,200));
        }
        if(fishID == "Pufferfish"){
            AddCash(UnityEngine.Random.Range(500,825));
        }
        if(fishID == "Starfish"){
            AddCash(UnityEngine.Random.Range(50,90));
        }
        if(fishID == "Blobfish"){
            AddCash(UnityEngine.Random.Range(1000,5000));
        }
        if(fishID == "Goldfish"){
            AddCash(UnityEngine.Random.Range(10,30));
        }
        if(fishID == "Koi"){
            AddCash(UnityEngine.Random.Range(25,60));
        }
        if(fishID == "Bream"){
            AddCash(UnityEngine.Random.Range(65,100));
        }
        if(fishID == "Roach"){
            AddCash(UnityEngine.Random.Range(80,110));
        }
        if(fishID == "Bass"){
            AddCash(UnityEngine.Random.Range(225,400));
        }
        if(fishID == "Tuna"){
            AddCash(UnityEngine.Random.Range(250,500));
        }
        if(fishID == "Salmon"){
            AddCash(UnityEngine.Random.Range(300,600));
        }
        if(fishID == "Anglerfish"){
            AddCash(UnityEngine.Random.Range(300,600));
        }


    }

    public void UpdateTimer()
    {
        if (timeSinceStart >= timeInDay) return; //Stops updating timer once day is done
        timeSinceStart += Time.deltaTime;
        timerFill.fillAmount = timeSinceStart / timeInDay;
        timerHand.transform.rotation = Quaternion.Euler(0,0,-(timeSinceStart % timeInDay) / timeInDay * 360);
    }
}
