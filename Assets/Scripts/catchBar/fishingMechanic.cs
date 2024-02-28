using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingMechanic : MonoBehaviour
{
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timeMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    public float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravity = 0.005f;
    [SerializeField] float hookDeProgressPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] public float failTimer = 10f;

    public bool Success = false;

    private void Start()
    {
        Resize();
    }

    private void Update()
    {   
        if (pause) { return; }

        Fish();
        Hook();
        ProgressCheck();
    }

    private void Resize() //allows the "hookArea" to be resized and keeps it contained in its own bar area
    {
        Bounds b = hookSpriteRenderer.bounds;
        float xSize = b.size.x;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(top.position, bottom.position);
        ls.x = (distance / xSize * hookSize);
        hook.localScale = ls;
    }

    private void ProgressCheck() //the longer the hookarea is over the fish, the higher the progress bar goes up/ win and lose conditions
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.x = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookDeProgressPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if (failTimer < 0f)
            {
                Success = false;
            }
        }

        if (hookProgress > 1f)
        {
            Success = true;
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Win() //temp win message
    {
        pause = true;
        Debug.Log("You Caught Fish !!");

    }

    private void Lose() //temp lose message
    {
        pause = true;
        Debug.Log("The fish got away :(");

    }

    void Hook() //allows the hook to be controlled by mouse click and has velocity and gravity controls that can be altered
    {
        if(Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if (hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottom.position, top.position, hookPosition);
    }

    void Fish() //randomises the speed/movement of the fish icon to add in difficulty 
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottom.position, top.position, fishPosition);
    }

}
