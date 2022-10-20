using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public Sound[] soundsMusic;
    public Sound[] soundsEffect;
    private void Start()
    {
        foreach(Sound effect in soundsEffect)
        {
            effect.source = gameObject.AddComponent<AudioSource>();
            effect.source.clip = effect.clip;
            effect.source.loop = effect.loop;
        }
        foreach(Sound music in soundsMusic)
        {
            music.source = gameObject.AddComponent<AudioSource>();
            music.source.clip = music.clip;
            music.source.loop = music.loop;
        }
    }


    public void PlaySoundEffect(string soundName)
    {
        Sound effect = Array.Find(soundsEffect, item => item.name == soundName);
        if(effect == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
        effect.source.volume = effect.volume;
        effect.source.Play();
    }

    public void PlaySoundMusic(string soundName)
    {
        Sound music = Array.Find(soundsMusic, item => item.name == soundName);
        if (music == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
        music.source.volume = music.volume;
        music.source.Play();
    }

}
