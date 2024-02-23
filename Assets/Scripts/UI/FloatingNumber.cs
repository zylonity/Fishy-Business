using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingNumber : MonoBehaviour
{
    public float SalePrice; //When fish is caught, spawn an instance of this prefab and set this
    
    private void Start()
    {
        //Sets text to sale price variable
        GetComponentInChildren<TextMeshProUGUI>().text = "$" + SalePrice.ToString();
        
        StartCoroutine(AnimFinish());
    }

    IEnumerator AnimFinish()
    {
        yield return new WaitForSeconds(1);
        
        Destroy(this.gameObject);
    }
}
