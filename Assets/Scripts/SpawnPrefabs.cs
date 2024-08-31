using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform spawnTransform;
    public int spawnCount;

    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            Instantiate(spawnPrefab, spawnTransform);

        }


    }
}
