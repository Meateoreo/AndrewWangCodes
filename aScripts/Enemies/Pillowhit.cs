using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillowhit : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource source;

    [SerializeField] private GameObject[] feathers;
    [SerializeField] private int randomizer;

    private void Start()
    {
        randomizer = Random.Range(0, 4);
    }

    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        randomizer = Random.Range(0, 4);

        if (hitbox.tag == "Hitbox")
        {
            StartCoroutine(UnStuck());
            if (!source.isPlaying)
            {
                Debug.Log("squeak");
                source.PlayOneShot(sound);
            }

            switch (randomizer)
            {
                case 0:
                    Instantiate(feathers[randomizer], transform.position, feathers[randomizer].transform.rotation);
                    break;
                case 1:
                    Instantiate(feathers[randomizer], transform.position, feathers[randomizer].transform.rotation);
                    break;
                case 2:
                    Instantiate(feathers[randomizer], transform.position, feathers[randomizer].transform.rotation);
                    break;
                case 3:
                    Instantiate(feathers[randomizer], transform.position, feathers[randomizer].transform.rotation);
                    break;
            }
        }
    }

    //move LEFT after a delay
    IEnumerator UnStuck()
    {
        transform.position += Vector3.up * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.down * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.left * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.right * 0.1f;
    }
}
