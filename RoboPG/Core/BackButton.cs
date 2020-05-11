using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject Manager;



    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    public void onClick()
    {
        if (Manager.GetComponent<GameState>().pState == PlayState.TOWN)
        {
           Manager.GetComponent<GameState>().ChangeScene(PlayState.TITLE);
        }

        if (Manager.GetComponent<GameState>().pState == PlayState.BATTLE)
        {
            Manager.GetComponent<turnManager>().clearTurnManager();
            Manager.GetComponent<GameState>().ChangeScene(PlayState.TOWN);
        }

        if (Manager.GetComponent<GameState>().pState == PlayState.ROBOTMENU)
        {
            Manager.GetComponent<GameState>().ChangeScene(PlayState.TOWN);
        }

        if (Manager.GetComponent<GameState>().pState == PlayState.ROBOTMENU2)
        {
            Manager.GetComponent<RobotCreation>().headIndex = 0;
            Manager.GetComponent<RobotCreation>().bodyIndex = 0;
            Manager.GetComponent<RobotCreation>().legIndex = 0;

            Manager.GetComponent<RobotCreation>().headList.Remove(Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headList.Count - 1]);
            Manager.GetComponent<RobotCreation>().bodyList.Remove(Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyList.Count - 1]);
            Manager.GetComponent<RobotCreation>().legList.Remove(Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legList.Count - 1]);

            //Manager.GetComponent<RobotCreation>().removeHead(Manager.GetComponent<RobotCreation>().headList.Length - 1);
            //Manager.GetComponent<RobotCreation>().removeBody(Manager.GetComponent<RobotCreation>().bodyList.Length - 1);
            //Manager.GetComponent<RobotCreation>().removeLegs(Manager.GetComponent<RobotCreation>().legList.Length - 1);

            Manager.GetComponent<GameState>().ChangeScene(PlayState.ROBOTMENU);
        }

    }

}
