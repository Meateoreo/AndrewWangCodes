using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnClick : MonoBehaviour
{
    private AudioClip clickPlay;
    private AudioSource source;

    private GameObject Manager;

    private void Start()
    {
        Manager = GameObject.Find("Manager");
        source = Manager.GetComponent<SoundList>().sfxSource;
    }

    public void PlayOnClick(int clipIndex)
    {
        //print("playing");
        source.Stop();
        source.clip = Manager.GetComponent<SoundList>().sfxClips[clipIndex];
        source.Play();
    }
}
