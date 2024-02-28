using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject fishingLine, hook;
    GameObject camera;
    private LineRenderer lineRenderer;
    [SerializeField]
    float fishingLineSpeed = 1f;
    [SerializeField]
    float cameraCatchUpSpeed = 1.2f;
    [SerializeField]
    float levelHeight = -12f;

    public bool level5 = false;
    public bool caughtFish = false;
    public bool hookedFish = false;

    public UIController uiController;


    Vector3 startPos, linePos;
    void Start()
    {

        lineRenderer = fishingLine.GetComponent<LineRenderer>();
        camera = Camera.main.gameObject;
    }


    void Update()
    {   
        if (level5 == false){
            if(PlayerPrefs.GetInt("GameRunning") == 1){
                if (!hookedFish){
                    //Move player on Mouse X axis, convert mouse to world point
                    if(Input.mousePosition.x > 150 && Input.mousePosition.x < Screen.width){
                        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, gameObject.transform.position.y, gameObject.transform.position.z);
                    }

                    //Move Fishing line
                    startPos = lineRenderer.GetPosition(0);
                    linePos = lineRenderer.GetPosition(1);

                    hook.transform.position = new Vector3(fishingLine.transform.position.x, linePos.y + fishingLine.transform.position.y, hook.transform.position.z);

                    //Only let player move fishing line if they haven't caught a fish
                    if(!caughtFish && Input.GetMouseButton(0) ){
                        lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y - (fishingLineSpeed * Time.deltaTime), linePos.z));

                        //Move Camera
                        if(linePos.y < -4 && linePos.y > levelHeight){
                            if(camera.transform.position.y > linePos.y){
                                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - (fishingLineSpeed * cameraCatchUpSpeed * Time.deltaTime), camera.transform.position.z);
                            }

                            if(camera.transform.position.y <= linePos.y - gameObject.transform.position.y){
                                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                            }

                            
                        }
                        
                    }
                    else{
                        //Reset fishing line and camera
                        if(linePos.y < 0){
                            lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
                        }
                        if(camera.transform.position.y < 0 && linePos.y > levelHeight){
                            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                        }
                    }
                }
            }
            else{
                //Reset fishing line and camera
                        if(linePos.y < 0){
                            lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
                        }
                        if(camera.transform.position.y < 0 && linePos.y > levelHeight){
                            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                        }
            }
        }
        else{ //L5
            if(PlayerPrefs.GetInt("GameRunning") == 1){
                if (!hookedFish){
                    //Move player on Mouse X axis, convert mouse to world point
                    if(Input.mousePosition.x > 150 && Input.mousePosition.x < Screen.width){
                        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, gameObject.transform.position.y, gameObject.transform.position.z);
                    }

                    //Move Fishing line
                    startPos = lineRenderer.GetPosition(0);
                    linePos = lineRenderer.GetPosition(1);

                    hook.transform.position = new Vector3(fishingLine.transform.position.x, linePos.y + fishingLine.transform.position.y, hook.transform.position.z);

                    //Only let player move fishing line if they haven't caught a fish
                    if(!caughtFish && Input.GetMouseButton(0) ){
                        lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));

                        //Move Camera
                        if(linePos.y > 4 && linePos.y < levelHeight){
                            if(camera.transform.position.y < linePos.y){
                                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * cameraCatchUpSpeed * Time.deltaTime), camera.transform.position.z);
                            }

                            if(camera.transform.position.y >= linePos.y + gameObject.transform.position.y){
                                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                            }

                            
                        }
                        
                    }
                    else{
                        //Reset fishing line and camera
                        if(linePos.y > 0){
                            lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y - (fishingLineSpeed * Time.deltaTime), linePos.z));
                        }
                        if(camera.transform.position.y > 5.91f && linePos.y < levelHeight){
                            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                        }
                    }
                }
            }
            else{
                //Reset fishing line and camera
                        if(linePos.y < 0){
                            lineRenderer.SetPosition(1, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
                        }
                        if(camera.transform.position.y < 0 && linePos.y > levelHeight){
                            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
                        }
            }
        }
        
        
    }
}
