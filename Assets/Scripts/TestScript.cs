using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer cylinderRenderer;
    float redValue, greenValue, blueValue;

    // Se jecuta en el primer frame renderizado por escena
    void Start(){

        cylinderRenderer = GameObject.Find("Cylinder").GetComponent<MeshRenderer>();
    }

    // Se ejecuta cada frame - Aquí se suelen comprobar condiciones como Inputs
    void Update(){

        if(Input.GetButtonDown("Fire1"))
        {
            cylinderRenderer.material.color = RandomColor();
        }
    }

    Color RandomColor()
    {
        redValue = Random.Range(0,1f);
        greenValue = Random.Range(0,1f);
        blueValue = Random.Range(0,1f);

        return new Color(redValue, greenValue, blueValue); 
    }

}
