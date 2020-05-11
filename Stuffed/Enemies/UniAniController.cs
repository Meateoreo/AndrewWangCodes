using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniAniController : MonoBehaviour
{
    [SerializeField] private Status myStatus;
    [SerializeField] private UniAI uniAI;

    public Animator ani;

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("Fighting", myStatus.Fighting);
        ani.SetBool("Hit", myStatus.Hit);
        ani.SetBool("Dead", myStatus.Dead);
    }
}
