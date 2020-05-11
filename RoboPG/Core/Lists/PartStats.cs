using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStats : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private int hp;
    [SerializeField] private int power;
    [SerializeField] private int speed;
    [SerializeField] private string attackName;
    [SerializeField] private int cooldown;

    public Sprite mySprite;

    public int sellPrice;

    private GameObject Manager;


    public string Type { get => type; }
    public int HP { get => hp; }
    public int Power { get => power; }
    public int Speed { get => speed; }
    public string AttackName { get => attackName; }
    public int Cooldown { get => cooldown; }

    //public Sprite MySprite { get => mySprite; }

    private void Awake()
    {
        if (attackName == "")
            attackName = "None";
    }



    private void Start()
    {
        Manager = GameObject.Find("Manager");
        
        if (transform.parent.name == "Parts")
        {
            if (type == "Head")
            {
                Manager.GetComponent<RobotCreation>().headList.Add(gameObject);
            }

            if (type == "Body")
            {
                Manager.GetComponent<RobotCreation>().bodyList.Add(gameObject);
            }

            if (type == "Legs")
            {
                Manager.GetComponent<RobotCreation>().legList.Add(gameObject);
            }
        }

    }

    private void Update()
    {
        sellPrice = hp + power * 2 + speed * 3;
    }

    public void setStats(string type, int hp, int power, int speed, string attackName)
    {
        this.type = type;
        this.hp = hp;
        this.power = power;
        this.speed = speed;
        this.attackName = attackName;

        //AddToPartList();
    }

}


