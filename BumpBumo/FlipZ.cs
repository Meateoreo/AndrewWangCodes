using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipZ : MonoBehaviour
{
    public float throwForce;
    public bool canFlip = true;
    public bool canDo = false;
	public float delay = 1;

	
    void Update()
    {
        //Flip CD
        if (canFlip == true)
        {
            if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Keypad3))
            {
                canFlip = false;
                StartCoroutine(WaitingToFlip());
            }
        }
		
		//Ready to Flip
	   	void OnTriggerStay(Collider other)
	    {
	        if (canDo == true)
	        {
	            if (canFlip == true)
	            {
	                if (other.tag == "Player1")
	                {
						print("wait");
	                    if (Input.GetKey(KeyCode.Keypad1))
	                    {
	                        other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * throwForce);
	                        other.GetComponent<CameraLock>().enabled = false;
	                        StartCoroutine(Wait());
	                    }
	                        if (Input.GetKey(KeyCode.Keypad3))
	                    { 
	                        other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * throwForce);
							print(0);
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
	    }
	
	    //Flip CD
	    IEnumerator WaitingToFlip()
	    {
	        yield return new WaitForSeconds(delay);
	        canFlip = true;
	    }
		
	 }
	
	//InArena
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arena")
		{
			canDo = true;
		}
    }

    //LeaveArena
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Arena")
            canDo = false;
    }
	
}
