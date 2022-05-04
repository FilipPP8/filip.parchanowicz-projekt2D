using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;

    public static AudioManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach(Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;
            s._source.volume = s._volume;
            s._source.pitch = s._pitch;
            s._source.loop = s._loop;

        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        
        if (s==null)
        {
            return;
        }
        
        s._source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        s._source.Stop();
    }

}
