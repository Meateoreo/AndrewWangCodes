using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatesManager;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private GameObject Manager;

    [SerializeField] private int AttackNumber;

    private Text myText;



    void Start()
    {
        myText = GetComponentInChildren<Text>();

        Manager = GameObject.Find("Manager");

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.GetComponent<turnManager>().takingTurn.Count > 0 && Manager.GetComponent<turnManager>().takingTurn[0] != null)
        {
            /*
            if (Manager.GetComponent<turnManager>().attack == "")
                Manager.GetComponent<turnManager>().attack = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[0];
            */

            /*
            if (AttackNumber == 1)
                myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[0];
            */

            if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Side == "Friend")
            {
                switch (AttackNumber)
                {
                    case 1:
                        if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[0] == "Head")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[0];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[1] == "Head")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[1];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[2] == "Head")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[2];
                        }

                        break;
                    case 2:
                        if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[0] == "Body")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[0];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[1] == "Body")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[1];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[2] == "Body")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[2];
                        }

                        break;
                    case 3:
                        if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[0] == "Legs")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[0];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[1] == "Legs")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[1];
                        }
                        else if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().PartType[2] == "Legs")
                        {
                            myText.text = Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Attacks[2];
                        }

                        break;
                }
            }
        }

    }

    public void OnClicked()
    {
        //print("attack Click");

        if (Manager.GetComponent<turnManager>().takingTurn[0].gameObject.GetComponent<Stats>().Side == "Friend" && 
            (Manager.GetComponent<turnManager>().bState == BattleState.MYTURN || Manager.GetComponent<turnManager>().bState == BattleState.TARGET))
        {
            if (Manager.GetComponent<AttackList>().Side[Manager.GetComponent<AttackList>().getAttackInfo(myText.text)] != "")
            {
                Manager.GetComponent<turnManager>().attack = myText.text;
                Manager.GetComponent<turnManager>().bState = BattleState.TARGET;
            }
        }


    }

    public void OnHover()
    {
        Manager.GetComponent<turnManager>().attackDescriptionText.text = myText.text + ": " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(myText.text)] + " (" + Manager.GetComponent<AttackList>().calcDamage(Manager.GetComponent<turnManager>().takingTurn[0], myText.text) + ")";


    }

}
