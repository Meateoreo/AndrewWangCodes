using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    [SerializeField] public GameObject player;

    [SerializeField] private Vector3 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter"); //find the player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = playerPosition;
    }
}
