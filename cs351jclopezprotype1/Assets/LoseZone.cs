using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LoseZone triggered by: " + collision.gameObject.name);

        // Make sure it only triggers when the player falls in
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player detected in lose zone!");

            if (ScoreManager.Instance != null)
            {
                Debug.Log("Setting game over to true");
                ScoreManager.Instance.gameOver = true;
                ScoreManager.Instance.won = false;
            }
            else
            {
                Debug.LogError("ScoreManager.Instance is NULL!");
            }
        }
        else
        {
            Debug.Log("Object is not tagged as Player. Tag is: " + collision.tag);
        }
    }
}