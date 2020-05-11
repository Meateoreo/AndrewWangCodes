using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showGlobals : MonoBehaviour
{
    //from Globals
    public bool paused;
    public float moveSpeed;
    public float jumpHeight;
    public float gravityMultiplier;
    public float fastFallMultiplier;

    //reference Others
    public GameObject playerStuffs; //player object
        public Status playerStatus; //script from above object

    //from Others
    public string facing;
    public bool jumping;
    public bool doubleJumped;
    public bool fighting;

    void Start()
    {
        //global variables
        paused = Globals.Pause;
        moveSpeed = Globals.MoveSpeed;
        jumpHeight = Globals.JumpHeight;
        gravityMultiplier = Globals.GravityMultiplier;
        fastFallMultiplier = Globals.FastFallMultiplier;


        //player specific variables
        playerStuffs = GameObject.FindWithTag("thePlayer"); //find the player
        playerStatus = playerStuffs.GetComponent<Status>(); //get Status script from the player object

        //other Variables
        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;
        doubleJumped = playerStatus.DoubleJump;
    }
    

    void Update()
    {
        //global variables
        paused = Globals.Pause;
        moveSpeed = Globals.MoveSpeed;
        jumpHeight = Globals.JumpHeight;
        gravityMultiplier = Globals.GravityMultiplier;
        fastFallMultiplier = Globals.FastFallMultiplier;


        //Others
        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;
        doubleJumped = playerStatus.DoubleJump;


    }
}
