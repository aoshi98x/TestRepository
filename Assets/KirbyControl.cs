using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyControl : MonoBehaviour
{
    Animator animatorControl;
    public bool iEated, eating;
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
            eating = true;
            //Va el codigo donde hacemos la absorción del enemigo
        }
        else{
            eating = false;
        }
        
        if(Input.GetButton("Fire1") && iEated)
        {
            animatorControl.SetBool("IHavePower", true);
        }
        else
        {
            animatorControl.SetBool("IHavePower", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Power") && eating)
        {
            iEated = true;
            other.gameObject.SetActive(false);
        }
    }
}
