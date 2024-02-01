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
        int catchPrice = Random.Range(10, 1001);
        UIController.AddCash(catchPrice);
        GameObject temp = Instantiate(FloatingNumberPrefab, this.transform);
        temp.GetComponent<FloatingNumber>().SalePrice = catchPrice;
    }
}
