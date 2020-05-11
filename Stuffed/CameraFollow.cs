using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public GameObject player;
        private Status playerStatus; //script from above object
    
    [SerializeField] private string facing;

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private float distance;

    [SerializeField] private float speed = 0.25f;
    [SerializeField] private float offsetX = 3;

    void Start()
    {
        player = GameObject.Find("MainCharacter"); //find the player
        playerStatus = player.GetComponent<Status>(); //get Status script from the player object
        playerPosition = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetX / 2, transform.position.z);

        initialPosition = transform.position;
        facing = playerStatus.Facing;
    }


    private void Update()
    {
        if (playerStatus.Hit)
            transform.localPosition = transform.position + Random.insideUnitSphere * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        facing = playerStatus.Facing;


        if (facing == "left")
            playerPosition = new Vector3(player.transform.position.x - offsetX, player.transform.position.y + offsetX / 2, initialPosition.z); //getplayer position as a Vector3
        if (facing == "right")
            playerPosition = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetX / 2, initialPosition.z);

        //distance between player and this object
        distance = Vector3.Distance(transform.position, playerPosition); 

        //now start moving
        transform.position = Vector3.Lerp(transform.position, playerPosition, Time.deltaTime * speed * distance);

        //make sure not to move further than this point
        if (transform.position.x < -1)
        {
            transform.position = new Vector3(-1f, transform.position.y, transform.position.z);
        }
    }
    
}
