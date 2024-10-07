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
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume); // Save volume setting
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save volume setting
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save volume setting
    }
}