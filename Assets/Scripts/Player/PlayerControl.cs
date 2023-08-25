using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    private Rigidbody2D rigidBody;
    private Animator animator;

    public int health = 3;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // it is better here because the control can fail in some moments
        Control();
    }

    private void FixedUpdate()
    {
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

    private void AutoMovement()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }

    private void Control()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.RightShift))
        {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }

    public void OnJump()
    {
        if (!isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            isJumping = true;
        }
    }

    public void OnShoot()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        
    }

    public void ReceiveDamage(int receivedDamage)
    {
        health -= receivedDamage;

        if (health <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy bombProjectile = collision.gameObject.GetComponent<Enemy>();
            ReceiveDamage(bombProjectile.damage);
        }
    }
}
