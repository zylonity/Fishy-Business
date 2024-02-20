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

    private void Update()
    {
        fishTimer -= Time.deltaTime;
        if(fishTimer <0f)
        {
            fishTimer = UnityEngine.Random.value;

            fishDestination =  UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottom.position, top.position, fishPosition);

    }

}
