using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Status myStatus; //script from above object

    [SerializeField] private GameObject horn;

    //value for randomization
    public int randomizer;
    public int timer;
    public int attTimer;

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
    [SerializeField] private Vector3 targetDirection;
    [SerializeField] private float distance;

    Vector3 randomFT;

    //hug Hitbox
    [SerializeField] private GameObject hitbox;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("thePlayer"); //find the player
        //myStatus = self.GetComponent<Status>(); //get Status script from the player object

        moveSpeed = Globals.getMonsterMoveSpeed("medium");
        
        setRotation = Quaternion.identity.eulerAngles;
        flipRotation = new Vector3(setRotation.x, setRotation.y + 180, setRotation.z);

        targetPosition = player.transform.position;
        targetDirection = targetPosition - transform.position;

        timer = 60;
        attTimer = Random.Range(100, 300);
        randomizer = Random.Range(1, 5);
    }

    private void FixedUpdate()
    {
        #region Timers
        if (timer > 0)
            timer--;
        if (attTimer > 0)
            attTimer--;

        if (timer == 0)
        {
            timer = 60;
            targetPosition = player.transform.position;
        }
        if (timer == 0 || timer == 30)
            targetDirection = targetPosition - transform.position;

        if (attTimer == 0)
        {
            attTimer = Random.Range(100, 300);
            StartCoroutine(attacking());
        }
        #endregion
        

        #region Movement
        if (timer % 5 == 0 && !myStatus.Fighting)
        {
            if (transform.position.x > targetPosition.x + 5)
            {
                rb.velocity += (Vector2.left * Globals.MoveSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed - 5)
                    rb.velocity = new Vector2(-Globals.MaxSpeed + 5, rb.velocity.y);
            }

            if (transform.position.x < targetPosition.x - 5)
            {
                rb.velocity += (Vector2.right * Globals.MoveSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed - 5)
                    rb.velocity = new Vector2(Globals.MaxSpeed - 5, rb.velocity.y);
            }

            if (transform.position.y < targetPosition.y + 3)
            {
                rb.velocity += (Vector2.up * Globals.MoveSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed - 5)
                    rb.velocity = new Vector2(-Globals.MaxSpeed + 5, rb.velocity.y);
            }

            if (transform.position.y > targetPosition.y + 3)
            {
                rb.velocity += (Vector2.down * Globals.MoveSpeed);

                if (Mathf.Abs(rb.velocity.x) > Globals.MaxSpeed - 5)
                    rb.velocity = new Vector2(Globals.MaxSpeed - 5, rb.velocity.y);
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > targetPosition.x)
            transform.rotation = Quaternion.Euler(setRotation);
        else
            transform.rotation = Quaternion.Euler(flipRotation);

        if (myStatus.Hit)
            resetTimers();
    }

    private void resetTimers()
    {
        timer = 60;
        attTimer = Random.Range(100, 300);

    }

    IEnumerator attacking()
    {
        myStatus.Fighting = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(horn, transform.position, horn.transform.rotation);
        myStatus.Fighting = false;

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        randomizer = Random.Range(1, 5);

    }
}
