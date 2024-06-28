using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController playerControl;
    float movX, movZ;
    public float speed;
    public float degreeMultiplier;
    Vector3 move;

    [Header("SimulatedPhysics")]
    Vector3 gravity;
    float gravityScale = -9.8f;
    public float jumpForce;
    
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        move = transform.right * movX + transform.forward * movZ;
        
        if(movX != 0 || movZ != 0)
        {
            transform.Rotate(0, movX * degreeMultiplier, 0);
            
            playerControl.SimpleMove(move * speed); 
        }

        if(Input.GetButtonDown("Jump") && playerControl.isGrounded)
        {
            JumpPlayer();
        }
        if(!playerControl.isGrounded)
        {
            ApplyGravity();
        }
       
    }
    void ApplyGravity()
    {
        gravity.y += gravityScale * Time.deltaTime;
        playerControl.Move(gravity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        gravity.y = Mathf.Sqrt(gravityScale * -2 *jumpForce);
        playerControl.Move(gravity * Time.deltaTime);
    }
}
