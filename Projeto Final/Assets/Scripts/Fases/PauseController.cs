using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    AudioSource music;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        music.volume = SoundController.MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateVolume()
    {
        float musicVolume = musicVolumeSlider.GetComponent<Slider>().value;
        SoundController.MusicVolume = musicVolume;

        float sfxVolume = sfxVolumeSlider.GetComponent<Slider>().value;
        SoundController.SFXVolume = sfxVolume;


        music.GetComponent<AudioSource>().volume = SoundController.MusicVolume;
    }
}
