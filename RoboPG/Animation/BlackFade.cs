using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    private GameObject Manager;

    public AudioSource aSource;

    public Animation doorAnimation;
    private float timer;
    private float startTime;
    private float animationTime;

    private void Start()
    {
        Manager = GameObject.Find("Manager");
        startTime = Time.time;
        animationTime = doorAnimation.clip.length / 2;

        aSource = Manager.GetComponent<SoundList>().sfxSource;
        aSource.PlayOneShot(Manager.GetComponent<SoundList>().sfxClips[3]);

        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, timer / animationTime * 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time - startTime;

        //print(timer);

        if (timer < animationTime)
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, timer/animationTime*2);
        else
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, (animationTime - Mathf.Abs(animationTime - timer))/animationTime*2);

    }
}
