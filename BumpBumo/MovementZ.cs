using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZ : MonoBehaviour
{
    public Rigidbody sumoZ;
    public float sideForce;
    public float bigForce;
    public float turnForce;

    [SerializeField]
    private float delay = 0.5f;
	
    private bool canDo = false;
    public bool start = false;
	
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
	}
	
    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (canDo == true)
            {

                //Basic Movement
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    MoveForward();
                    //direction = 1;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    MoveBack();
                    //direction = 2;
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    MoveLeft();
                    //direction = 3;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    MoveRight();
                    //direction = 4;
                }

                //BigPush
                if (Input.GetKeyUp(KeyCode.Keypad1))
                {
                    GetComponent<CameraLock>().enabled = false;
                    StartCoroutine(Wait());
                }
				
				if(canDo == false)
					sumoZ.AddForce(0,-10000,0);
            }
        }
    }
	
	//Actual Movement
	private void MoveForward()
    {
        sumoZ.AddRelativeForce(Vector3.forward * sideForce * Time.deltaTime);
        //sumoZ.velocity = transform.TransformDirection(new Vector3(0, 0, 1)) * sideForce;
    }
	
	private void MoveLeft()
    {
        sumoZ.AddRelativeForce(Vector3.left * sideForce * Time.deltaTime);
        //sumoZ.velocity = transform.TransformDirection(new Vector3(-1, 0, 0)) * sideForce;
    }
	
	private void MoveRight()
    {
        sumoZ.AddRelativeForce(Vector3.right * sideForce * Time.deltaTime);
        //sumoZ.velocity = transform.TransformDirection(new Vector3(1, 0, 0)) * sideForce;
    }
	
	private void MoveBack()
    {
        sumoZ.AddRelativeForce(-Vector3.forward * sideForce * Time.deltaTime);
        //sumoZ.velocity = transform.TransformDirection(new Vector3(0, 0, -1)) * sideForce;
    }
	
    //Actual Big Pushing
    private void BigMoveForward()
    {
           sumoZ.velocity = transform.TransformDirection(new Vector3(0,0,1)) * bigForce;
    }
	
    /*
	private void AddForward()
	{
		sumoZ.AddRelativeForce(Vector3.forward * 10000 * Time.deltaTime);
		print(1);
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
		sumoZ.constraints = RigidbodyConstraints.FreezePosition;
		yield return new WaitForSeconds(freezeDelay);
		sumoZ.constraints = ~RigidbodyConstraints.FreezePosition;
	}

    //InArena
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arena")
		{
			canDo = true;
			sumoZ.drag = 1;
		}

        //Start Match
        if (other.tag == "Start")
		{
            start = true;
			Manager.GetComponent<StoneZ>().enabled = true;
		}
    }

    //LeaveArena
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Arena")
		{
            canDo = false;
			Manager.GetComponent<StoneZ>().enabled = false;
			sumoZ.drag = 0;
		}
		
		if (other.tag == "Start")
		{
			Manager.GetComponent<StoneZ>().enabled = false;
		}
    }

}
