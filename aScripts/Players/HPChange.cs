using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPChange : MonoBehaviour
{
    [SerializeField] private Status status;

    // Update is called once per frame
    void Update()
    {
        float hp = status.HP;

        if(this.gameObject.tag == "Boss")
            transform.localScale = new Vector3(hp / 300, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(hp/100, transform.localScale.y, transform.localScale.z);
    }
}
