using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float moveSpeed = 3f;
    public float jumpFoce = 10f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Control();
        AutoMovement();
    }

    void Control()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0f, jumpFoce), ForceMode2D.Impulse);
        }
    }

    void AutoMovement()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }
}
