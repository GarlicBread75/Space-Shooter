using System;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    public Sound[] sounds;
    bool nextSong;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void FixedUpdate()
    {
        if (!nextSong)
        {
            SongDonePlaying("MainMenu 1");
        }
        else
        {
            SongDonePlaying("MainMenu 2");
        }
    }

    private void Start()
    {
        int num = UnityEngine.Random.Range(0, 2);

        if (num == 0)
        {
            Play("MainMenu 1");
            nextSong = false;
        }
        else
        {
            Play("MainMenu 2");
            nextSong = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void SongDonePlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (!s.source.isPlaying)
        {
            if (nextSong)
            {
                Play("MainMenu 1");
                nextSong = false;
            }
            else
            {
                Play("MainMenu 2");
                nextSong = true;
            }
        }
    }
}