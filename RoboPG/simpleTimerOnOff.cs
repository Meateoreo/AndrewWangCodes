using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simpleTimerOnOff : MonoBehaviour
{
    private float time;
    private Image thisSprite;
     

    private void Start()
    {
        time = 0;
        thisSprite = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float timeFactor = time % 2;


        if (timeFactor < 0.5f)
            thisSprite.enabled = false;
        else
            thisSprite.enabled = true;

    }
}
