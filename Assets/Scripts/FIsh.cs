using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIsh : MonoBehaviour
{

    public string ID = "ClownFish";
    private float movementSpeed = 1f;
    private float start;
    private float end;
    Vector3 startPoint, endPoint;

    public Transform pointA, pointB;
    
    public bool moved = false;

    void Start()
    {
        //Default values
        gameObject.transform.position = new Vector3(pointA.position.x, transform.position.y, transform.position.z);
        start = Time.time;
        startPoint = new Vector3(pointA.position.x, transform.position.y, transform.position.z);
        endPoint = new Vector3(pointB.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        //Reset fish trajectory
        if(gameObject.transform.position.x == pointB.position.x && !moved){
            end = Time.time;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            moved = true;
        }

        //Reset fish trajectory
        if(gameObject.transform.position.x == pointA.position.x && moved){
            start = Time.time;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            moved = false;
        }

        //Move fish
        if(!moved){
            transform.position = Vector3.Lerp(startPoint, endPoint, (Time.time - start) * movementSpeed);
        }
        else{
            transform.position = Vector3.Lerp(endPoint, startPoint, (Time.time - end) * movementSpeed);
        }
        
    }
}
