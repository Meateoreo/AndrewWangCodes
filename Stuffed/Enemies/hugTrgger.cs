using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hugTrgger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject self;

    [SerializeField] private Status myStatus; //script from above object;
    [SerializeField] private miniBearMovement miniBearMoveScript; //script from above object

    [SerializeField] private GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject; //find self
        player = GameObject.FindWithTag("thePlayer"); //find the player
        //myStatus = self.GetComponentInParent<Status>(); //get Status script from the player object
        //miniBearMoveScript = self.GetComponentInParent<miniBearMovement>(); //get Status script from the player object

        hitbox.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");
        
        if (miniBearMoveScript != null)
            if (collision.gameObject.tag == "thePlayer")
                StartCoroutine(Hug(0.5f, 1f, 0.5f));
                

    }
    */
    

}
