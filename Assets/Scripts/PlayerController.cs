using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;
    public Transform camy;
    public LayerMask groundMask;

    //public WitchyControls contolMe;
    public InputActionAsset contolMe;
    public InputActionMap Player;
    public InputAction Jump;
    public Animator animator;
    public AudioSource jump;
    private PlayerStats stats;

    
    float movementX;
    float movementY;
    [Header("PlayerMovement")]
    [Range(1f, 50f)]
    public float speed = 20;
    public float MaxSpeed = 12;
    private bool facingRight = true;
    public float linearDrag = 4f;

    [Header("JumpInfo")]

    public bool onGround = false;
    public float jumpSpeed = 15f;
    public float fallMultiplier = 5f;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;
    public float gravity = 1;
    public float jumpDelay = 0.25f;
    float jumpTimer;
    public bool jumpIsPressed;

    


    [Header("Camera")]

    public Vector3 offset;


    //Private Variables
    bool isPaused = false;


    
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    
        if((movementX > 0.1 && !facingRight) || (movementX < 0 && facingRight))
        {
            Flip();
        }

        

      


    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);

    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        contolMe = this.GetComponent<PlayerInput>().actions;
        Player = contolMe.FindActionMap("Player");
        /*
        contolMe.Player.Jump.performed += context => OnJump();
        contolMe.Player.Special.performed += context => OnSpecial();
        contolMe.Player.MenuButton.performed += context => OnMenuButton();
        

        */
        
        
        stats = GetComponent<PlayerStats>();


       
    }

    private void Start()
    {
       
    }

    private void Update()
    {

        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundMask) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundMask);
        if (Player.FindAction("Jump").IsPressed())
        {
            jumpIsPressed = true;
        }
        else
        {
            jumpIsPressed = false;
        }
        animator.SetFloat("walk", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", rb.velocity.y);
        animator.SetBool("jumpPressed", jumpIsPressed);
        animator.SetBool("onGround", onGround);
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("moveStickValue", Mathf.Abs(movementX));
        if (Mathf.Abs(rb.velocity.x) > 0.15)
        {
            stats.Oxygen -= 0.0001f;
            stats.OxygenStatBar.SetValue(stats.Oxygen);
        }

        
    }
    void FixedUpdate()
    {
        Vector2 moveme = new Vector2(movementX * speed * Time.deltaTime, 0f);

        
            rb.AddForce(moveme, ForceMode2D.Impulse);

        if (Mathf.Abs(rb.velocity.x) > MaxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * MaxSpeed, rb.velocity.y);
        }

        if(jumpTimer > Time.time && onGround)
        {
            jumpy();
        }

        modifyPhysics();


    }

    void modifyPhysics()
    {
        bool changingDirections = (movementX > 0 && rb.velocity.x < 0) || (movementX < 0 && rb.velocity.x > 0);

        if (onGround)
        {


            if (Mathf.Abs(movementX) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0 )
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if(rb.velocity.y > 0 && jumpIsPressed == false)
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }

    void OnJump()
    {
        jumpTimer = Time.time + jumpDelay;
        
            
        
        /*
        if (onGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        */

    }
    void jumpy()
    {
        jump.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0f;
    }

    void OnSpecial()
    {
        
    }

   void OnMenuButton()
    {
       

        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }

    private void OnEnable()
    {
        Player.FindAction("Jump").performed += context => OnJump();
        Player.FindAction("Special").performed += context => OnSpecial();
        Player.FindAction("MenuButton").performed += context => OnMenuButton();
        Jump = Player.FindAction("Jump");
        Player.Enable();
        
        
    }
    private void OnDisable()
    {
        Player.FindAction("Jump").performed += context => OnJump();
        Player.FindAction("Special").performed += context => OnSpecial();
        Player.FindAction("MenuButton").performed += context => OnMenuButton();
        Player.Disable();
    }

     




}
