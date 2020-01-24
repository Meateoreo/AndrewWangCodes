using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject self;
    [SerializeField] private Status playerStatus; //script from above object
    [SerializeField] private ControllerInputManager contInput; //script from above object

    [SerializeField] private bool fighting;
    [SerializeField] private bool jumping;
    [SerializeField] private string facing;

    
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    

    public Rigidbody2D rb;
    

    private void Start()
    {
        self = GameObject.FindWithTag("thePlayer"); //find the player

        /*
        //player specific variables               
        playerStatus = self.GetComponent<Status>(); //get Status script from the player object
        contInput = self.GetComponent<ControllerInputManager>(); //get ControllerInputManager script
        */

        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;
    }

    // Update is called once per frame
    void Update()
    {
        //update Controller Input Stuffs
        horizontal = contInput.controllerMovement.x;
        vertical = contInput.controllerMovement.y;


        //update Statuses
        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;

        
        if (vertical < -0.5f && Mathf.Abs(horizontal) < Mathf.Abs(vertical))
            playerStatus.Ducking = true;
        else
            playerStatus.Ducking = false;

        #region GroundMovement
        //ground movement Keyboard
        if (!fighting && !jumping && !playerStatus.Ducking && !playerStatus.Hit)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.velocity += (Vector2.left * Globals.MaxSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);
            }


            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.velocity += (Vector2.right * Globals.MaxSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
            }
        }
        //ground movement Controller
        if (!fighting && !jumping && !playerStatus.Ducking && !playerStatus.Hit)
        {
            if (horizontal < -0.19)
            {
                rb.velocity += (Vector2.left * Mathf.Abs(horizontal));

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);
            }

            if (horizontal > 0.19)
            {
                rb.velocity += (Vector2.right * Mathf.Abs(horizontal));

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
            }
        }
        #endregion

        #region AirMovement
        //air movement Keyboard
        if (jumping) //while not fighting
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.velocity += (Vector2.left * Globals.MoveSpeed * 2);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.velocity += (Vector2.right * Globals.MoveSpeed * 2);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
            }
        }
        //air movement Controller
        if (jumping) //while not fighting
        {
            if (horizontal < -0.19)
            {
                rb.velocity += (Vector2.left * Globals.MoveSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);
            }

            if (horizontal > 0.19)
            {
                rb.velocity += (Vector2.right * Globals.MoveSpeed);
                
                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
                    rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
            }
        }
        #endregion

        //minimize sliding on ground
        if (!jumping || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Mathf.Abs(horizontal) < 0.19f)
        {
            if (Mathf.Abs(rb.velocity.x) > 0)
            {
                if (rb.velocity.x > 0)
                    rb.velocity += Vector2.left * Time.deltaTime * 10;
                if (rb.velocity.x < 0)
                    rb.velocity += Vector2.right * Time.deltaTime * 10;
            }
        }
        
        #region Facing
        //update facing direction if not in air
        if (!jumping && !fighting && !playerStatus.Hit && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerStatus.Facing = "left";
        }

        if (!jumping && !fighting && !playerStatus.Hit && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerStatus.Facing = "right";
        }
        

        //update facing direction if not in air
        //FOR CONTROLLER: I DONT KNOW Y IT DOESNT WORK JUST ADDING HORIZONTAL VALUE TO THE ABOVE CODE
        if (!jumping && !fighting && horizontal < -0.19)
        {
            playerStatus.Facing = "left";
        }

        if (!jumping && !fighting && horizontal > 0.19)
        {
            playerStatus.Facing = "right";
        }
        #endregion

    }

    //onCollison EXIT Stuffs
    private void OnCollisionExit2D(Collision2D collision)
    {
    }
}
