using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickup : MonoBehaviour
{
    [SerializeField] int heal;
    [SerializeField] bool used;

    private void Start()
    {
        used = false;
        heal = Random.Range(5, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "thePlayer")
        {
            if (!used)
            {
                used = true;
                collision.gameObject.GetComponent<Status>().HP += heal;

                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "thePlayer")
        {
            if (!used)
            {
                used = true;
                collision.gameObject.GetComponent<Status>().HP += heal;

                Destroy(this.gameObject);
            }
        }
    }
}
