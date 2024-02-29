using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  
    public int level;

    [Header("Quota")]
    public int currentCash;


    int quotaL2, quotaL3, quotaL4, quotaL5;
    public int quotaCash = 100;
    public Image barFill;
    public TextMeshProUGUI cashText;
    public GameObject FloatingNumberPrefab;

    [Header("Timer")] 
    public float timeSinceStart;
    public float timeInDay; //in seconds (Should probably be stored somewhere else)
    public GameObject timerHand;
    public Image timerFill;

    [Header("Game Over")]
    public bool timerRunning = true;
    public bool gameOver = false;
    public GameObject shark;
    public GameObject gameOverScreen, lbutton;
    public GameObject winscreen, wbutton;

    float gameOverTimer = 0;
    bool setQuota = false;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("GameRunning", 1);
        if(level > 1){
            quotaCash = (int)PlayerPrefs.GetFloat("LevelQuota" + level.ToString());
        }
        PlayerPrefs.Save();
        UpdateQuota();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
            UpdateTimer();

        if(gameOver){
            PlayerPrefs.SetInt("GameRunning", 0);
            PlayerPrefs.Save();
            if (currentCash >= quotaCash){ //win
                if (setQuota == false){
                    float nextQuota = currentCash + (1 + level^2 / 10) * UnityEngine.Random.Range(0.0f, 125f);
                    print(nextQuota);
                    PlayerPrefs.SetFloat("LevelQuota" + level.ToString(), currentCash);
                    PlayerPrefs.SetFloat("LevelQuota" + (level+1).ToString(), nextQuota);
                    PlayerPrefs.SetInt("Level", level+1);
                    PlayerPrefs.Save();
                    setQuota = true;
                }

                
                winscreen.SetActive(true);
                wbutton.SetActive(true);
            }
            else{
                if (setQuota == false){
                    PlayerPrefs.DeleteKey("LevelQuota1");
                    PlayerPrefs.DeleteKey("LevelQuota2");
                    PlayerPrefs.DeleteKey("LevelQuota3");
                    PlayerPrefs.DeleteKey("LevelQuota4");
                    PlayerPrefs.DeleteKey("LevelQuota5");
                    PlayerPrefs.SetInt("Level", 1);
                    PlayerPrefs.Save();
                    setQuota = true;
                }


                shark.SetActive(true); //lose
                gameOverTimer += Time.deltaTime;
                if(gameOverTimer > 1.2f){
                    gameOverScreen.SetActive(true);
                    shark.SetActive(false);
                    lbutton.SetActive(true);
                }
            }
        };
    }

    public void SetQuotas(){

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
        if (timeSinceStart >= timeInDay){//Stops updating timer once day is done
            gameOver = true;
            return;

        }; 
        timeSinceStart += Time.deltaTime;
        timerFill.fillAmount = timeSinceStart / timeInDay;
        timerHand.transform.rotation = Quaternion.Euler(0,0,-(timeSinceStart % timeInDay) / timeInDay * 360);
    }

}
