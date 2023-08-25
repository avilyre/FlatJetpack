using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Enemy
{
    private Rigidbody2D rigidBody;
    private PlayerControl player;

    public float xAxis = -5f;
    public float yAxis = 6f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }
}
