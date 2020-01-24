using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxController : MonoBehaviour
{
    [SerializeField] private Status myStatus;
    [SerializeField] private GameObject duckBox;
    [SerializeField] private GameObject standBox;


    void Start()
    {
        standBox = GameObject.Find("MainCharacter/PlayerHitBox");
        duckBox = GameObject.Find("MainCharacter/PlayerDuckHitBox");
    }

    // Update is called once per frame
    void Update()
    {
        if (myStatus.Lives == 0)
        {
            standBox.SetActive(false);
            duckBox.SetActive(false);
        }
        else if (myStatus.Jumping || myStatus.Ducking)
        {
            standBox.SetActive(false);
            duckBox.SetActive(true);
        }
        else
        {
            standBox.SetActive(true);
            duckBox.SetActive(false);
        }

    }
}
