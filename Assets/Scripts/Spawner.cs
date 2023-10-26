using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ShootingScript shootScript;
    
    public GameObject objectPrefab1;
    public GameObject objectPrefab2;
    public float spawnInterval = 5.0f;
    public float spawnAreaWidth = 120f;
    public float spawnAreaHeight = 60f;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            float randomY = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            // Spawn one of the objects randomly
            GameObject selectedObject = Random.Range(0f, 1f) < 0.5f ? objectPrefab1 : objectPrefab2;
            Instantiate(selectedObject, transform.position + spawnPosition, Quaternion.identity);

            // Set the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}