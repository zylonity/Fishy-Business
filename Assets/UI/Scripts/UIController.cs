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
    }

    public void fishCaught(string fishID)
    {
        if(fishID == "ClownFish"){
            AddCash(10);
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
