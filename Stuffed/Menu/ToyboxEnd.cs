using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyboxEnd : MonoBehaviour
{
    [SerializeField] private Status bossStatus;
    [SerializeField] private Status playerStatus;
    
    [SerializeField] private Jump playerJump;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private aAttacks attacks;

    [SerializeField] private GameObject playerHitbox;

    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject winStuffs;

    [SerializeField] private GameObject player;
    [SerializeField] private Sprite UTsprite;

    public Animator playerAni;

    private void Update()
    {
        if (bossStatus.HP <= 0)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(player.GetComponent<Rigidbody2D>());
            playerMovement.enabled = false;
            playerJump.enabled = false;
            attacks.enabled = false;
            playerAni.enabled = false;

            winCanvas.SetActive(true);
            winText.SetActive(true);
            winStuffs.SetActive(true);
            playerHitbox.SetActive(false);
        }

        if (playerStatus.Lives <= 0)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(player.GetComponent<Rigidbody2D>());
            playerMovement.enabled = false;
            playerJump.enabled = false;
            attacks.enabled = false;
            playerAni.enabled = false;
            
        }
    }

}
