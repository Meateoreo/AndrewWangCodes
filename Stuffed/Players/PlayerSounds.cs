using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] punchClips;
    [SerializeField] private AudioClip[] hitClips;
    [SerializeField] private AudioClip deadClip;

    [SerializeField] private Status playerStatus;

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (playerStatus.Hit)
                source.PlayOneShot(hitClips[Random.Range(0, hitClips.Length)]);

            if (playerStatus.Fighting)
                source.PlayOneShot(punchClips[Random.Range(0, punchClips.Length)]);

            if (playerStatus.Dead)
                source.PlayOneShot(deadClip);
        }
    }
}
