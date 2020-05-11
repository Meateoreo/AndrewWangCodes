using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

public class BuildButton : MonoBehaviour
{
    private GameObject Manager;
    private GameState GameStateScript;

    [SerializeField] private Transform parts;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
        GameStateScript = Manager.GetComponent<GameState>();

    }
    

    public void onClicked()
    {
        if (Manager.GetComponent<RobotCreation>().headIndex != Manager.GetComponent<RobotCreation>().headList.Count - 1)
        {
            if (Manager.GetComponent<RobotCreation>().curRobot == 1)
            {
                Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[0].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 2)
            {
                Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[1].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 3)
            {
                Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[2].transform);
            }

            Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headList.Count - 1].transform.SetParent(parts);
            Manager.GetComponent<RobotCreation>().headList.Remove(Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headIndex]);

            //nager.GetComponent<RobotCreation>().headIndex = 0;

        }
        else
        {
            Manager.GetComponent<RobotCreation>().headList.Remove(Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headList.Count-1]);
        }

        if (Manager.GetComponent<RobotCreation>().bodyIndex != Manager.GetComponent<RobotCreation>().bodyList.Count - 1)
        {
            if (Manager.GetComponent<RobotCreation>().curRobot == 1)
            {
                Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[0].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 2)
            {
                Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[1].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 3)
            {
                Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[2].transform);
            }

            Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyList.Count - 1].transform.SetParent(parts);
            Manager.GetComponent<RobotCreation>().bodyList.Remove(Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyIndex]);

            //nager.GetComponent<RobotCreation>().bodyIndex = 0;

        }
        else
        {
            Manager.GetComponent<RobotCreation>().bodyList.Remove(Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyList.Count - 1]);
        }

        if (Manager.GetComponent<RobotCreation>().legIndex != Manager.GetComponent<RobotCreation>().legList.Count - 1)
        {
            if (Manager.GetComponent<RobotCreation>().curRobot == 1)
            {
                Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[0].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 2)
            {
                Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[1].transform);
            }

            if (Manager.GetComponent<RobotCreation>().curRobot == 3)
            {
                Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legIndex].transform.SetParent(Manager.GetComponent<RobotCreation>().MyRobots[2].transform);
            }

            Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legList.Count - 1].transform.SetParent(parts);
            Manager.GetComponent<RobotCreation>().legList.Remove(Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legIndex]);

            //nager.GetComponent<RobotCreation>().legIndex = 0;

        }
        else
        {
            Manager.GetComponent<RobotCreation>().legList.Remove(Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legList.Count - 1]);
        }
        /*
        Manager.GetComponent<RobotCreation>().headList[Manager.GetComponent<RobotCreation>().headList.Count-1].transform.SetParent(parts);
        Manager.GetComponent<RobotCreation>().removeHead(Manager.GetComponent<RobotCreation>().headList.Count - 1);
        Manager.GetComponent<RobotCreation>().bodyList[Manager.GetComponent<RobotCreation>().bodyList.Count - 1].transform.SetParent(parts);
        Manager.GetComponent<RobotCreation>().removeBody(Manager.GetComponent<RobotCreation>().bodyList.Count - 1);
        Manager.GetComponent<RobotCreation>().legList[Manager.GetComponent<RobotCreation>().legList.Count - 1].transform.SetParent(parts);
        Manager.GetComponent<RobotCreation>().removeLegs(Manager.GetComponent<RobotCreation>().legList.Count - 1);
        */
        Manager.GetComponent<RobotCreation>().headIndex = 0;
        Manager.GetComponent<RobotCreation>().bodyIndex = 0;
        Manager.GetComponent<RobotCreation>().legIndex = 0;
        

        if (Manager.GetComponent<RobotCreation>().curRobot == 1)
            Manager.GetComponent<RobotCreation>().MyRobots[0].GetComponent<Stats>().ResetStats();
        if (Manager.GetComponent<RobotCreation>().curRobot == 2)
            Manager.GetComponent<RobotCreation>().MyRobots[1].GetComponent<Stats>().ResetStats();
        if (Manager.GetComponent<RobotCreation>().curRobot == 3)
            Manager.GetComponent<RobotCreation>().MyRobots[2].GetComponent<Stats>().ResetStats();

        //Manager.GetComponent<RobotCreation>().resetList();



        GameStateScript.ChangeScene(PlayState.ROBOTMENU);        
    }
}
