using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform spawnTransform;
    public int spawnCount;
    private float spawnDelay = 1f;


    private void Start() {
        
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            
            GameObject spawnInst  = Instantiate(spawnPrefab, spawnTransform);
            Vector2 randomDirection = Random.insideUnitCircle * 5f;
            spawnInst.GetComponent<Rigidbody2D>().velocity = randomDirection;

        }

        yield return new WaitForSeconds(spawnDelay);
    }
}
