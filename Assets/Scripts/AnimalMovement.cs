using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [Range (0,2)]
    public float speed;
    void Update()
    {
        transform.Translate(0,0,speed);
    }
}
