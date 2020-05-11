using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

public class TargetButton : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private GameObject[] fighter;

    private GameObject Manager;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //print(Manager.GetComponent<AttackList>().Side[(Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack))]);

        //Friendly Target
        if (Manager.GetComponent<turnManager>().bState == BattleState.TARGET &&
            Manager.GetComponent<AttackList>().Side[(Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack))] == "Friend")
        {
            //print("ally");
            if (fighter[0].GetComponent<Stats>().Alive)
            {
                targets[0].SetActive(true);

            }
            else
                targets[0].SetActive(false);

            if (fighter[1].GetComponent<Stats>().Alive)
            {
                targets[1].SetActive(true);

            }
            else
                targets[1].SetActive(false);

            if (fighter[2].GetComponent<Stats>().Alive)
            {
                targets[2].SetActive(true);

            }
            else
                targets[2].SetActive(false);

            /*
            Vector3 tagPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            target.transform.position = tagPosition;
            */
        }
        else
        {
            targets[0].SetActive(false);
            targets[1].SetActive(false);
            targets[2].SetActive(false);
        }

        //Enemy Target
        if (Manager.GetComponent<turnManager>().bState == BattleState.TARGET &&
           Manager.GetComponent<AttackList>().Side[(Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack))] == "Enemy")
        {
            //print("enemy");
            if (fighter[3].GetComponent<Stats>().Alive)
            {
                targets[3].SetActive(true);

            }
            else
                targets[3].SetActive(false);

            if (fighter[4].GetComponent<Stats>().Alive)
            {
                targets[4].SetActive(true);

            }
            else
                targets[4].SetActive(false);

            if (fighter[5].GetComponent<Stats>().Alive)
            {
                targets[5].SetActive(true);

            }
            else
                targets[5].SetActive(false);

            /*
            Vector3 tagPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            target.transform.position = tagPosition;
            */
        }
        else
        {
            targets[3].SetActive(false);
            targets[4].SetActive(false);
            targets[5].SetActive(false);

        }

        //Self Target
        if (Manager.GetComponent<turnManager>().bState == BattleState.TARGET &&
           Manager.GetComponent<AttackList>().Side[(Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack))] == "Self")
        {
            //print("self");
            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[0])
            {
                targets[0].SetActive(true);
            }
            else
                targets[0].SetActive(false);

            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[1])
            {
                targets[1].SetActive(true);
            }
            else
                targets[1].SetActive(false);

            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[2])
            {
                targets[2].SetActive(true);
            }
            else
                targets[2].SetActive(false);

            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[3])
            {
                targets[3].SetActive(true);
            }
            else
                targets[3].SetActive(false);

            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[4])
            {
                targets[4].SetActive(true);
            }
            else
                targets[4].SetActive(false);

            if (Manager.GetComponent<turnManager>().takingTurn[0] == fighter[5])
            {
                targets[5].SetActive(true);
            }
            else
                targets[5].SetActive(false);
        }
    }
}
