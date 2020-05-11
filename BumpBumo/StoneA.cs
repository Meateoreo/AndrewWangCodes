using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneA : MonoBehaviour
{
    public GameObject player1;

    private Rigidbody rb1;

    private float waitTime = 3;
    private bool canStoneA = true;
	
	public Material OldMat1;
	public Material StoneMaterial;
	
	

    private void Awake()
    {
        rb1 = player1.GetComponent<Rigidbody>();
		
		OldMat1 = player1.GetComponent<Renderer>().material;
    }
	
	private void Start()
	{
		enabled = false;
	}
    
    void Update()
    {
        if(canStoneA == true)
        {
            if (Input.GetKey(KeyCode.M))
                stoneModeA();
        }


        if (canStoneA == false)
            StoneACD();

    }

    //Becoming Stone
    private void stoneModeA()
    {
        stopMovementA();
        StartCoroutine(StoneWaitA());
    }


    //Stop Movement
    private void stopMovementA()
    {
        player1.GetComponent<MovementA>().enabled = false;
    }
        

    //Start and Releasing StoneMode
    IEnumerator StoneWaitA()
    {
        yield return new WaitForSeconds(0.5f);
		player1.GetComponent<Renderer>().material = StoneMaterial;
        rb1.drag = 10;
        yield return new WaitForSeconds(2f);
		player1.GetComponent<Renderer>().material = OldMat1;
        rb1.drag = 1;
		yield return new WaitForSeconds(0.25f);
        player1.GetComponent<MovementA>().enabled = true;
    }

    //Cooldown
    IEnumerator StoneACD()
    {
        yield return new WaitForSeconds(waitTime);
        canStoneA = true;
    }
}
