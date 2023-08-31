using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseTeste : MonoBehaviour
{


    AudioSource music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        music.volume = SoundController.MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
