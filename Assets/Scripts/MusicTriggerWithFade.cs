using UnityEngine;
using System.Collections;

public class MusicTriggerWithFade : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip newMusic;
    public float fadeDuration = 0.7f; // Duration of the fade

    private bool isFading = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeOutAndSwitch(fadeDuration));
        }
    }

    IEnumerator FadeOutAndSwitch(float duration)
    {
        isFading = true;

        // Fade out the current music
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();

        // Switch to the new music
        audioSource.clip = newMusic;
        audioSource.Play();

        // Fade in the new music
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / duration);
            yield return null;
        }

        audioSource.volume = startVolume;
        isFading = false;
    }
}