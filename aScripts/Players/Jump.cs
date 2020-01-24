using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //scripts
    [SerializeField] private GameObject self;
    [SerializeField] private Status playerStatus; //script from above object
    [SerializeField] private ControllerInputManager contInput; //script from above object
    [SerializeField] private aAttacks attackPut; //script from above object

    //statuses
    [SerializeField] private bool fighting;
    [SerializeField] private bool jumping;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool doubleOn;
    [SerializeField] private bool upJumpOn;

    //controller
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    //drop through
    [SerializeField] private bool goDown;
    

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //player specific variables
        self = GameObject.FindWithTag("thePlayer"); //find the player
        //playerStatus = self.GetComponent<Status>(); //get Status script from the player object
        //contInput = self.GetComponent<ControllerInputManager>(); //get ControllerInputManager script
        
        jumping = playerStatus.Jumping;
        doubleJump = playerStatus.DoubleJump;
        fighting = playerStatus.Fighting;
        goDown = false;


        //optional Stuffs
        doubleOn = true;
        upJumpOn = true;
    }

    // Update is called once per frame
    void Update()
    { 
        //update Statuses every frame
        jumping = playerStatus.Jumping;
        doubleJump = playerStatus.DoubleJump;
        fighting = playerStatus.Fighting;

        //update Controller Input Stuffs
        horizontal = contInput.controllerMovement.x;
        vertical = contInput.controllerMovement.y;


        #region Actual Jumping -----------------------------------------------------
        //jump if not in air Keyboard
        if (!jumping && !fighting && !playerStatus.Hit)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                rb.velocity = Vector2.up * Globals.JumpHeight;
            }
        }

        //jump if not in air Controller
        if (!jumping && !fighting && !playerStatus.Hit)
        {
            if (contInput.AButton || contInput.YButton || vertical == 1f)
            {
                rb.velocity = Vector2.up * Globals.JumpHeight;
            }
        }

        //up Jump
        if (!jumping && !fighting && !playerStatus.Hit && upJumpOn)
        {
            if (vertical >= 0.9f)
            {
                rb.velocity = Vector2.up * Globals.JumpHeight;
            }

        }
        #endregion

        //if (Input.GetJoystickNames().Length > 0)
        //    rb.velocity = Vector2.up * Globals.JumpHeight;


        #region Turn On/Off Some Stuffs
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (doubleOn)
                doubleOn = false;
            else
                doubleOn = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (upJumpOn)
                upJumpOn = false;
            else
                upJumpOn = true;
        }
        #endregion

        //Double Jump
        if (jumping && !fighting && !doubleJump && doubleOn)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) || contInput.YButton || contInput.AButton)
            {
                playerStatus.DoubleJump = true;
                rb.velocity = Vector2.up * Globals.JumpHeight;
            }

            if (upJumpOn && vertical >= 0.9f)
            {
                playerStatus.DoubleJump = true;
                rb.velocity = Vector2.up * Globals.JumpHeight;
            }
        }
        


        //if falling (y is negative) fall faster
        if (rb.velocity.y < 0 && attackPut.CurrentHitbox != GameObject.Find("DAir"))
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || vertical < -0.19)
                rb.velocity += Vector2.up * Physics2D.gravity.y * Globals.FastFallMultiplier * Time.deltaTime;
            else if (!fighting)
                rb.velocity += Vector2.up * Physics2D.gravity.y * Globals.GravityMultiplier * Time.deltaTime;
        }
        //if in process of jumping (y is positive) dont fall so fast until jump button is released
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.LeftAlt) && !contInput.YButton && !contInput.AButton)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Globals.GravityMultiplier / 2 * Time.deltaTime;
        }
   
        
        //Layer Switch to go Through Platforms
        #region Through Platforms
        /*
        //switch when jumping
        if (jumping && rb.velocity.y > 0 && !goDown)
            transform.gameObject.layer = LayerMask.NameToLayer(Globals.ThroughLayer);
        else if (!goDown)
            transform.gameObject.layer = LayerMask.NameToLayer(Globals.OnLayer);
*/
        //switch when down press
        if (vertical <= -0.75 || Input.GetKey(KeyCode.DownArrow))
            StartCoroutine(GoingDown());
        else
            transform.gameObject.layer = LayerMask.NameToLayer(Globals.OnLayer);


        #endregion


    }
    
    IEnumerator GoingDown()
    {
        transform.gameObject.layer = LayerMask.NameToLayer(Globals.ThroughLayer);
        goDown = true;
        yield return new WaitForSeconds(0.5f);
        goDown = false;
    }
    
    //onCollison Stuffs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //can now jump again after hitting something considered a floor
        if (collision.gameObject.tag == "Floor")
        {
            playerStatus.Jumping = false;
            playerStatus.DoubleJump = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //can now jump again after hitting something considered a floor
        if (collision.gameObject.tag == "Floor")
        {
            playerStatus.Jumping = false;
            playerStatus.DoubleJump = false;
        }
    }

    //onCollison EXIT Stuffs
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerStatus.Jumping = true;
        }
    }

}
