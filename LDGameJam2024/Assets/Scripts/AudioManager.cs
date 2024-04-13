using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds) { 
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.soundClip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        Play("MainMenu");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound =>  sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void ChangeMusicVolume(float value)
    {
        AudioListener.volume = value;
    }
}
