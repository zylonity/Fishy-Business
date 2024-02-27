using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessPanel : MonoBehaviour
{
    public TextMeshProUGUI MoneyMadeText, QuotaAmountText, ExtraMoneyText;
    public GameObject UpgradesContainer;
    public GameObject UpgradePrefab;

    public void SetText()
    {
        MoneyMadeText.text = "Money Made: " + GameManager.Instance.currentCash.ToString();
        QuotaAmountText.text = "Quota Amount: " + GameManager.Instance.currentQuota.ToString();
        ExtraMoneyText.text = "Extra Money: " + (GameManager.Instance.currentCash - GameManager.Instance.currentQuota).ToString();
        
        CheckForUpgrade();
    }

    public void CheckForUpgrade()
    {
        GameManager.Instance.currentCash = (GameManager.Instance.currentCash - GameManager.Instance.currentQuota);

        if (GameManager.Instance.currentCash >= 100 && GameManager.Instance.Upgrades == 0)
        {
            GameManager.Instance.Upgrades++;
            GameObject temp = Instantiate(UpgradePrefab, UpgradesContainer.transform);
            temp.GetComponent<Upgrade>().SetUI("SteelRod", "Steel Rod");
            //Set upgrade in gamemanager
        }
    }

    public void MapButton()
    {
        Debug.Log("Map Loaded");
    }

    public void NextButton()
    {
        GameManager.Instance.currentDay++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
