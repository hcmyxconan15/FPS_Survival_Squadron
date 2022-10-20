using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSound : MonoBehaviour
{
    public Sound music;

    private void Start()
    {
        music.source = gameObject.AddComponent<AudioSource>();
        music.source.clip = music.clip;
        music.source.loop = music.loop;
    }


    public void PlaySound(string soundName)
    {
        if (music == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
        music.source.volume = music.volume;
        music.source.Play();
    }
}
