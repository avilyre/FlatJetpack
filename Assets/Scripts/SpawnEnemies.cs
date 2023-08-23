using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
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
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + new Vector3(0f, Random.Range(0f, 3f), 0f), transform.rotation);
    }
}
