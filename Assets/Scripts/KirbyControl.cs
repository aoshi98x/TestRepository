using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyControl : MonoBehaviour
{
    Animator animatorControl;
    public bool wasEating; //Checker de si ya comí al enemigo 
    public bool isEating; // Checker de si estoy intentando comer
    
    void Start()
    {
        animatorControl =GetComponent<Animator>(); // Referencio el componente Animator
    }

    // Update is called once per frame
    void Update()
    {
        //Igualo el bool Eat del Animator con el Input de la barra espaciadora
        // Es decir, cuando oprima la barra, el estado de animación cambia
        animatorControl.SetBool("Eat", Input.GetButton("Jump"));

        //Pregunto si estoy presionando constantemente la barra espaciadora
        if(Input.GetButton("Jump"))
        {
            //si es cierto, entonces cambio el checker de la acción comer a verdadero
            isEating = true;
            
            //Aquí pregunto si estoy detectando una colisión por medio del Casteo
            //es decir, si hay algo dentro del rango del círculo externo
            if(Enemy())
            {
                //si detecta el "Enemigo", hace que se mueva hacia mí.
                Enemy().transform.position = Vector2.Lerp(Enemy().transform.position,transform.position, Time.deltaTime);
                //Debug.Log(Enemy().name);
            }
        }
        else
        {
            //Si no ocurre nada de lo anterior, simplemente no estamos intentando comer
            isEating = false;
        }
        
        //Pregunto si presiono click izquierdo y ya me comí al enemigo
        if(Input.GetButton("Fire1") && wasEating)
        {
            //Puedo usar el poder (aquí solo está la animación)
            animatorControl.SetBool("IHavePower", true);
        }
        else
        {
            //Sino, mantengo el poder apagado (false)
            animatorControl.SetBool("IHavePower", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Reviso si cuando algo colisiona estoy intentando comer y eso
        // que colisiona tiene el Tag de "Power"
        if(other.gameObject.CompareTag("Power") && isEating)
        {
            //De ser cierto, significa que me comí al enemigo y por ende
            //El checker de que comí pasa a verdadero (true)
            wasEating = true;
            //Desactivo al enemigo para evitar errores y que se vea que se lo comió
            other.gameObject.SetActive(false);
        }
    }

    //Esta función sirve para crear un círculo que detecta si un colisionador (objeto) ha entrado
    //en el rango
    public Collider2D Enemy()
    {
        //Esto e slo que dibuja el rango en forma de círculo 2D
        //Partiendo de un coordenada (Vector2), con un radio y detectando colisionadores en una 
        //LayerMask determinada
        return Physics2D.OverlapCircle(transform.position,3.0f,LayerMask.GetMask("Default"));
    }

    //Lo dibujamos para verlo
    private void OnDrawGizmos()
    {
        //Elegimos el color
        Gizmos.color = Color.green;
        //Esto lo dibuja en el espacio
        Gizmos.DrawWireSphere(transform.position, 3.0f);
        
    }
}
