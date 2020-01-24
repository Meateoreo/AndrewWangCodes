using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raBBITMovement : MonoBehaviour
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

    public bool Moving { get => moving; }


    //never changed here
    public bool target;
    public bool Target { get => target; set => target = value; }

    //when i have target
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 walkUpTo;
    [SerializeField] private float xOffset = 0f;
    [SerializeField] private float distance;

    //hitBox for headbutt
    [SerializeField] private GameObject hitbox;

    public Rigidbody2D rb;

    void Start()
    {
        self = this.gameObject; //find self
        player = GameObject.FindWithTag("thePlayer"); //find the player
        //myStatus = self.GetComponent<Status>(); //get Status script from the player object

        moveSpeed = Globals.getMonsterMoveSpeed("light");
        target = false;

        //set Statuses
        fighting = myStatus.Fighting;
        facing = myStatus.Facing;
        jumping = myStatus.Jumping;
        hit = myStatus.Hit;

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

        if (target)
            rest = false;

        //Turn Left or Right
        if (facing == "right")
            transform.rotation = Quaternion.Euler(setRotation);
        else
            transform.rotation = Quaternion.Euler(flipRotation);

        if (hit)
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
        if (!target) //if not aiming at someone then randomly do one of the following
        {
            if (!moving && !fighting && !jumping && !hit && !rest)
            {
                switch (randomizer)
                {
                    case 1:
                        StartCoroutine(MoveLeft(1f, 0f, 1f));
                        break;
                    case 2:
                        StartCoroutine(MoveLeft(1f, 0f, 1f));
                        break;
                    case 3:
                        StartCoroutine(MoveLeft(1f, 0f, 1f));
                        break;
                    case 4:
                        StartCoroutine(MoveLeft(1f, 0f, 1f));
                        break;
                    case 5:
                        StartCoroutine(MoveLeft(1f, 0f, 1f));
                        break;
                    case 6:
                        StartCoroutine(MoveRight(0f, 0f, 2f));
                        break;
                    case 7:
                        StartCoroutine(MoveRight(0f, 0f, 2f));
                        break;
                    case 8:
                        StartCoroutine(MoveRight(0f, 0f, 2f));
                        break;
                    case 9:
                        StartCoroutine(MoveRight(0f, 0f, 2f));
                        break;
                    case 10:
                        StartCoroutine(MoveRight(0f, 0f, 2f));
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

                if (player.transform.position.x < transform.position.x)
                    StartCoroutine(MoveLeft(1f, 0f, 2f));
                if (player.transform.position.x > transform.position.x)
                    StartCoroutine(MoveRight(1f, 0f, 2f));
            }
        }

    }
    //move LEFT after a delay
    IEnumerator MoveLeft(float startUpTime, float time, float endLag)
    {
        moving = true;
        yield return new WaitForSeconds(startUpTime); //delay before moving
        moveLeft();
        hitbox.SetActive(true);
        yield return new WaitForSeconds(endLag);
        moving = false;
        hitbox.SetActive(false);
        randomizer = Random.Range(0, 10);
    }

    //move RIGHT after a delay
    IEnumerator MoveRight(float startUpTime, float time, float endLag)
    {
        moving = true;
        yield return new WaitForSeconds(startUpTime);
        moveRight();
        hitbox.SetActive(true);
        yield return new WaitForSeconds(endLag);
        moving = false;
        hitbox.SetActive(false);
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

        rb.velocity = new Vector2(-1f, 0.9f) * Globals.MaxSpeed * 1.1f;
        rb.velocity += (Vector2.left * Globals.MoveSpeed);
    }

    private void moveRight()
    {
        myStatus.Facing = "right";

        rb.velocity = new Vector2(1f, 0.9f) * Globals.MaxSpeed * 1.1f;
        rb.velocity += (Vector2.right * Globals.MoveSpeed);
    }
    
}
