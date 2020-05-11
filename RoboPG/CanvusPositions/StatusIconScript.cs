using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIconScript : MonoBehaviour
{
    private GameObject Manager;

    [SerializeField] private GameObject robot;

    private Vector3 barPosition;

    public float offsetX;


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        barPosition = Camera.main.WorldToScreenPoint(robot.GetComponent<Stats>().HPBarPlacement.transform.position);

        if (robot.GetComponent<Stats>().Side == "Enemy")
            transform.position = new Vector3(barPosition.x + Screen.width/24 + offsetX, barPosition.y);
        else
            transform.position = new Vector3(barPosition.x - Screen.width / 16 - offsetX, barPosition.y);

        if (robot.GetComponentInChildren<Stats>().Statuses == "")
        {
            GetComponentInChildren<Image>().color = new Color(GetComponentInChildren<Image>().color.r, GetComponentInChildren<Image>().color.g, GetComponentInChildren<Image>().color.b, 0f);
        }
        else
        {
            GetComponentInChildren<Image>().color = new Color(GetComponentInChildren<Image>().color.r, GetComponentInChildren<Image>().color.g, GetComponentInChildren<Image>().color.b, 1f);

            switch (robot.GetComponentInChildren<Stats>().Statuses)
            {
                case "PowerSurge":
                    GetComponentInChildren<Image>().sprite = Manager.GetComponent<AttackList>().StatusImages[0];
                    break;

                case "Rust":
                    GetComponentInChildren<Image>().sprite = Manager.GetComponent<AttackList>().StatusImages[1];
                    break;

                case "Lag":
                    GetComponentInChildren<Image>().sprite = Manager.GetComponent<AttackList>().StatusImages[2];
                    break;
            }
        }

        if (robot.GetComponentInChildren<Stats>().StatusDuration <= 0)
        {
            GetComponentInChildren<Text>().text = "";
        }
        else
        {
            GetComponentInChildren<Text>().text = robot.GetComponentInChildren<Stats>().StatusDuration.ToString();
        }

    }
}
