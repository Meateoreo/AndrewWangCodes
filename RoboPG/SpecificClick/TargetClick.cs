using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

public class TargetClick : MonoBehaviour
{
    [SerializeField] private GameObject Manager;

    [SerializeField] private GameObject fighter;
    [SerializeField] private Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
        Vector3 tagPosition = Camera.main.WorldToScreenPoint(targetPosition.position);
        transform.position = tagPosition;

    }

    // Update is called once per frame
    void Update()
    {
        //print("moving");
        Vector3 tagPosition = Camera.main.WorldToScreenPoint(targetPosition.position);
        transform.position = tagPosition;
    }

    public void onClicked()
    {
       //print("target click");

        Manager.GetComponent<turnManager>().target = fighter;
        //if (Manager.GetComponent<AttackList>().Targets[Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack)] == "All")
        //    Manager.GetComponent<turnManager>().attackAll(Manager.GetComponent<AttackList>().Side[Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack)]);
       
        //if (Manager.GetComponent<AttackList>().Targets[Manager.GetComponent<AttackList>().getAttackInfo(Manager.GetComponent<turnManager>().attack)] == "Single")
          //  Manager.GetComponent<turnManager>().attackThis();

        Manager.GetComponent<turnManager>().bState = BattleState.ATTACK;
    }


}
