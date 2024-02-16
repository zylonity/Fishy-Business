using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIsh : MonoBehaviour
{

    public string ID = "ClownFish";
    private float movementSpeed = 1f;
    private float start;
    private float end;

    private float pointA = -3.2f;
    private float pointB = 4.8f;


    Vector3 startPoint, endPoint;


    
    public bool moved = false;
    public bool caught, hooked = false;

    Player player;
    Transform hook;

    float timer = 0;

    void Start()
    {
        //Default values
        gameObject.transform.position = new Vector3(pointA, transform.position.y, transform.position.z);
        start = Time.time;
        startPoint = new Vector3(pointA, transform.position.y, transform.position.z);
        endPoint = new Vector3(pointB, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if(!caught){
            //Reset fish trajectory
            if(gameObject.transform.position.x == pointB && !moved){
                end = Time.time;
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                moved = true;
            }

            //Reset fish trajectory
            if(gameObject.transform.position.x == pointA && moved){
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
        else{
            if(hook.position.y > 1.2f){
                player.caughtFish = false;
                player.uiController.fishCaught(ID);
                hooked = false;
                Destroy(gameObject);
            }

            

        }

        //Once hooked invoke fight so it runs in update
        if(hooked){
            if (FishStruggle()){
                gameObject.transform.parent = hook;
                player.caughtFish = true;
                player.hookedFish = false;
            }
        }
        else{
            if(caught){
                player.caughtFish = false;
                player.hookedFish = false;
                timer = 0;
            }
            
        }
        

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Verify player touched fish and freeze screen
        if(col.tag == "Player"){
            player = col.transform.parent.parent.GetComponent<Player>();
            hook = col.transform;
             if(player.hookedFish == false){
                hooked = true;
                player.hookedFish = true;
                caught = true;

             }
            
        }
        

    }

    bool FishStruggle(){
        timer += Time.deltaTime;

        if(timer < 5){
            //Add fish struggle here

            return false;
        }
        else{
            return true;
        }
    }
}
