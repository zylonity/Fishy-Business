using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Quota")]
    public int currentCash;
    public int quotaCash = 100;
    public Image barFill;
    public TextMeshProUGUI cashText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateQuota();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
