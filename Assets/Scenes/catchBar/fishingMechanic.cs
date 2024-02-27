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
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravity = 0.005f;
    [SerializeField] float hookDeProgressPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 10f;

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

    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float xSize = b.size.x;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(top.position, bottom.position);
        ls.x = (distance / xSize * hookSize);
        hook.localScale = ls;
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
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
                Lose();
            }
        }

        if (hookProgress > 1f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Win()
    {
        pause = true;
        Debug.Log("You Caught Fish !!");

    }
    private void Lose()
    {
        pause = true;
        Debug.Log("The fish got away :(");

    }

    void Hook()
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

    void Fish()
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
