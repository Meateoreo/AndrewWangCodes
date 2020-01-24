using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTiltHit : MonoBehaviour
{
    [SerializeField] private int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = Damages.DownTilt;
    }
}
