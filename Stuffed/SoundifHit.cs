using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundifHit : MonoBehaviour
{
    [SerializeField] private Status myStatus;

    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource source;
    
    [SerializeField] private GameObject[] stuffing;
    [SerializeField] private int randomizer;

    // Start is called before the first frame update
    void Start()
    {
        randomizer = Random.Range(0, 4);

    }

    // Update is called once per frame
    void Update()
    {
        randomizer = Random.Range(0, 4);

        if (myStatus.Hit && !source.isPlaying)
        {
            source.PlayOneShot(sounds[Random.Range(0,4)]);

            switch (randomizer)
            {
                case 0:
                    Instantiate(stuffing[randomizer], transform.position, stuffing[randomizer].transform.rotation);
                    break;
                case 1:
                    Instantiate(stuffing[randomizer], transform.position, stuffing[randomizer].transform.rotation);
                    break;
                case 2:
                    Instantiate(stuffing[randomizer], transform.position, stuffing[randomizer].transform.rotation);
                    break;
                case 3:
                    Instantiate(stuffing[randomizer], transform.position, stuffing[randomizer].transform.rotation);
                    break;
            }
        }
    }
}
