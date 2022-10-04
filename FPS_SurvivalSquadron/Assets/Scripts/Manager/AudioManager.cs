using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

    private void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string soundName)
    {
        Sound sound = Array.Find(sounds, item => item.name == soundName);
        if(sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
        sound.source.volume = sound.volume;
        sound.source.Play();
    }
}
