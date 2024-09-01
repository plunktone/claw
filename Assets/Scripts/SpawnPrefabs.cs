using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] spawnPrefab;
    public Transform spawnTransform;
    public int spawnCount;
    private float spawnDelay = 0.15f;
    


    private void Start() {
        
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            int randomNum = Random.Range(0,99);
            GameObject toy = GetSpawnRandomNum(randomNum);
            SpawnToys(toy);

            Debug.Log(randomNum);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

        private GameObject GetSpawnRandomNum(int randomNum)
        {
            if (randomNum <= 70)
            return spawnPrefab[0];
            else if (randomNum <= 90 && randomNum>70)
            return spawnPrefab[1];
            else
            return spawnPrefab[2];
        }

        private void SpawnToys(GameObject toy)
        {
            GameObject spawnToy = Instantiate(toy,spawnTransform);

            Vector2 randomDirection = Random.insideUnitCircle * 5f;
            spawnToy.GetComponent<Rigidbody2D>().velocity = randomDirection;

            float randomRotation = Random.Range(0f, 360f);
            spawnToy.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

        }

}
