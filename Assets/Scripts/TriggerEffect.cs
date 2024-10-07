using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip triggerAudio;
    private bool firstTime;

    private void Start()
    {
        firstTime = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && firstTime)
        {
            //audioSource.Stop(); // i wonder if this is required
            audioSource.clip = triggerAudio;
            audioSource.Play();
            firstTime = false;
        }
    }
}
