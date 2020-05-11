using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;
    
    private AudioClip curMusicClip;
    private AudioClip curSFXClip;


    public void SwitchMusic(int index)
    {
        if (curMusicClip != musicClips[index])
        {
            if (index == 0 || index == 1)
                musicSource.volume = 0.25f;
            else
                musicSource.volume = 1f;

            musicSource.Stop();
            musicSource.clip = musicClips[index];
            musicSource.Play();
            curMusicClip = musicClips[index];
        }
    }

    public void SwitchSound(int index)
    {
        if (curSFXClip != sfxClips[index])
        {
            if (index == 1 || index == 2)
                sfxSource.volume = 0.25f;
            else
                sfxSource.volume = 1f;

            sfxSource.Stop();
            sfxSource.clip = sfxClips[index];
            sfxSource.Play();
        }
    }
}
