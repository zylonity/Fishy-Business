using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] FishPrefab;
    public GameObject[] SpawnPoints;

    private void Start()
    {
        SpawnPoints = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
        {
            SpawnPoints[i] = transform.GetChild(i).gameObject;
        }
        
        SpawnFish();
    }

    public void SpawnFish()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (SpawnPoints[i].transform.childCount < 1)
            {
                int temp = UnityEngine.Random.Range(0, 101);

                if (temp <= 50)
                {
                    Instantiate(FishPrefab[0], SpawnPoints[i].transform);
                }
                else if (temp <= 80)
                {
                    Instantiate(FishPrefab[1], SpawnPoints[i].transform);
                }
                else if (temp <= 95)
                {
                    Instantiate(FishPrefab[2], SpawnPoints[i].transform);
                }
                else
                {
                    Instantiate(FishPrefab[3], SpawnPoints[i].transform);
                }
                
                
            }
        }
    }
}
