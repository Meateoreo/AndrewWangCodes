using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneZ : MonoBehaviour
{
    public GameObject player2;

    private Rigidbody rb2;

    private float waitTime = 3;
    private bool canStoneZ = true;
	
	public Material OldMat2;
	public Material StoneMaterial;
	
	

    private void Awake()
    {
        rb2 = player2.GetComponent<Rigidbody>();
		
		OldMat2 = player2.GetComponent<Renderer>().material;
    }
	
	private void Start()
	{
		enabled = false;
	}
    
    void Update()
    {
        if (canStoneZ == true)
        {
            if (Input.GetKey(KeyCode.Keypad2))
                stoneModeZ();
        }


        if (canStoneZ == false)
            StoneZCD();
    }

    //Becoming Stone

    private void stoneModeZ()
    {
        stopMovementZ();
        StartCoroutine(StoneWaitZ());
    }


    //Stop Movement
    private void stopMovementZ()
    {
        player2.GetComponent<MovementZ>().enabled = false;
    }
        

    //Start and Releasing StoneMode
    IEnumerator StoneWaitZ()
    {
        yield return new WaitForSeconds(0.5f);
		player2.GetComponent<Renderer>().material = StoneMaterial;
        rb2.drag = 10;
        yield return new WaitForSeconds(2f);
		player2.GetComponent<Renderer>().material = OldMat2;
        rb2.drag = 1;
		yield return new WaitForSeconds(0.25f);
        player2.GetComponent<MovementZ>().enabled = true;
    }

    //Cooldown
    IEnumerator StoneZCD()
    {
        yield return new WaitForSeconds(waitTime);
        canStoneZ = true;
    }
}
