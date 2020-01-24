using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpDetection : MonoBehaviour
{
    [SerializeField] private Status myStatus;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private raBBITMovement movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //onCollison Stuffs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //can now jump again after hitting something considered a floor
        if (collision.gameObject.tag == "Floor")
        {
            myStatus.Jumping = false;
            myStatus.DoubleJump = false;
        }
    }

    //onCollison EXIT Stuffs
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            myStatus.Jumping = true;
        }
    }
}
