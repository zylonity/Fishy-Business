using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject Canvas;
    
    [Header("Quota")]
    public Image barFill;
    public TextMeshProUGUI cashText;
    public GameObject FloatingNumberPrefab;

    [Header("Timer")] 
    public GameObject timerHand;
    public Image timerFill;

    [Header("Day Completion")] 
    public GameObject SuccessPanelPrefab;
    public GameObject LossPanelPrefab;

    public void UpdateQuotaUI(int currentCash, int quotaCash)
    {
        barFill.fillAmount = (float)currentCash / quotaCash;
        cashText.text = currentCash.ToString() + "/" + quotaCash.ToString();
    }

    public void SpawnFloatingNumber(int amount)
    {
        GameObject temp = Instantiate(FloatingNumberPrefab, cashText.transform.parent.parent);
        temp.GetComponent<FloatingNumber>().SalePrice = amount;
    }

    public void UpdateTimerUI(float timeSinceStart, float timeInDay)
    {
        timerFill.fillAmount = timeSinceStart / timeInDay;
        timerHand.transform.rotation = Quaternion.Euler(0,0,-(timeSinceStart % timeInDay) / timeInDay * 360);
    }

    public void ShowSuccessPanel()
    {
        GameObject temp = Instantiate(SuccessPanelPrefab, Canvas.transform);
        temp.GetComponent<SuccessPanel>().SetText();
    }
    
    public void ShowLossPanel()
    {
        GameObject temp = Instantiate(LossPanelPrefab, Canvas.transform);
    }
}
