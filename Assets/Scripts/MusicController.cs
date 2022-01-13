using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    //private static MusicController musicInstance;
    [SerializeField] private Slider volumeSlider;
    public AudioMixer mixer;
    public AudioSource musicSource;
    public AudioClip bgmMusic;

    /*void Awake()
    {
        DontDestroyOnLoad(this);

        if(musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 0.8f);
        musicSource.clip = bgmMusic;
        musicSource.Play();
    }

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("GameVolume", sliderValue);
    }
}
