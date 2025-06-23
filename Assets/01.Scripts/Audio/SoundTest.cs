using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip growlClip;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audioSource.clip = growlClip;

        audioSource.spatialBlend = 1.0f; //3D Sound
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 15f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;

        audioSource.Play();
    }

    
}
