using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBearMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject self;
    [SerializeField] private Status myStatus; //script from above object

    //value for randomization
    public int randomizer;
    
    //from Status
    [SerializeField] private bool fighting;
    [SerializeField] private bool jumping;
    [SerializeField] private bool hit;
    [SerializeField] private string facing;

    //unique to this enemy
    [SerializeField] private bool moving;
    [SerializeField] private bool rest;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 setRotation;
    [SerializeField] private Vector3 flipRotation;

    //never changed here
    [SerializeField] private bool target;
    public bool Target { get => target; set => target = value; }
    public bool Resting { get => rest; }

    //when i have target
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 walkUpTo;
    [SerializeField] private float xOffset = 1f;
    [SerializeField] private float distance;

    //hug Hitbox
    [SerializeField] private GameObject hitbox;

    public Rigidbody2D rb;

    void Start()
    {
        self = this.gameObject; //find self
        player = GameObject.FindWithTag("thePlayer"); //find the player
        //myStatus = self.GetComponent<Status>(); //get Status script from the player object

        moveSpeed = Globals.getMonsterMoveSpeed("medium");
        target = false;

        //set Statuses
        fighting = myStatus.Fighting;
        facing = myStatus.Facing;
        jumping = myStatus.Jumping;

        //initializing unique variables
        moving = false;
        rest = true;
        target = false;
        setRotation = Quaternion.identity.eulerAngles;
        flipRotation = new Vector3(setRotation.x, setRotation.y + 180, setRotation.z);
        

        //make randomizer a random int for the switch statement
        randomizer = Random.Range(0, 10);
    }

    private void Update()
    {
        //update Statuses
        fighting = myStatus.Fighting;
        facing = myStatus.Facing;
        jumping = myStatus.Jumping;
        hit = myStatus.Hit;
        
        //Turn Left or Right
        if (facing == "right")
            transform.rotation = Quaternion.Euler(setRotation);
        else
            transform.rotation = Quaternion.Euler(flipRotation);

        float distance;
        distance = player.transform.position.x - transform.position.x;

        if (distance > 0 && distance < 1.2f && !moving && !fighting && !jumping && !hit && !rest)
        {
            myStatus.Facing = "right";
            StartCoroutine(HugRight(0.5f, 1f, 1f));
        }
        if (distance < 0 && distance > -1.2f && !moving && !fighting && !jumping && !hit && !rest)
        {
            myStatus.Facing = "left";
            StartCoroutine(HugLeft(0.5f, 1f, 1f));
        }

        if (hit || myStatus.Dead)
        {
            StopAllCoroutines();
            hitbox.SetActive(false);
            myStatus.Fighting = false;
            moving = false;
            rest = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (hit)
        {
            StopAllCoroutines();
            hitbox.SetActive(false);
            myStatus.Fighting = false;
            moving = false;
            rest = false;
        }

        if (!target) //if not aiming at someone then randomly do one of the following
        {
            if (!moving && !fighting && !jumping && !hit && !rest)
            {
                switch (randomizer)
                {
                    case 1:
                        StartCoroutine(MoveLeft(1f, 0f, 2f));
                        break;
                    case 2:
                        StartCoroutine(MoveLeft(1f, 0f, 2f));
                        break;
                    case 3:
                        StartCoroutine(MoveRight(1f, 0f, 2f));
                        break;
                    case 4:
                        StartCoroutine(MoveRight(1f, 0f, 2f));
                        break;
                    default:
                        rest = true;
                        break;
                }
            }
        }
        else
        {
            rest = false; //stop sitting

            if (!moving && !fighting && !jumping && !hit && !rest)
            {
                //targetPosition = new Vector3(target.x, target.y, target.z);  //target position

                if (player.transform.position.x + xOffset < transform.position.x)
                    moveLeft();
                else if (player.transform.position.x - xOffset > transform.position.x)
                    moveRight();
            }
        }

    }

    //move LEFT after a delay
    IEnumerator MoveLeft(float startUpTime, float time, float endLag)
    {
        moving = true;
        yield return new WaitForSeconds(startUpTime); //delay before moving
        moveLeft();
        yield return new WaitForSeconds(endLag);
        moving = false;
        randomizer = Random.Range(0, 10);
    }

    //move RIGHT after a delay
    IEnumerator MoveRight(float startUpTime, float time, float endLag)
    {
        moving = true;
        yield return new WaitForSeconds(startUpTime);
        moveRight();
        yield return new WaitForSeconds(endLag);
        moving = false;
        randomizer = Random.Range(0, 10);
    }
    
    //sit then delay
    IEnumerator Sit(float startUpTime, float time, float endLag)
    {
        rest = true;
        yield return new WaitForSeconds(startUpTime);
        yield return new WaitForSeconds(endLag);
        rest = false;
        randomizer = Random.Range(0, 10);
    }

    private void moveLeft()
    {
        myStatus.Facing = "left";

        if (!target)
            rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);

        rb.velocity += (Vector2.left * Globals.MoveSpeed);
        
        if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
            rb.velocity = new Vector2(-Globals.MaxSpeed, rb.velocity.y);
           
    }

    private void moveLeft(int zero)
    {
        myStatus.Facing = "left";
        
        rb.velocity += (Vector2.left * Globals.MaxSpeed) * 1.5f;
    }

    private void moveRight()
    {
        myStatus.Facing = "right";

        if (!target)
            rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
        
        rb.velocity += (Vector2.right * Globals.MoveSpeed);

        if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed)
            rb.velocity = new Vector2(Globals.MaxSpeed, rb.velocity.y);
    }

    private void moveRight(int zero)
    {
        myStatus.Facing = "right";

        rb.velocity += (Vector2.right * Globals.MaxSpeed) * 1.5f;
    }

    IEnumerator HugLeft(float startUpTime, float time, float endLag)
    {
        myStatus.Fighting = true;
        yield return new WaitForSeconds(startUpTime);
        hitbox.SetActive(true);
        moveLeft(0);
        yield return new WaitForSeconds(endLag);
        myStatus.Fighting = false;
        hitbox.SetActive(false);
    }

    IEnumerator HugRight(float startUpTime, float time, float endLag)
    {
        myStatus.Fighting = true;
        yield return new WaitForSeconds(startUpTime);
        hitbox.SetActive(true);
        moveRight(0);
        yield return new WaitForSeconds(endLag);
        myStatus.Fighting = false;
        hitbox.SetActive(false);
    }
}
