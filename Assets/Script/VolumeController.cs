using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    public AudioMixer mixer;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 0.75f);
    }

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("GameVolume", sliderValue);
    }
}
