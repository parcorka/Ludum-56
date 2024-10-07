using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the Audio Mixer
    public Slider masterSlider; // Reference to the master volume slider
    public Slider musicSlider;  // Reference to the music volume slider
    public Slider sfxSlider;    // Reference to the SFX volume slider

    void Start()
    {
        // Load saved volume settings
        masterSlider.value = PlayerPrefs.GetFloat("Master", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
    }

    public void SetMasterVolume(float volume)
    {
        //Debug.Log("volume " + volume);
        audioMixer.SetFloat("Master", Mathf.Log(volume)*20);
        PlayerPrefs.SetFloat("Master", volume); // Save volume setting
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume); // Save volume setting
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume); // Save volume setting
    }
}