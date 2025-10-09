using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;
    public AudioClip triggerSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.CompareTag("Player"))
        {
            active = false;

            // Increase score directly
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.score++;
            }

            if (triggerSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(triggerSound);
                Destroy(gameObject, triggerSound.length);
            }
            else
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}