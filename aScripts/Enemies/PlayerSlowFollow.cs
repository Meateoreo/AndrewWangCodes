using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlowFollow : MonoBehaviour
{
    [SerializeField] public GameObject player;

    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private float speed = 0.005f;
    [SerializeField] private float time = 60f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter"); //find the player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (time == 0)
        {
            time = 60f;
            playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        --time;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > playerPosition.x)
            transform.position += Vector3.left * speed;

        if (transform.position.x < playerPosition.x)
            transform.position += Vector3.right * speed;
    }
}
