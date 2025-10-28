using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //Player Movement Speed
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    public AudioClip jumpSound;

    private AudioSource playerAudio;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        //set refrence to plater audio source
        playerAudio = GetComponent<AudioSource>();

        //get the rigidbody2d component attached to the game object
        rb = GetComponent<Rigidbody2D>();
        //ensure the groundChecl variable is assigned
        if (groundCheck ==null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");

        }

    }

    void Update()
    {
        //Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("yVelocity", rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("onGround", isGrounded);

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);


        }
        else if (horizontalInput < 0)
       {
            transform.rotation = Quaternion.Euler(0, 180, 0);



        }
    }




}
