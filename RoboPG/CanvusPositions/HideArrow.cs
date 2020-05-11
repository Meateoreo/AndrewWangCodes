using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

public class HideArrow : MonoBehaviour
{
    [SerializeField] private GameObject Manager;

    public float offsetY;
    public float offsetY2;
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");

        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetComponent<GameState>().pState != PlayState.BATTLE)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            transform.position = oldPosition;

        }
        else
            GetComponent<SpriteRenderer>().enabled = true;


        if (Manager.GetComponent<turnManager>().takingTurn.Count > 0)
        {
            if (Manager.GetComponent<turnManager>().takingTurn[0].GetComponent<Stats>().Side == "Enemy")
                transform.position = new Vector3(Manager.GetComponent<turnManager>().takingTurn[0].transform.position.x + 0.2f, Manager.GetComponent<turnManager>().takingTurn[0].transform.position.y + offsetY);
            else if (Manager.GetComponent<turnManager>().takingTurn[0].GetComponent<Stats>().Side == "Friend")
                transform.position = new Vector3(Manager.GetComponent<turnManager>().takingTurn[0].transform.position.x - 0.25f, Manager.GetComponent<turnManager>().takingTurn[0].transform.position.y + offsetY2);
        }
        else
            transform.position = oldPosition;


    }
}
