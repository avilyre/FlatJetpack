using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    private int distanceBetweenPlatforms = 30;

    // Loop Variables
    private int currentPlatformIndex = 0;
    private float platformOffset = 0;

    private GameObject player;

    public List<GameObject> platforms = new List<GameObject>();
    public List<GameObject> generatedPlatforms = new List<GameObject>();

    private GameObject currentEndPlatform;

    void Start()
    {
        GeneratePlatforms();

        player = GameObject.FindGameObjectWithTag("Player");
        currentEndPlatform = generatedPlatforms[currentPlatformIndex].GetComponent<Platform>().EndPlatform;
    }

    void Update()
    {
        CheckPlayerWithEndPlatformCollision();
    }

    private void CheckPlayerWithEndPlatformCollision()
    {
        float distanceBetweenPlayerAndCurrentPlatform = player.transform.position.x - currentEndPlatform.transform.position.x;

        if (distanceBetweenPlayerAndCurrentPlatform >= 1)
        {
            RecyclePlatform(generatedPlatforms[currentPlatformIndex].gameObject);
            currentPlatformIndex += 1;

            if (currentPlatformIndex > platforms.Count - 1)
            {
                currentPlatformIndex = 0;
            }

            currentEndPlatform = generatedPlatforms[currentPlatformIndex].GetComponent<Platform>().EndPlatform;
        }
    }

    private void GeneratePlatforms()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            GameObject platform = Instantiate(platforms[i], new Vector2(i * distanceBetweenPlatforms, transform.position.y), transform.rotation);
            generatedPlatforms.Add(platform);

            platformOffset += 30f;
        }
    }

    private void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector2(platformOffset, transform.position.y);
        platformOffset += 30;

        bool hasSpawnEnemy = platform.GetComponent<Platform>().spawnEnemies != null;

        if (hasSpawnEnemy)
        {
            platform.GetComponent<Platform>().spawnEnemies.RespawnEnemy();
        }
    }
}
