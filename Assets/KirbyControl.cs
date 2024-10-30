using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyControl : MonoBehaviour
{
    Animator animatorControl;
    public bool iEated;
    void Start()
    {
        animatorControl =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animatorControl.SetBool("Eat", Input.GetButton("Jump"));
        
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
        if(other.CompareTag("Power"))
        {
            iEated = true;
            other.gameObject.SetActive(false);
        }
    }
}
