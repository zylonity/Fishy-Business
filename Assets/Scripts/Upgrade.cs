using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI name;

    public void SetUI(string UpgradeName, string UpgradeDisplayText)
    {
        icon.sprite = Resources.Load<Sprite>("Upgrades/Rod/T_" + UpgradeName);
        name.text = UpgradeDisplayText;
    }
}
