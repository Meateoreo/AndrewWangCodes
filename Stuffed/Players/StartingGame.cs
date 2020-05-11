using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingGame : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] Status playerStatus;
    [SerializeField] Jump playerJump;
    [SerializeField] Movement playerMovement;
    [SerializeField] aAttacks attacks;
    [SerializeField] private int stuck;
    [SerializeField] private ControllerInputManager contInput;

    public int Stuck { get => stuck; set => stuck = value; }

    // Start is called before the first frame update
    void Start()
    {
        stuck = 10;
        playerMovement.enabled = false;
        playerJump.enabled = false;
        attacks.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stuck > 0 && (contInput.AButton || contInput.YButton))
            StartCoroutine(UnStuck());

        if(stuck > 0)
        {
            playerMovement.enabled = false;
            playerJump.enabled = false;
            attacks.enabled = false;
        }

        if (stuck == 0)
        {
            StopAllCoroutines();
            thePlayer.GetComponent<SpriteRenderer>().enabled = true;
            playerMovement.enabled = true;
            playerJump.enabled = true;
            attacks.enabled = true;
            thePlayer.transform.SetParent(null);
        }
        
        if (playerStatus.Dead)
        {
            playerMovement.enabled = false;
            playerJump.enabled = false;
            attacks.enabled = false;
            contInput.enabled = false;
        }
    }

    //move LEFT after a delay
    IEnumerator UnStuck()
    {
        stuck--;
        transform.position += Vector3.up * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.down * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.left * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.right * 0.1f;
    }

}
