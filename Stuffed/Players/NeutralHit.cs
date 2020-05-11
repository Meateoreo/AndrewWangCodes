using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralHit : MonoBehaviour
{
    [SerializeField] private int damage; 

    // Start is called before the first frame update
    void Start()
    {
        damage = Damages.Neutral;
    }
}
