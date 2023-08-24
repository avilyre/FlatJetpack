using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    public GameObject enemy;
    private GameObject spawnedEnemy;
    private GameObject spawnPoint;

    public List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        SpawnEnemy();
    }

    public void RespawnEnemy()
    {
        if (spawnedEnemy == null)
        {
            SpawnEnemy();
        } else
        {
            spawnedEnemy.transform.position = spawnPoint.transform.position;
        }
    }

    private void SpawnEnemy()
    {
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        spawnedEnemy = Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
