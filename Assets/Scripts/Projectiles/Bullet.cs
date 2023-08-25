using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 15;
    public int damage = 5;

    private Rigidbody2D rigidBody;
    public GameObject feedbackEffect;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
        rigidBody.velocity = Vector2.right * moveSpeed;
    }

    public void OnHit()
    {
        GameObject feedbackEffectInstantiated = Instantiate(feedbackEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(feedbackEffectInstantiated, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            OnHit();
        }
    }
}
