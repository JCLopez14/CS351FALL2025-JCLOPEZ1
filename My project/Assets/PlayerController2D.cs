using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Health")]
    public int health = 3;

    [Header("Stomp Settings")]
    public float bounceForce = 10f; // bounce velocity after stomping

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Landing on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Enemy collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth2D enemyHealth = collision.gameObject.GetComponent<EnemyHealth2D>();
            if (enemyHealth == null) return;

            // Get bounds
            float playerBottom = col.bounds.min.y;
            float enemyTop = collision.collider.bounds.max.y;

            // Check if player is above enemy (stomp)
            if (playerBottom > enemyTop - 0.05f && rb.velocity.y <= 0)
            {
                // Deal damage to enemy
                enemyHealth.TakeDamage(1);

                // Bounce player
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
            }
            else
            {
                // Player takes damage from side or bottom
                health--;
                Debug.Log("Player hit! Health: " + health);

                if (health <= 0)
                {
                    Debug.Log("Player Died!");
                    Destroy(gameObject);
                }
            }
        }
    }
}