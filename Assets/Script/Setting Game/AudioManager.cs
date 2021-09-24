using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public DATA_MENU menuSetting;
    public Sound[] music;
    public Sound[] effect;

    private void Awake()
    {
        foreach (Sound s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumne;
            s.source.loop = s.loop;
        }
        foreach (Sound s in effect)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumne;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        TurnMusic();
        TurnEffect();
    }
    private void Update()
    {
        TurnMusic();
        TurnEffect();
    }

    public void TurnMusic()
    {
        if (menuSetting.Sound[0].onSound)
        {
            foreach (Sound i in music)
            {
                i.source.volume = 1;
            }
        }
        else
        {
            foreach (Sound i in music)
            {
                i.source.volume = 0;
            }
        }

    }
    public void TurnEffect()
    {
        if (menuSetting.Sound[1].onSound)
        {
            foreach (Sound i in effect)
            {
                i.source.volume = 1;
            }
        }
        else
        {
            foreach (Sound i in effect)
            {
                i.source.volume = 0;
            }
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        s.source.Play();
    }
    public void PlayEffect(string name)
    {
        Sound s = Array.Find(effect, sound => sound.name == name);
        s.source.Play();
    }
}
