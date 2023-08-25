using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float parallaxWidth;
    private float initialPosition;

    public GameObject camera;

    public float moveSpeed;

    void Start()
    {
        initialPosition = transform.position.x;
        parallaxWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float resposition = camera.transform.position.x * (1 - moveSpeed);
        float distance = camera.transform.position.x * moveSpeed;

        transform.position = new Vector3(initialPosition + distance, transform.position.y, transform.position.z);

        if (resposition > initialPosition + parallaxWidth)
        {
            initialPosition += parallaxWidth;
        }
    }
}
