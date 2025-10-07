using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make sure it only triggers when the player falls in
        if (collision.CompareTag("Player"))
        {
            ScoreManager.gameOver = true;
            ScoreManager.won = false;
        }
    }
}