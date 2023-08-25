using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int damage = 5;

    public virtual void ReceiveDamage(int receivedDamage)
    {
        health -= receivedDamage;
    }

    private void HealthChecker()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int receivedDamage = collision.GetComponent<Bullet>().damage;
            ReceiveDamage(receivedDamage);

            HealthChecker();
        }
    }
}
