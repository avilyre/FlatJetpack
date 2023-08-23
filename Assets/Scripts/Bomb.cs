using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public float xAxis = -5f;
    public float yAxis = 6f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        
    }
}
