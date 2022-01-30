using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find( sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        if(!s.source.isPlaying)
            s.source.Play();
    }    

    public void Play(string name, int index)
    {
        var s = Array.FindAll(sounds, sound => sound.name.Contains(name));
        var specific = Array.Find(sounds, sound => sound.name == $"{name}_{index}");
        if (s == null || specific == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        if (!s.Any(sound => sound.source.isPlaying))
            specific.source.Play();
    }

    public void PlayRandom(string name, int rangeMinInclusive, int rangeMaxExclusive)
    {
        int soundIndex = UnityEngine.Random.Range(rangeMinInclusive, rangeMaxExclusive);
        Play(name, soundIndex);
    }

    public void PlayRandomOverride(string name, int rangeMinInclusive, int rangeMaxExclusive)
    {
        int soundIndex = UnityEngine.Random.Range(rangeMinInclusive, rangeMaxExclusive);
        PlayWithOverride(name, soundIndex);
    }

    void PlayWithOverride(string name, int index)
    {
        var s = Array.FindAll(sounds, sound => sound.name.Contains(name));
        var specific = Array.Find(sounds, sound => sound.name == $"{name}_{index}");
        if (s == null || specific == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        foreach(var sound in s)
        {
            sound.source.Stop();
        }

        specific.source.Play();
    }

    public void ReplaceMusic(string previousTrack, string nextTrack)
    {
        Sound previous = Array.Find(sounds, sound => sound.name == previousTrack);
        Sound next = Array.Find(sounds, sound => sound.name == nextTrack);

        if(previous != null)
            previous.source.Stop();

        if(next != null)
            next.source.Play();
    }
}
