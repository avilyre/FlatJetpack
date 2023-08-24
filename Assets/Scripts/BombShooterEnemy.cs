using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShooterEnemy : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject projectile;

    public float shootTime = 2f;
    private float gameTime;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= shootTime)
        {
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            gameTime = 0;
        }
    }
}
