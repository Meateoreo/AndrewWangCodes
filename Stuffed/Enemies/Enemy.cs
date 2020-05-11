using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    protected string name;
    protected string weight;
    protected int hp;
    protected int baseHP;

    protected float moveSpeed;
    protected float jumpHeight;

    protected bool moving;
    protected bool attacking;
    protected bool damaged;
    
    
    public Enemy()
    {
        moving = false;
        attacking = false;
        damaged = false;
    }

    public Enemy(string name, int hp, string weight)
    {
        this.name = name;
        this.hp = hp;
        this.weight = weight;
        baseHP = hp;

        moveSpeed = Globals.getMonsterMoveSpeed(weight);
        jumpHeight = Globals.getMonsterJumpHeight(weight);
    }
   
}
