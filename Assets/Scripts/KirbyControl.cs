using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyControl : MonoBehaviour
{
    Animator animatorControl;
    public bool wasEating, isEating;
    
    void Start()
    {
        animatorControl =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animatorControl.SetBool("Eat", Input.GetButton("Jump"));

        if(Input.GetButton("Jump"))
        {
            isEating = true;
            
            if(Enemy())
            {
                Enemy().transform.position = Vector2.Lerp(Enemy().transform.position,transform.position, Time.deltaTime);
                //Debug.Log(Enemy().name);
            }
        }
        else{
            isEating = false;
        }
        
        if(Input.GetButton("Fire1") && wasEating)
        {
            animatorControl.SetBool("IHavePower", true);
        }
        else
        {
            animatorControl.SetBool("IHavePower", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Power") && isEating)
        {
            wasEating = true;
            other.gameObject.SetActive(false);
        }
    }

    public Collider2D Enemy()
    {
        return Physics2D.OverlapCircle(transform.position,3.0f,LayerMask.GetMask("Default"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3.0f);
        
    }
}
