using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeted : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject self;
    [SerializeField] private miniBearMovement miniBearMoveScript; //script from above object
    [SerializeField] private raBBITMovement raBBITMovementScript; //script from above object

    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject; //find self
        player = GameObject.FindWithTag("thePlayer"); //find the player
        //miniBearMoveScript = self.GetComponentInParent<miniBearMovement>(); //get Status script from the player object

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (miniBearMoveScript != null)
            if (collision.gameObject.tag == "thePlayer")
                miniBearMoveScript.Target = true;

        if (raBBITMovementScript != null)
            if (collision.gameObject.tag == "thePlayer")
                raBBITMovementScript.Target = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (miniBearMoveScript != null)
            if (collision.gameObject.tag == "thePlayer")
                miniBearMoveScript.Target = true;

        if (raBBITMovementScript != null)
            if (collision.gameObject.tag == "thePlayer")
                raBBITMovementScript.Target = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (miniBearMoveScript != null)
            if (other.gameObject.tag == "thePlayer")
                miniBearMoveScript.Target = false;

        if (raBBITMovementScript != null)
            if (other.gameObject.tag == "thePlayer")
                raBBITMovementScript.Target = false;
    }

}
    
