using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource source;

    public bool off;

    private void Start()
    {
        off = false;
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "thePlayer" && !off)
        {
            off = true;

            StopAllAudio();

            if (!source.isPlaying)
                source.Play();
        }
    }


    void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}
