using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fish : MonoBehaviour
{

    public string ID = "Undefined";
    public float movementSpeed = 1f;
    private float start;
    private float end;

    private float pointA = -3.9f;
    private float pointB = 4.8f;

    Vector3 startPoint, endPoint;

    public GameObject StruggleMechanicPrefab;

    
    public bool moved = false;
    public bool caught, failed, hooked = false;

    Player player;
    Transform hook;

    float timer = 0;

    public GameObject particlePrefab;
    private Light2D[] lights;

    void Start()
    {
        //Default values
        gameObject.transform.position = new Vector3(pointA, transform.position.y, transform.position.z);
        start = Time.time;
        startPoint = new Vector3(pointA, transform.position.y, transform.position.z);
        endPoint = new Vector3(pointB, transform.position.y, transform.position.z);
        lights = GetComponentsInChildren<Light2D>();
    }

    void Update()
    {
        
        if(!caught && !hooked && !failed){
            //Reset fish trajectory
            if(gameObject.transform.position.x == pointB && !moved){
                end = Time.time;
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                //Makes sure particles are going up as particles get scale flipped with fish
                if (particlePrefab)
                {
                    particlePrefab.transform.localScale = new Vector3(-particlePrefab.transform.localScale.x, particlePrefab.transform.localScale.y, particlePrefab.transform.localScale.z); 
                }
                
                moved = true;
            }
            
            //Reset fish trajectory
            if(gameObject.transform.position.x == pointA && moved){
                start = Time.time;
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                
                //Makes sure particles are going up as particles get scale flipped with fish
                if (particlePrefab)
                {
                    particlePrefab.transform.localScale = new Vector3(-particlePrefab.transform.localScale.x, particlePrefab.transform.localScale.y, particlePrefab.transform.localScale.z); 
                }
                
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
                GameManager.Instance.FishCaught(ID);
                hooked = false;
                //Destroy(gameObject);
                StartCoroutine(HideThenDestroy()); //added to allow bubbles to fade out when fish is caught
            }

            

        }

        //Once hooked invoke fight so it runs in update
        if(hooked){
            if (FishStruggle() == true && player.caughtFish){
                caught = true;
                gameObject.transform.parent = hook;
                player.hookedFish = false;
                
            }
            else if (FishStruggle() == true && player.failedFish)
            {
                caught = false;
                hooked = false;
                player.caughtFish = false;
                player.hookedFish = false;
                player.failedFish = false;
                Destroy(gameObject, 1f);
   
            }
        }
        else{
            if(caught){
                caught = false;
                failed = false;
                player.caughtFish = false;
                player.failedFish = false;
                player.hookedFish = false;
                timer = 0;
            }
            
        }
        

        
    }

    IEnumerator HideThenDestroy()
    {
        GetComponent<SpriteRenderer>().enabled = false; //Hides fish sprite
        GetComponent<BoxCollider2D>().enabled = false; //Disables fish collider

        //Disables lights
        foreach (Light2D light in lights)
        {
            light.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(3f);
        
        Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Verify player touched fish and freeze screen
        if(col.tag == "Player"){
            player = col.transform.parent.parent.GetComponent<Player>();
            hook = col.transform;
             if(player.hookedFish == false && player.caughtFish == false && player.failedFish == false){
                player.hookedFish = true;
                hooked = true;

                //Flips hook towards collider
                BoxCollider2D fishCollider = GetComponent<BoxCollider2D>();

                if (hook.position.x < transform.position.x + fishCollider.bounds.center.x && col.name == "Hook")
                {
                    col.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
                else
                {
                    col.GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
             }
            
        }
        

    }

    bool FishStruggle(){
        timer += Time.deltaTime;
        
        if(timer < 11 && !player.caughtFish && !player.failedFish){
            //Add fish struggle here

            if (GameManager.Instance._FishingMechanicParent.transform.childCount < 1 && !player.caughtFish && !player.failedFish)
            {
                Instantiate(StruggleMechanicPrefab, GameManager.Instance._FishingMechanicParent.transform);
            }
            

            return false;
        }
        else
        {
            return true;
        }
    }
}
