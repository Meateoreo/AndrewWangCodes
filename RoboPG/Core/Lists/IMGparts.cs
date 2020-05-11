using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGparts : MonoBehaviour
{
    [SerializeField] private Sprite[] headSprites;
    [SerializeField] private Sprite[] bodySprites;
    [SerializeField] private Sprite[] legSprites;

    public Sprite[] HeadSprites { get => headSprites; }
    public Sprite[] BodySprites { get => bodySprites; }
    public Sprite[] LegSprites { get => legSprites; }

 
    public RuntimeAnimatorController[] animationControllersHead;
    public RuntimeAnimatorController[] animationControllersBody;
}
