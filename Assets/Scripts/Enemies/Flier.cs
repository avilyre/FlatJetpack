using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flier : Enemy
{
    private Rigidbody2D rigidBody;
    public float moveSpeed = 3f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rigidBody.velocity = Vector3.left * moveSpeed;
    }
}
