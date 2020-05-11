using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMode : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private Rigidbody rb1;
    private Rigidbody rb2;

    private float waitTime = 3;
    private bool canStoneA = true;
    private bool canStoneZ = true;
	
	public Material OldMat1;
	public Material OldMat2;
	public Material StoneMaterial;
	
	

    private void Awake()
    {
        rb1 = player1.GetComponent<Rigidbody>();
        rb2 = player2.GetComponent<Rigidbody>();
		
		OldMat1 = player1.GetComponent<Renderer>().material;
		OldMat2 = player2.GetComponent<Renderer>().material;
    }
	
	private void Start()
	{
		enabled = false;
	}
    
    void Update()
    {
        if(canStoneA == true)
        {
            if (Input.GetKey(KeyCode.N))
                stoneModeA();
        }

        if (canStoneZ == true)
        {
            if (Input.GetKey(KeyCode.Keypad2))
                stoneModeZ();
        }

        if (canStoneA == false)
            StoneACD();

        if (canStoneZ == false)
            StoneZCD();
    }

    //Becoming Stone
    private void stoneModeA()
    {
        stopMovementA();
        StartCoroutine(StoneA());
    }

    private void stoneModeZ()
    {
        stopMovementZ();
        StartCoroutine(StoneZ());
    }


    //Stop Movement
    private void stopMovementA()
    {
        player1.GetComponent<MovementA>().enabled = false;
    }

    private void stopMovementZ()
    {
        player2.GetComponent<MovementZ>().enabled = false;
    }
        

    //Start and Releasing StoneMode
    IEnumerator StoneA()
    {
        yield return new WaitForSeconds(0.5f);
		player1.GetComponent<Renderer>().material = StoneMaterial;
        rb1.drag = 10;
        yield return new WaitForSeconds(2f);
		player1.GetComponent<Renderer>().material = OldMat1;
        rb1.drag = 1;
		yield return new WaitForSeconds(0.5f);
        player1.GetComponent<MovementA>().enabled = true;
    }
    IEnumerator StoneZ()
    {
        yield return new WaitForSeconds(0.5f);
		player2.GetComponent<Renderer>().material = StoneMaterial;
        rb2.drag = 10;
        yield return new WaitForSeconds(2f);
		player2.GetComponent<Renderer>().material = OldMat2;
        rb2.drag = 1;
		yield return new WaitForSeconds(0.5f);
        player2.GetComponent<MovementZ>().enabled = true;
    }

    //Cooldown
    IEnumerator StoneACD()
    {
        yield return new WaitForSeconds(waitTime);
        canStoneA = true;
    }

    IEnumerator StoneZCD()
    {
        yield return new WaitForSeconds(waitTime);
        canStoneZ = true;
    }
}
