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
    [SerializeField]
    float cameraCatchUpSpeed = 1.2f;

    RaycastHit hit;
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
            lineRenderer.SetPosition(0, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
        }
        if(camera.transform.position.y < 0){
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + (fishingLineSpeed * Time.deltaTime), camera.transform.position.z);
        }
    }


    void FixedUpdate(){

        // if (Physics.Raycast(linePos, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        //     {
        //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //         Debug.Log("Did Hit");
        //     }
        //     else
        //     {
        //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //         Debug.Log("Did not Hit");
        //     }



    }

    }
}
