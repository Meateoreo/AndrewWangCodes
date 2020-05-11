using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageAniController : MonoBehaviour
{
    private Animator thisAnimator;

    private void Start()
    {
        thisAnimator = gameObject.GetComponent<Animator>();
    }


    public void OnClicked()
    {
        GetComponent<Animation>().Play();
    }
}
