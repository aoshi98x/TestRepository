using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float movimientoHorizontal;
    float movimientoVertical;
    float movimientoFrontal;
    
    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");
        movimientoFrontal = Input.GetAxis("Frontal");
        if(movimientoHorizontal != 0 || movimientoVertical != 0 || movimientoFrontal !=0)
        {
            transform.Translate(movimientoHorizontal, movimientoVertical, movimientoFrontal);
        }
    }
}
