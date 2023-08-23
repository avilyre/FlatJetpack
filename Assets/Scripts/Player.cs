using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Control();
        AutoMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            animator.SetBool("Jumping", false);
            isJumping = false;
        }
    }

    void Control()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            isJumping = true;
        }
    }

    void AutoMovement()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }
}
