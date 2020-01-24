using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeadUIAnimations : MonoBehaviour
{
    [SerializeField] private BossAI bossStuffs;
    [SerializeField] private Status bossStatus;

    public Animator headAni;


    // Update is called once per frame
    void Update()
    {
        headAni.SetBool("Fighting", bossStatus.Fighting);
        headAni.SetBool("Laser", bossStuffs.Lasering);
        headAni.SetBool("Dizzy", bossStuffs.Dizzy);
    }
}
