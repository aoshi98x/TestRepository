using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    //Datos requeridos
    Rigidbody playerRigidbody;
    float movX, movZ;
    public float degrees, speed, jumpForce;
    bool isJumping;
    public int points;
    public string controlH, controlV;
    Vector3 movement;
    GameManager gameManager;

    void Start()
    {
        //Referencia Componente RigidBody
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Guardamos los inputs en MovX y movZ
        movX = Input.GetAxis(controlH);
        movZ = Input.GetAxis(controlV);

        //En este Vector3 Decimos que almacene el valor y lo asigne al eje Z
        movement = transform.forward * movZ;

        //Si Oprimo Barra espaciadora y NO estoy saltando
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            // Añado fuerza ascendente con una fuerza en modo de impulso
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate() {
        
        //Si estoy presionando los botones de movimiento
        if(movX != 0 || movZ != 0)
        {
            //Muevo a mi personaje de manera frontal
            playerRigidbody.MovePosition(transform.position + movement * Time.deltaTime * speed);
            //Roto para poder dirigirlo
            transform.Rotate(0, movX * degrees, 0);
        }
    }

    //Si entro en colisión con algún collider
    private void OnCollisionEnter(Collision other) {

        //Verifico si el collider tiene tag de Coin
        if(other.gameObject.CompareTag("Coin"))
        {  
            //Destruyo (Elimino) ese objeto Coin
            Destroy(other.gameObject);
            //Sumo un punto
            points += 1;
        }
        
        if(other.gameObject.CompareTag("LimitLose"))
        {  
            gameManager.LoseGame("SampleScene");
        }

        //Verifico si el collider tiene tag de Floor
        if(other.gameObject.CompareTag("Floor"))
        {
            //Significa que NO estoy saltando
            isJumping = false;
        }

    }
    //Si dejo de colisionar con algún collider
    private void OnCollisionExit(Collision other) {
        
        //Si ese collider tiene tag Floor
        if(other.gameObject.CompareTag("Floor"))
        {
            //Estoy saltando
            isJumping = true;
        }
    }

}
