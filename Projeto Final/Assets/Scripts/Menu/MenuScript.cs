using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    AudioSource music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
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
