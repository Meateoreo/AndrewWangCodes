using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private bool dead;
    [SerializeField] private int lives;

    [SerializeField] private bool fighting;
    [SerializeField] private bool jumping;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool hit;
    [SerializeField] private bool ducking;
    [SerializeField] private string facing;

    [SerializeField] private string weight;


    private void Awake()
    {
        lives = 1;
    }

    void Start()
    {
        if (this.gameObject.tag == "miniBear")
            weight = "medium";

        if (this.gameObject.tag == "raBBIT")
            weight = "light";

        if (this.gameObject.tag == "thePlayer")
            weight = "medium";

        resetStatus();
    }

    public int HP { get => hp; set => hp = value; }
    public int MaxHP { get => maxHp; set => maxHp = value; }
    public bool Dead { get => dead; set => dead = value; }
    public int Lives { get => lives; set => lives = value; }
    public bool Hit { get => hit; set => hit = value; }
    public bool Fighting{ get => fighting; set => fighting = value; }
    public bool Jumping { get => jumping; set => jumping = value; }
    public bool Ducking { get => ducking; set => ducking = value; }
    public bool DoubleJump { get => doubleJump; set => doubleJump = value; }
    public string Facing { get => facing; set => facing = value; }
    public string Weight { get => weight; }

    public void resetStatus()
    {
        hp = maxHp;
        dead = false;
        fighting = false;
        ducking = false;
        hit = false;
        jumping = true;
        doubleJump = true;
        facing = "right";
    }

    private void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            dead = true;
        }

        if (hp > MaxHP)
            hp = maxHp;
        

    }
}
