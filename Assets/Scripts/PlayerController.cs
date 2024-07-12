using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    CharacterController controller;
    [SerializeField] float movX, movZ;
    float gravityScale = -9.8f;
    [Range(0,5)]
    public float speed;
    [Range(1,5)]
    public int jumpForce;
    Vector3 movement;
    [SerializeField] Vector3 gravity;

    [Header ("Multijugador Local")]
    public string controlPlayerX, controlPlayerZ;  

    [Header ("Gameplay variables")]
    public int ringCount;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        movX = Input.GetAxis(controlPlayerX);
        movZ = Input.GetAxis(controlPlayerZ);
        
        MovePlayer();
        
        
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            JumpPlayer();
        }

        if(!controller.isGrounded)
        {
            ApplyGravity();
        }
        else
        {
            gravity.y = -2;
        }
        if(Input.GetButtonDown("Pause"))
        {
            GameManager.Instance.CheckPause();
        }
        if(GameManager.Instance.cachedRing)
        {
            StartCoroutine(BreakingHunter());
        }
        else{
            
            StopCoroutine(BreakingHunter());
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {

        if(hit.gameObject.CompareTag("Ring"))
        {
            ringCount ++;
            hit.gameObject.SetActive(false);
            GameManager.Instance.cachedRing = true;
        }
    }

    IEnumerator BreakingHunter()
    {
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.cachedRing = false;
        
    }
    void MovePlayer()
    {
        movement = transform.right * movX + transform.forward * movZ;
        controller.SimpleMove(movement * speed);
    }
    void ApplyGravity()
    {
        gravity.y += gravityScale * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        gravity.y = Mathf.Sqrt(gravityScale * -2 *jumpForce);
        controller.Move(gravity * Time.deltaTime);
    }
}

