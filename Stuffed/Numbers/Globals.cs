using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    //ChangingVariable
    //pause
    private static bool pause = false;

    //moveSpeed
    private static float moveSpeed = 0.5f;
    private static float maxSpeed = 6f;

    //for Jump
    private static float jumpHeight = 7f;
    private static float gravityMultiplier = 1.25f;
    private static float fastFallMultiplier = 3f;


    //InchangeableVariables or DependantVariables
    private static float baseMoveSpeed = moveSpeed;
    private static float baseJumpHeight = jumpHeight;

    //Hp Stuffs
    private static int playerHP = 100;
    private static int miniBearHP = 25;
    private static int raBBIT = 17;
    private static int unicorn = 11;
    private static int boss = 300;

    //Layers
    private static string onLayer = "OnPlatform";
    private static string throughLayer = "ThroughPlatform";


    //PAUSE STUFFS
    public static bool Pause { get => pause; }
    public static void pauseGame() //pauses and unpauses
    {
        if (pause == true)
            pause = false;
        else
            pause = true;
    }



    //HP STUFFS
    public static int PlayerHP { get => playerHP; }
    public static int MiniBearHP { get => miniBearHP; }
    public static int RaBBIT { get => raBBIT; }
    public static int Unicorn { get => unicorn; }
    public static int Boss { get => boss; }


    //MOVESPEED STUFFS
    public static float BaseMoveSpeed { get => baseMoveSpeed; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

    public static void resetMoveSpeed() //make moveSpeed back to base moveSpeed
    {
        moveSpeed = baseMoveSpeed;
    }

        //for Monsters/Enemies
        public static float getMonsterMoveSpeed(string weightLightMediumHeavy)
        {
            if (weightLightMediumHeavy == "light")
                return baseMoveSpeed * 1.2f;
            else if (weightLightMediumHeavy == "heavy")
                return baseMoveSpeed * 0.75f;
            else
                return baseMoveSpeed;
        }

    //JUMP STUFFS

    public static float BaseJumpHeight { get => baseJumpHeight; }
    public static float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public static float GravityMultiplier { get => gravityMultiplier; set => gravityMultiplier = value; }
    public static float FastFallMultiplier { get => fastFallMultiplier; set => fastFallMultiplier = value; }
    
    public static void resetJumpHeight()
    {
        jumpHeight = baseJumpHeight;
    }

        //for Monsters/Enemies
        public static float getMonsterJumpHeight(string weightLightMediumHeavy)
        {
            if (weightLightMediumHeavy == "light")
                return baseJumpHeight * 1.25f;
            else if (weightLightMediumHeavy == "heavy")
                return baseJumpHeight * 0.8f;
            else
                return baseJumpHeight;
        }

    //LAYER STUFFS
    public static string OnLayer { get => onLayer; }
    public static string ThroughLayer { get => throughLayer; }


    //KnockBack Stuffs
    public static float knockbackCalc(float knockdownPercent, float damagePercent, string weightLightMediumHeavy)
        {
            float kdDistance;
            //kdp changed to percent (kdp = knockdown percent)
            float KDP = knockdownPercent;

            if (weightLightMediumHeavy == "light")
            {
                if (damagePercent > 0.4f)
                    return kdDistance = (KDP + Mathf.Abs(KDP * damagePercent * 1.05f)) * 0.9f;
                if (damagePercent < 0.1f)
                    return kdDistance = Mathf.Max(KDP / 1.5f, (KDP - 1 + Mathf.Abs(KDP * damagePercent)) * 0.5f);
                else
                    return kdDistance = Mathf.Max(KDP / 1.5f, (KDP + Mathf.Abs(KDP * damagePercent * 0.6f)) * 0.7f);
            }

            if (weightLightMediumHeavy == "medium")
            {
                if (damagePercent > 0.5f)
                    return kdDistance = (KDP + Mathf.Abs(KDP * damagePercent * 0.9f)) * 0.8f;
                if (damagePercent < 0.2f)
                    return kdDistance = Mathf.Max(KDP / 2f, (KDP - 1 + Mathf.Abs(KDP * damagePercent * 0.3f)) * 0.4f);
                else
                    return kdDistance = Mathf.Max(KDP / 2f, (KDP + Mathf.Abs(KDP * damagePercent * 0.5f)) * 0.6f);
            }

            if (weightLightMediumHeavy == "heavy")
            {
                if (damagePercent > 0.7f)
                    return kdDistance = (KDP + Mathf.Abs(KDP * damagePercent * 0.7f)) * 0.7f;
                if (damagePercent < 0.3f)
                    return kdDistance = Mathf.Max(KDP / 3f, (KDP - 1 + Mathf.Abs(KDP * damagePercent * 0.1f)) * 0.3f);
                else
                    return kdDistance = Mathf.Max(KDP / 3f, (KDP + Mathf.Abs(KDP * damagePercent * 0.3f)) * 0.5f);
            }
            else
                return knockdownPercent;
        }
}