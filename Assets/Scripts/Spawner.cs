using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int level = 0;
    float posY;
    GameObject[] allFish;
    GameObject currentFish;
    public bool firstSpawner = false;


    float timerMax = 3;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //prevents all the fish from running parallel
        if(firstSpawner){
            timer = 3;
        }
        else{
            timer = Random.Range(0.0f, 3.0f);
        }
        allFish = Resources.LoadAll<GameObject>("Prefabs/Fish");
        posY = gameObject.transform.position.y;

    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (currentFish == null){
            if (timer > timerMax){
                if (level == 1){
                    float fishToSpawn = Random.Range(0.0f, 1.65f);
                    if (fishToSpawn <= 0.05f){ //5%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Koi")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.35f){ //30%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Goldfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.85f){ //50%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Stickleback")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.65f){ //80%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Clownfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                }
                else if(level == 2){

                    float fishToSpawn = Random.Range(0.0f, 1.0f);
                    if (fishToSpawn <= 0.1f){ //10%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Roach")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.25f){ //15%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Koi")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.55f){ //30%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Bream")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.0f){ //45%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Starfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                }
                else if(level == 3){

                    float fishToSpawn = Random.Range(0.0f, 1.0f);
                    if (fishToSpawn <= 0.05f){ //5%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Bass")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.25f){ //20%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Koi")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.55f){ //30%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Bream")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.0f){ //45%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Squid")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                }
                else if(level == 4){

                    float fishToSpawn = Random.Range(0.0f, 1.1f);
                    if (fishToSpawn <= 0.01f){ //1%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Blobfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.05f){ //4%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Anglerfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.20f){ //15%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Pufferfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.55f){ //35%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Salmon")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.10f){ //55%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("Tuna")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                }
                else if(level == 5){
                    float fishToSpawn = Random.Range(0.0f, 1.1f);
                    if (fishToSpawn <= 0.05f){ //5%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("SpaceBlobfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.30f){ //25%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("SpaceAnglerfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 0.65f){ //35%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("SpaceRoach")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.0f){ //35%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("SpaceSalmon")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                    else if (fishToSpawn <= 1.5f){ //50%
                        foreach (GameObject fish in allFish){
                            if (fish.name.Contains("SpaceClownfish")){
                                currentFish = Instantiate(fish, new Vector3(0, posY, 0), Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }
        else{
            timer = 0;
        }
        
    }
}
