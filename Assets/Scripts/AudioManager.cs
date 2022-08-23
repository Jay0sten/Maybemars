using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip =sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            

            sound.source.loop = sound.loop;
            
        }


    }

    public void Play(string name)
    {
       
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("There is no song to play brosky");
            return;
        }
        s.source.Play();

    }
    
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            Debug.Log("I couldn't find the sound you wanted to stop...");
            return;
        }
        s.source.Stop();
    }



}
