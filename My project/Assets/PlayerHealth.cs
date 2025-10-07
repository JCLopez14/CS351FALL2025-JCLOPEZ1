using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
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