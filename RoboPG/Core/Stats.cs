using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatesManager;

public class Stats : MonoBehaviour
{
    [SerializeField] private GameObject Manager;

    public Vector3 oldPosition;

    [SerializeField] private bool alive;

    [SerializeField] private float maxHp = 100;
    [SerializeField] private float hp = 100;
    [SerializeField] private float power = 10;
    [SerializeField] private float speed = 100;
    [SerializeField] private float ready;
    [SerializeField] private PartStats[] partStats;

    public Sprite headPart;
    public Sprite bodyPart;
    public Sprite legPart;


    [SerializeField] private Sprite[] partSprite;
    [SerializeField] private string[] partType;
    [SerializeField] private string[] attacks;
    [SerializeField] private int[] cooldowns;


    //Status effects
    [SerializeField] private string statuses;
    [SerializeField] private int statusDuration;


    public GameObject HPBarPlacement;
    public float offsetY;

    //public BattleState bstate;

    [SerializeField] private string side;


    public bool Alive { get => alive; set => alive = value; }
    public float maxHP { get => maxHp; set => maxHp = value; }
    public float HP { get => hp; set => hp = value; }
    public float Power { get => power; set => power = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Ready { get => ready; set => ready = value; }

    public Sprite[] PartSprite { get => partSprite; set => partSprite = value; }
    public string[] PartType { get => partType; set => partType = value; }
    public string[] Attacks { get => attacks; set => attacks = value; }
    public int[] Cooldowns { get => cooldowns; set => cooldowns = value; }

    public string Statuses { get => statuses; set => statuses = value; }
    public int StatusDuration { get => statusDuration; set => statusDuration = value; }


    public string Side { get => side; }

    private void Start()
    {
        ResetStats();
        oldPosition = transform.position;
        Manager = GameObject.Find("Manager");
    }

    private void Update()
    {
        if (hp == 0)
            alive = false;
        else
            alive = true;

        if (hp > maxHp)
            hp = maxHp;

        //bstate = TurnManagerScript.bState;
        if (Manager.GetComponent<turnManager>().bState == BattleState.END)
        {
            ready = 0;
        }

        #region not negative or 0
        if (hp < 0)
            hp = 0;
        if (power < 1)
            power = 1;
        if (speed < 1)
            speed = 1;
        #endregion
        
        if (Manager.GetComponent<turnManager>().bState == BattleState.PREPARE && HP > 0)
        {
            Ready += speed * 0.9f * Time.deltaTime;
        }

        if (ready >= 100 && alive)
        {
            ready = 0;

            //print("added: " + gameObject);
            Manager.GetComponent<turnManager>().takingTurn.Add(gameObject);
        }

        if (!alive)
        {
            Manager.GetComponent<turnManager>().fighters.Remove(gameObject);

            if (side == "Friend" && Manager.GetComponent<turnManager>().friends.Contains(gameObject))
                Manager.GetComponent<turnManager>().friends.Remove(gameObject);
            if (side == "Enemy" && Manager.GetComponent<turnManager>().enemies.Contains(gameObject))
                Manager.GetComponent<turnManager>().enemies.Remove(gameObject);

            if (Manager.GetComponent<turnManager>().takingTurn.Contains(gameObject))
            {
                if (Manager.GetComponent<turnManager>().takingTurn[0] == gameObject)
                    Manager.GetComponent<turnManager>().bState = BattleState.PREPARE;

                Manager.GetComponent<turnManager>().takingTurn.Remove(gameObject);
            }
                
            if (side == "Enemy")
                GetComponent<SpriteRenderer>().enabled = false;

            statuses = "";
            statusDuration = 0;

        }

        if (alive)
        {
            
            if (side == "Friend" && !Manager.GetComponent<turnManager>().friends.Contains(gameObject))
                Manager.GetComponent<turnManager>().friends.Add(gameObject);
            if (side == "Enemy" && !Manager.GetComponent<turnManager>().enemies.Contains(gameObject))
                Manager.GetComponent<turnManager>().enemies.Add(gameObject);
                
            if (side == "Enemy")
                GetComponent<SpriteRenderer>().enabled = true;
        }


        if (partType[0] == "Head")
            headPart = partSprite[0];
        else if (partType[1] == "Head")
            headPart = partSprite[1];
        else if (partType[2] == "Head")
            headPart = partSprite[2];


        if (partType[0] == "Body")
            bodyPart = partSprite[0];
        else if (partType[1] == "Body")
            bodyPart = partSprite[1];
        else if (partType[2] == "Body")
            bodyPart = partSprite[2];


        if (partType[0] == "Legs")
            legPart = partSprite[0];
        else if (partType[1] == "Legs")
            legPart = partSprite[1];
        else if (partType[2] == "Legs")
            legPart = partSprite[2];


        //hp bar put here
        HPBarPlacement.transform.position = new Vector3(transform.position.x, transform.position.y + offsetY);

    }

    /*
    private void FixedUpdate()
    {
        if (Manager.GetComponent<turnManager>().bState == BattleState.PREPARE && HP > 0)
        {
            Ready += speed * 0.0125f;
        }

        if (ready >= 100 && alive)
        {
            /*
            if (side == "Friend")
                Manager.GetComponent<turnManager>().bState = BattleState.MYTURN;
            else
                Manager.GetComponent<turnManager>().bState = BattleState.AUTO;
                
            ready = 0;

            print("added: " + gameObject);
            Manager.GetComponent<turnManager>().takingTurn.Add(gameObject);
        }
    }*/


    public void ResetStats()
    {
        statuses = "";
        statusDuration = 0;

        partSprite = new Sprite[3];
        partType = new string[3];
        attacks = new string[3];
        cooldowns = new int[3];
        int count = 0;
        maxHP = 100;
        power = 10;
        speed = 100;

        partStats = gameObject.GetComponentsInChildren<PartStats>();

        foreach (PartStats stat in partStats)
        {
            maxHp += stat.HP;
            power += stat.Power;
            speed += stat.Speed;
            partType[count] = stat.Type;
            attacks[count] = stat.AttackName;
            partSprite[count] = stat.mySprite;
            cooldowns[count++] = stat.Cooldown;

        }

        hp = maxHp;
    }

    public void SetStats(float maxHP, float power, float speed, string att1, string att2, string att3)
    {
        this.maxHP = maxHP;
        this.power = power;
        this.speed = speed;

        hp = maxHP;

        attacks = new string[3];
        attacks[0] = att1;
        attacks[1] = att2;
        attacks[2] = att3;

    }

}
