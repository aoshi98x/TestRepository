using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offsetCamera;
    Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    void LateUpdate()
    {
        transform.position = player.position + offsetCamera;
    }
}
