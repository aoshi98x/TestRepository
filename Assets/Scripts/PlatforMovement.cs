using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforMovement : MonoBehaviour
{
    public Transform limitPoint, limitPoint2;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, limitPoint2.position, speed/1000);
        if(transform.position.z >= limitPoint.position.z)
        {
            transform.position = Vector3.Lerp(transform.position, limitPoint2.position, speed/1000);
        }
        if(transform.position.z <= limitPoint2.position.z)
        {
            transform.position = Vector3.Lerp(transform.position, limitPoint.position, speed/1000);
        }
    }
}
