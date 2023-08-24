using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject player;
    public float cameraMoveSpeed = 100; // Need to be hight to reduce tremolo
    public float cameraOffset = -6;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        Vector3 cameraPosition = new Vector3(player.transform.position.x - cameraOffset, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, cameraPosition, cameraMoveSpeed * Time.deltaTime);
    }
}
