using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundToPlay;
    public float volume = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundToPlay, volume);



    }
}
