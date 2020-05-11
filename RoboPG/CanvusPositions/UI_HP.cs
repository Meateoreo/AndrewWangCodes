using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    private GameObject Manager;

    private Vector3 oldPosition;

    public Stats robot;
    public Transform barPosition;
    public string barType;


    public Text HPText;

    public float offsetX;

    private void Awake()
    {
        oldPosition = new Vector3(-500, -500);

        Manager = GameObject.Find("Manager");
    }

    private void Start()
    {
        if (barType == "Base")
        {
            Vector3 barPos = Camera.main.WorldToScreenPoint(barPosition.position);
            
            transform.position = new Vector3(barPos.x + offsetX, barPos.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (barType == "Base")
        {
            if (robot.Alive)
            {
                Vector3 barPos = Camera.main.WorldToScreenPoint(barPosition.position);

                transform.position = new Vector3(barPos.x + offsetX, barPos.y);
            }
            else
                transform.position = oldPosition;
        }

        if (barType == "Health")
        {
            if (robot.Alive && robot.maxHP > 0)
                transform.localScale = new Vector3(robot.HP / robot.maxHP, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }

        if (barType == "Ready")
        {
            if (robot.Alive && robot.Ready > 0)
                transform.localScale = new Vector3(robot.Ready / 100, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }

        if (barType == "Current")
        {
            if (Manager.GetComponent<turnManager>().takingTurn.Count > 0)
                robot = Manager.GetComponent<turnManager>().takingTurn[0].GetComponent<Stats>();

            if (robot != null)
            {
                if (robot.Alive)
                    transform.localScale = new Vector3(robot.HP / robot.maxHP, transform.localScale.y, transform.localScale.z);
                else
                    transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);

                HPText.text = robot.HP + " / " + robot.maxHP;
            }
        }
    }
}
