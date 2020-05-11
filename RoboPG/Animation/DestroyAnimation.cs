using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
   private float offset = 0.05f;

    public bool parent = false;

    void Start()
    {
        //print(gameObject.GetComponent<Animation>().clip.length);

        if (!parent)
            Destroy(gameObject, gameObject.GetComponent<Animation>().clip.length - offset);
        else
            Destroy(transform.parent.gameObject, gameObject.GetComponent<Animation>().clip.length + offset);

    }
}
