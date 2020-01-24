using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Color alpha;

    private void Start()
    {
        alpha = this.gameObject.GetComponent<SpriteRenderer>().color;
        alpha.a = 0.9f;
    }

    private void FixedUpdate()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = alpha;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
            alpha.a = 0.5f;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject == player.gameObject)
            alpha.a = 0.5f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == player.gameObject)
            alpha.a = 0.9f;
    }

}
