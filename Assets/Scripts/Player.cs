using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject fishingLine;
    private LineRenderer lineRenderer;
    [SerializeField]
    float fishingLineSpeed = 1f;
    void Start()
    {
        lineRenderer = fishingLine.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    //Move player on Mouse X axis, convert mouse to world point
    if(Input.mousePosition.x > 50 && Input.mousePosition.x < Screen.width){
        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    //Move Fishing line
    Vector3 linePos = lineRenderer.GetPosition(0);


    if(Input.GetMouseButton(0)){
        lineRenderer.SetPosition(0, new Vector3(linePos.x, linePos.y - (fishingLineSpeed * Time.deltaTime), linePos.z));
    }
    else{
        if(linePos.y < 0){
            lineRenderer.SetPosition(0, new Vector3(linePos.x, linePos.y + (fishingLineSpeed * Time.deltaTime), linePos.z));
        }
    }

    }
}
