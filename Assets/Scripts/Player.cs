using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject fishingLine;
    GameObject camera;
    private LineRenderer lineRenderer;
    [SerializeField]
    float fishingLineSpeed = 1f;
    void Start()
    {
        lineRenderer = fishingLine.GetComponent<LineRenderer>();
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    //Move player on Mouse X axis, convert mouse to world point
    if(Input.mousePosition.x > 150 && Input.mousePosition.x < Screen.width){
        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    //Move Fishing line
    Vector3 linePos = lineRenderer.GetPosition(0);


    if(Input.GetMouseButton(0)){
        lineRenderer.SetPosition(0, new Vector3(linePos.x, linePos.y - (fishingLineSpeed * Time.deltaTime), linePos.z));
        //Move Camera
        if(linePos.y < -4){
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
        }
    }
    else{
        if(linePos.y < 0){
            lineRenderer.SetPosition(0, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
        }
        if(camera.transform.position.y < 0){
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
        }
    }



    }
}
