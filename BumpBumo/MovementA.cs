using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementA : MonoBehaviour
{
    public Rigidbody sumoA;
	public float sideForce;
	public float bigForce;
	public float turnForce;
    public float throwForce;

    [SerializeField]
    private float delay = 0.5f;

    private bool canFlip = true;
    private bool canDo = false;
    public bool start = false;
	
	public Text roundNumberText;
	private int round = 1;
	
	public GameObject Manager;
	
	[SerializeField] private float freezeDelay = 2f;
	
    [SerializeField] private GameObject chargeParte;
	
    
    /*
    public float jumpForce = 5;
    private float jumpDelay = 1;
    private int delaying = 0;
	*/
	
	
	void Start()
	{
		StartCoroutine(Freeze());
		roundNumberText.text = "Round " + round.ToString();
	}
	
    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (canDo == true)
            {
                //Basic Movement
                if (Input.GetKey(KeyCode.W))
                {
                    MoveForward();
                    //direction = 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    MoveBack();
                    //direction = 2;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    MoveLeft();
                    //direction = 3;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    MoveRight();
                    //direction = 4;
                }

                /*
                if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A)))
                {
                    MoveLeftForward();
                    //direction = 4;
                }

                if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)))
                {
                    MoveRightForward();
                }

                if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A)))
                {
                    MoveLeftBack();
                    //direction = 4;
                }

                if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.D)))
                {
                    MoveRightBack();
                }

                /*   -need to fix-

                //Jumping
                if (delaying == 0)
                {
                    if(Input.GetKey(KeyCode.Space))
                    {
                        MoveUp();
                    }
                }
                */

                /*Rotating
                 if (Input.GetKey(KeyCode.B))
                {
                    RotateLeft();
                }

                if (Input.GetKey(KeyCode.M))
                {
                    RotateRight();
                }
                */

                //BigPush
                if (Input.GetKeyUp(KeyCode.N))
                {
                    GetComponent<CameraLock>().enabled = false;
                    StartCoroutine(Wait());
                }
				/*
                //Flip CD
                if (canFlip == true)
                {
                    if (Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.B))
                    {
                        canFlip = false;
                        StartCoroutine(WaitingToFlip());
                    }
                }
				*/
				if(canDo == false)
					sumoA.AddForce(0,-100000,0);
            }
        }
    }

    //Actual Movement
    private void MoveForward()
    {
        sumoA.AddRelativeForce(Vector3.forward * sideForce * Time.deltaTime);
        //sumoA.velocity = transform.TransformDirection(new Vector3(0, 0, 1)) * sideForce;
    }
	
	private void MoveLeft()
    {
        sumoA.AddRelativeForce(Vector3.left * sideForce * Time.deltaTime);
        //sumoA.velocity = transform.TransformDirection(new Vector3(-1, 0, 0)) * sideForce;
    }

    private void MoveRight()
    {
        sumoA.AddRelativeForce(Vector3.right * sideForce * Time.deltaTime);
        //sumoA.velocity = transform.TransformDirection(new Vector3(1, 0, 0)) * sideForce;
    }

    private void MoveBack()
    {
        sumoA.AddRelativeForce(-Vector3.forward * sideForce * Time.deltaTime);
        //sumoA.velocity = transform.TransformDirection(new Vector3(0, 0, -1)) * sideForce;
    }

    /*
    private void MoveRightForward()
    {
        //sumoA.AddForce(Vector3.left * sideForce * Time.deltaTime);
        sumoA.velocity = transform.TransformDirection(new Vector3(1, 0, 1)) * sideForce;
    }

    private void MoveLeftForward()
    {
        //sumoA.AddForce(Vector3.left * sideForce * Time.deltaTime);
        sumoA.velocity = transform.TransformDirection(new Vector3(-1, 0, 1)) * sideForce;
    }

    private void MoveRightBack()
    {
        //sumoA.AddForce(Vector3.left * sideForce * Time.deltaTime);
        sumoA.velocity = transform.TransformDirection(new Vector3(1, 0, -1)) * sideForce;
    }

    private void MoveLeftBack()
    {
        //sumoA.AddForce(-Vector3.forward * sideForce * Time.deltaTime);
        sumoA.velocity = transform.TransformDirection(new Vector3(-1, 0, -1)) * sideForce;
    }


    /*
          -Not Working Yet-

	//Actual Jumping
	private void MoveUp()
    {
        delaying = 1;
        sumoA.velocity = new Vector3(0,1,0) * jumpForce;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "jumpable")
        {
            StartCoroutine(Waiting());
        }
    }
    */

    /*
    //Actual Turning
    private void RotateRight()
    {
            sumoA.transform.Rotate(0,1,0, Space.Self);
    }
	
	private void RotateLeft()
    {
           sumoA.transform.Rotate(0,-1,0, Space.Self);
	}
    */

    //Actual Big Pushing
    private void BigMoveForward()
    {
        sumoA.velocity = transform.TransformDirection(new Vector3(0, 0, 1)) * bigForce;
    }
	/*
    //Ready to Flip
    private void OnTriggerStay(Collider other)
    {
        if (canDo == true)
        {
            if (canFlip == true)
            {
                if (other.tag == "Player")
                {
                    if (Input.GetKey(KeyCode.M))
                    {
                        other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * throwForce);
                        other.GetComponent<CameraLock>().enabled = false;
                        StartCoroutine(Wait());
                    }
                    if (Input.GetKey(KeyCode.B))
                    { 
                        other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * throwForce);
                        other.GetComponent<CameraLock>().enabled = false;
                        StartCoroutine(Wait());
                    }
                }
            }
        }
        //Wait 1s
        IEnumerator Wait()
        {

            yield return new WaitForSeconds(delay);
            other.GetComponent<CameraLock>().enabled = true;
        }
		
		if (other.tag == "Start")
			Manager.GetComponent<StoneA>().enabled = true;
    }

    //Flip CD
    IEnumerator WaitingToFlip()
    {
        yield return new WaitForSeconds(delay);
        print(1);
        canFlip = true;
    }
	 */
	
    //Wait for Push
    IEnumerator Wait()
    {
		GameObject particalClone = Instantiate(chargeParte, transform.position, transform.rotation);
		particalClone.transform.parent = this.gameObject.transform;
        Destroy(particalClone,1f);
        yield return new WaitForSeconds(delay);
        BigMoveForward();
        yield return new WaitForSeconds(delay);
        GetComponent<CameraLock>().enabled = true;
    }
	
	IEnumerator Freeze()
	{
		sumoA.constraints = RigidbodyConstraints.FreezePosition;
		yield return new WaitForSeconds(freezeDelay);
		roundNumberText.enabled = false;
		sumoA.constraints = ~RigidbodyConstraints.FreezePosition;
	}
	
	
    //InArena
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arena")
		{
            canDo = true;
			sumoA.drag = 1;
		}
        //Start Match
        if (other.tag == "Start")
		{
            start = true;
			Manager.GetComponent<StoneA>().enabled = true;
		}
		
    }

    //LeaveArena
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Arena")
		{
            canDo = false;
			Manager.GetComponent<StoneA>().enabled = false;
			sumoA.drag = 0;
		}
		
		if (other.tag == "Start")
		{
			Manager.GetComponent<StoneA>().enabled = false;
		}
    }



}
