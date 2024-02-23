using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLighting : MonoBehaviour
{
    public GameObject hook;
    private Light2D globalLight;

    private void Awake()
    {
        globalLight = GetComponent<Light2D>();
    }

    private void Update()
    {
        globalLight.intensity = 1 - Mathf.Abs(hook.transform.position.y) / 50;
    }
}
