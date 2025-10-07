using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    // Keeps track if this trigger can still be used
    bool active = true;

    // Assign your sound in the Inspector
    public AudioClip triggerSound;

    // How long to keep the object alive after triggering (auto-detects if sound assigned)
    private float destroyDelay = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.CompareTag("Player"))
        {
            active = false;

            // Increase score
            ScoreManager.score++;

            // Play sound once at this position
            if (triggerSound != null)
            {
                AudioSource.PlayClipAtPoint(triggerSound, transform.position);
                destroyDelay = triggerSound.length;
            }

            // Destroy or deactivate this trigger after sound finishes
            Destroy(gameObject, destroyDelay);
        }
    }
}