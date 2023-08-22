using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    private int distanceBetweenPlatforms = 30;

    public List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        GeneratePlatforms();
    }

    private void GeneratePlatforms()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            Instantiate(platforms[i], new Vector2(i * distanceBetweenPlatforms, 0), transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
