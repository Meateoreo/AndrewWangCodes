using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aAttacks : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject self;
    [SerializeField] private Status playerStatus; //script from above object
    [SerializeField] private Movement playerMovement; //script from above object
    [SerializeField] private ControllerInputManager contInput; //script from above object

    public Coroutine AttackDelay;

    //hitboxes
    [SerializeField] private GameObject NA;
    [SerializeField] private GameObject FT;
    [SerializeField] private GameObject UT;
    [SerializeField] private GameObject DT;
    [SerializeField] private GameObject NAir;
    [SerializeField] private GameObject FAir;
    [SerializeField] private GameObject BAir;
    [SerializeField] private GameObject UAir;
    [SerializeField] private GameObject DAir;

    private GameObject currentHitbox;
    public GameObject CurrentHitbox { get => currentHitbox; set => currentHitbox = value; }

    //statuses
    [SerializeField] private bool fighting;
    [SerializeField] private bool jumping;
    [SerializeField] private bool hit;
    [SerializeField] private string facing;

    //controller
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    //directions
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    //Rotation for fliping sprite
    [SerializeField] private Vector3 setRotation;
    [SerializeField] private Vector3 flipRotation;


    public Rigidbody2D rb;
    #endregion

    void Start()
    {
        //player specific variables       
        self = GameObject.FindWithTag("thePlayer"); //find the player
        //playerStatus = self.GetComponent<Status>(); //get Status script from the player object
        //contInput = self.GetComponent<ControllerInputManager>(); //get ControllerInputManager script

        //find statuses
        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;
        hit = playerStatus.Hit;


        //find and store hitboxes
        #region Hitbox GameObjects
        NA = GameObject.Find("MainCharacter/playerHitboxes/AButtons/NA"); //find the gameobject NA which is a child of AButtons which is a child of playerHitboxes
        FT = GameObject.Find("MainCharacter/playerHitboxes/AButtons/ForwardTilt");
        DT = GameObject.Find("MainCharacter/playerHitboxes/AButtons/DownTilt");
        UT = GameObject.Find("MainCharacter/playerHitboxes/AButtons/UpTilt");
        FAir = GameObject.Find("MainCharacter/playerHitboxes/AButtons/Fair");
        BAir = GameObject.Find("MainCharacter/playerHitboxes/AButtons/Bair");
        UAir = GameObject.Find("MainCharacter/playerHitboxes/AButtons/Uair");
        DAir = GameObject.Find("MainCharacter/playerHitboxes/AButtons/Dair");
        NAir = GameObject.Find("MainCharacter/playerHitboxes/AButtons/Nair");
        #endregion
        

        //set rotations to rotate to
        setRotation = Quaternion.identity.eulerAngles;
        flipRotation = new Vector3(setRotation.x, setRotation.y + 180, setRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        #region constantUpdates
        //update Statuses
        fighting = playerStatus.Fighting;
        facing = playerStatus.Facing;
        jumping = playerStatus.Jumping;

        //update Controller Input Stuffs
        horizontal = contInput.controllerMovement.x;
        vertical = contInput.controllerMovement.y;
        #endregion


        //Turn Left or Right
        #region Facing
        if (facing == "right")
            transform.rotation = Quaternion.Euler(setRotation);
        else
            transform.rotation = Quaternion.Euler(flipRotation);
        #endregion

        //UP DOWN LEFT RIGHT
        #region KeyBoard Directions
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            up = true;
        else
            up = false;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            down = true;
        else
            down = false;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            left = true;
        else
            left = false;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            right = true;
        else
            right = false;
        #endregion

        

        //attack delayer and spawns/despawns hitboxes
        IEnumerator attackDelay(float startUpTime, float time, float endLag, GameObject hitbox)
        {
            playerStatus.Fighting = true;
            yield return new WaitForSeconds(startUpTime);
            hitbox.SetActive(true);
            yield return new WaitForSeconds(time);
            hitbox.SetActive(false);
            yield return new WaitForSeconds(endLag);
            playerStatus.Fighting = false;
            currentHitbox = null;
        }
        


        //FOR KEYBOARD; Z == A 
        #region KeyBoardAttacks
        //Ground Stuffs
        #region GroundAttacks
        if (!jumping && !fighting && Input.GetKey(KeyCode.Z)) //Grounded? Not already using an attack? Pressed the attack button?
        {
            //neutral A
            if (!(up || down || left || right))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.05f, 0.1f, 0.05f, NA)); //no input till after done animation

                currentHitbox = NA;
            }

            //side Left A
            if (left && !(up || down || right))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.3f, 0.1f, FT)); //no input till after done animation

                if (facing == "right")
                    rb.velocity = Vector2.right * 5;
                else
                    rb.velocity = Vector2.left * 5;

                currentHitbox = FT;
            }

            //side Right A
            if (right && !(up || down || left))
            {
                StartCoroutine(attackDelay(0.25f, 0.3f, 0.1f, FT)); //no input till after done animation

                if (facing == "right")
                    rb.velocity = Vector2.right * 5;
                else
                    rb.velocity = Vector2.left * 5;

                currentHitbox = FT;
            }

            //down A
            if (down && !up)
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.2f, 0.6f, 0.1f, DT)); //no input till after done animation

                if (facing == "right")
                    rb.velocity = Vector2.right * 10;
                else
                    rb.velocity = Vector2.left * 10;

                currentHitbox = DT;
            }

            //up A
            if (up && !down)
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.5f, 0.2f, UT)); //no input till after done animation

                currentHitbox = UT;
            }
        }
        #endregion

        //Air Stuffs
        #region AirAttacks 
        if (jumping && !fighting && Input.GetKey(KeyCode.Z))
        {
            //air neutral A
            if (!(up || down || left || right))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.2f, 0.3f, 0.05f, NAir)); //no input till after done animation

                rb.velocity += Vector2.up;

                currentHitbox = NAir;
            }

            //air forward A right
            if ((facing == "right") && (right && !(up || down || left)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.3f, 0.5f, 0.2f, FAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = FAir;
            }

            //air back A right
            if ((facing == "right") && (left && !(up || down || right)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.4f, 0.2f, BAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = BAir;
            }

            //air forward A left
            if ((facing == "left") && (left && !(up || down || right)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.4f, 0.5f, 0.2f, FAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = FAir;
            }

            //air back A left
            if ((facing == "left") && (right && !(up || down || left)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.4f, 0.2f, BAir)); //no input till after done animation
                rb.velocity += Vector2.up / 2;

                currentHitbox = BAir;
            }

            //air down A
            if (down && !up)
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.1f, 0.3f, 0.5f, DAir)); //no input till after done animation

                if (facing == "right")
                {
                    rb.velocity = Vector2.down * 2;
                    rb.velocity += Vector2.right * 10;
                }
                else if (facing == "left")
                {
                    rb.velocity = Vector2.down * 2;
                    rb.velocity += Vector2.left * 10;
                }

                currentHitbox = DAir;
            }

            //air up A
            if (up && !down)
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.5f, 0.2f, UAir)); //no input till after done animation

                rb.velocity += Vector2.up;

                currentHitbox = UAir;
            }
        }
        #endregion
        #endregion
        

        //FOR GAMEPAD
        #region GamePadAttacks
        //Ground Stuffs
        #region GroundAttacks
        if (!jumping && !fighting && !hit && (contInput.XButton || contInput.BButton)) //Grounded? Not already using an attack? Pressed the attack button?
        {
            //neutral A
            if (Mathf.Abs(horizontal) < 0.19 && (Mathf.Abs(vertical) < 0.19))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.05f, 0.1f, 0.05f, NA)); //no input till after done animation

                currentHitbox = NA;
            }

            //side A
            if (Mathf.Abs(horizontal) > 0.19 && (Mathf.Abs(vertical) < Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.3f, 0.1f, FT)); //no input till after done animation

                if (facing == "right")
                    rb.velocity = Vector2.right * 5;
                else
                    rb.velocity = Vector2.left * 5;

                currentHitbox = FT;
            }

            //down A
            if (vertical < -0.19 && (Mathf.Abs(vertical) > Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay =   StartCoroutine(attackDelay(0.2f, 0.6f, 0.1f, DT)); //no input till after done animation

                if (facing == "right")
                    rb.velocity = Vector2.right * 10;
                else
                    rb.velocity = Vector2.left * 10;

                currentHitbox = DT;
            }

            //up A
            if (vertical > 0.19 && (Mathf.Abs(vertical) > Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.5f, 0.2f, UT)); //no input till after done animation
                
                currentHitbox = UT;
            }
        }
        #endregion

        //Air Stuffs
        #region AirAttacks 
        if (jumping && !fighting && !hit && (contInput.XButton || contInput.BButton))
        {
            //air neutral A
            if (Mathf.Abs(horizontal) < 0.19 && (Mathf.Abs(vertical) < 0.19))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.2f, 0.3f, 0.05f, NAir)); //no input till after done animation

                rb.velocity += Vector2.up;

                currentHitbox = NAir;
            }

            //air forward A right
            if ((facing == "right") && horizontal > 0.19 && (Mathf.Abs(vertical) < Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.3f, 0.5f, 0.2f, FAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = FAir;
            }

            //air back A right
            if ((facing == "right") && horizontal < -0.19 && (Mathf.Abs(vertical) < Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.4f, 0.2f, BAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = BAir;
            }

            //air forward A left
            if ((facing == "left") && horizontal < -0.19 && (Mathf.Abs(vertical) < Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.4f, 0.5f, 0.2f, FAir)); //no input till after done animation

                rb.velocity += Vector2.up / 2;

                currentHitbox = FAir;
            }

            //air back A left
            if ((facing == "left") && horizontal > 0.19 && (Mathf.Abs(vertical) < Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.4f, 0.2f, BAir)); //no input till after done animation
                rb.velocity += Vector2.up / 2;

                currentHitbox = BAir;
            }

            //air down A
            if (vertical < -0.19 && (Mathf.Abs(vertical) > Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.1f, 0.3f, 0.5f, DAir)); //no input till after done animation

                if (facing == "right")
                {
                    rb.velocity = Vector2.down * 2;
                    rb.velocity += Vector2.right * 10;
                }
                else if (facing == "left")
                {
                    rb.velocity = Vector2.down * 2;
                    rb.velocity += Vector2.left * 10;
                }

                currentHitbox = DAir;
            }

            //air up A
            if (vertical > 0.19 && (Mathf.Abs(vertical) > Mathf.Abs(horizontal)))
            {
                Coroutine AttackDelay = StartCoroutine(attackDelay(0.25f, 0.5f, 0.2f, UAir)); //no input till after done animation

                rb.velocity += Vector2.up;

                currentHitbox = UAir;
            }
        }
        #endregion
        #endregion


        #region disable Movement when doing a Down Air
        if (currentHitbox == DAir)
            playerMovement.enabled = false;
        else
            playerMovement.enabled = true;
        #endregion

        if (currentHitbox == null)
            SetAllInactive();

        //if hit deactivate everything
        if (hit)
        {
            StopAllCoroutines();
            currentHitbox.SetActive(false);
            playerStatus.Fighting = false;
            currentHitbox = null;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ground ani-cancel
        if (jumping && collision.gameObject.tag == "Floor" && currentHitbox != DAir && transform.gameObject.layer != LayerMask.NameToLayer(Globals.ThroughLayer))
        {
            StopAllCoroutines();
            StartCoroutine(aniCancel(0.1f));
        }


        //aniCancel delay
        IEnumerator aniCancel(float time)
        {
            yield return new WaitForSeconds(time);
            playerStatus.Fighting = false;

            if (currentHitbox)
                currentHitbox.SetActive(false);

            currentHitbox = null;
        }
        

    }


    private void SetAllInactive()
    {
        NA.SetActive(false);
        FT.SetActive(false);
        DT.SetActive(false);
        UT.SetActive(false);
        NAir.SetActive(false);
        BAir.SetActive(false);
        FAir.SetActive(false);
        DAir.SetActive(false);
        UAir.SetActive(false);
    }

}
