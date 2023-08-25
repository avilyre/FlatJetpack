using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlierEnemy : MonoBehaviour
{
    private float gameTime = 0;
    public float spawnTime = 5f;

    public List<GameObject> enemies = new List<GameObject>();

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= spawnTime)
        {
            SpawnEnemy();
            gameTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + new Vector3(0f, Random.Range(-3f, 1.30f), 0f), transform.rotation);
    }
}
