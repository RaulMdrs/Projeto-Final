using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController
{
    private static float musicVolume = 1.0f;
    private static float sfxVolume = 1.0f;

    public static float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = Mathf.Clamp01(value);
        }
    }

    public static float SFXVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = Mathf.Clamp01(value);
        }
    }
}
