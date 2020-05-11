using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] Status playerStatus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "thePlayer")
        {
            playerStatus.Dead = true;
        }
        else
            Destroy(collision.gameObject);
    }
}
