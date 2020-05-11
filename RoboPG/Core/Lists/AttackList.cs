using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackList : MonoBehaviour
{
    [SerializeField] private string[] description;
    [SerializeField] private float[] damage;
    [SerializeField] private float[] statusChance;
    [SerializeField] private string[] statusType;
    [SerializeField] private int[] statusDuration;
    [SerializeField] private string[] targets;
    [SerializeField] private string[] side;
    [SerializeField] private int[] attackIndex;

    public GameObject[] AttackAnimations;
    public Sprite[] StatusImages;

    public string[] Description { get => description; }
    public float[] Damage { get => damage; }
    public float[] StatusChance { get => StatusChance; }
    public string[] StatusType { get => statusType; }
    public int[] StatusDuration { get => statusDuration; }
    public string[] Targets { get => targets; }
    public string[] Side { get => side; }
    public int[] AttackIndex { get => attackIndex; }


    private void Awake()
    {
        description = new string[100];
        damage = new float[100];
        statusChance = new float[100];
        statusType = new string[100];
        statusDuration = new int[100];
        targets = new string[100];
        side = new string[100];
        attackIndex = new int[100];


        //idle 0
        description[0] = "Do nothing.";
        damage[0] = 0;
        statusChance[0] = 0; 
        statusType[0] = "";
        statusDuration[0] = 0;
        targets[0] = "Single";
        side[0] = "none";
        attackIndex[0] = 1;

        //headbutt 1
        description[1] = "Deals damage based on MaxHP with a 30% chance of causing the target to LAG on their next turn.";
        damage[1] = 1f;
        statusChance[1] = 30;
        statusType[1] = "Lag";
        statusDuration[1] = 1;
        targets[1] = "Single";
        side[1] = "Enemy";
        attackIndex[1] = 0;

        //steelgrip 2
        description[2] = "Deals damage based on Power. With a 30% chance to gain a POWERSURGE for 2 turns.";
        damage[2] = 1.1f;
        statusChance[2] = 30;
        statusType[2] = "PowerSurge";
        statusDuration[2] = 3;
        targets[2] = "Single";
        side[2] = "Enemy";
        attackIndex[2] = 2;

        //TruckCharge 3
        description[3] =  "Risky attack that deals more damage the FASTER you are, but causes recoil damage.";
        damage[3] = 0.9f;
        statusChance[3] = 0;
        statusType[3] = "";
        statusDuration[3] = 0;
        targets[3] = "Single";
        side[3] = "Enemy";
        attackIndex[3] = 0;

        //PowerLine 4
        damage[4] = 1;
        statusType[4] = "";
        statusDuration[4] = 0;
        targets[4] = "All";
        side[4] = "Enemy";

        //Piston Crusher 5
        description[5] = "Deals damage based on both speed and power.";
        damage[5] = 1.1f;
        statusChance[5] = 0;
        statusType[5] = "";
        statusDuration[5] = 0;
        targets[5] = "Single";
        side[5] = "Enemy";
        attackIndex[5] = 2;

        //Piston Charge 6
        description[6] = "Quickly tackle at your enemy and grant yourself a POWERSURGE for 1 turn.";
        damage[6] = 1;
        statusChance[6] = 100;
        statusType[6] = "PowerSurge";
        statusDuration[6] = 2;
        targets[6] = "Single";
        side[6] = "Enemy";
        attackIndex[6] = 0;

        //Piston Rush 7
        description[7] = "Quickly tackle at your enemy with a 15% chance of causing the target to LAG on their next turn.";
        damage[7] = 1;
        statusChance[7] = 15;
        statusType[7] = "Lag";
        statusDuration[7] = 0;
        targets[7] = "Single";
        side[7] = "Enemy";
        attackIndex[7] = 0;

        //Thor's Burp 8
        description[8] = "Deals damage and heals for a portion of damage dealt with a 50% chance to infect the target with RUST for 1 turn.";
        damage[8] = 2;
        statusChance[8] = 50;
        statusType[8] = "Rust";
        statusDuration[8] = 0;
        targets[8] = "Single";
        side[8] = "Enemy";
        attackIndex[8] = 2;

        //SteamEngine 50
        description[50] = "(Passive) This PART has increased Power and Speed, but decreased HP. \t(Active) 50% chance to infect the target with RUST for 3 turns.";
        damage[50] = 51;
        statusChance[50] = 50;
        statusType[50] = "Rust";
        statusDuration[50] = 2;
        targets[50] = "Single";
        side[50] = "Enemy";
        attackIndex[98] = 2;

        //ChainMail 51
        description[51] = "(Passive) This PART has increased Power and HP, but decreased Speed. \t(Active) Grant yourself a POWERSURGE for 2 turns.";
        damage[51] = 51;
        statusChance[51] = 100;
        statusType[51] = "PowerSurge";
        statusDuration[51] = 3;
        targets[51] = "Single";
        side[51] = "Enemy";
        attackIndex[98] = 1;

        //Reboot 98
        description[98] = "Removes Status and Heals based on Power";
        damage[98] = 0.25f;
        statusChance[98] = 0;
        statusType[98] = "";
        statusDuration[98] = 0;
        targets[98] = "Single";
        side[98] = "Friend";
        attackIndex[98] = 1;

        //Recharge 99
        description[99] = "Heal based on Power and grant the target a POWERSURGE for 1 turn.";
        damage[99] = 0.4f;
        statusChance[99] = 100;
        statusType[99] = "PowerSurge";
        statusDuration[99] = 1;
        targets[99] = "Single";
        side[99] = "Friend";
        attackIndex[99] = 1;



    }


    public int getAttackInfo(string attackName)
    {
        switch (attackName)
        {
            case "Headbutt":
                return 1;
            case "SteelGrip":
                return 2;
            case "TruckCharge":
                return 3;
            case "PowerLine":
                return 4;
            case "PistonCrusher":
                return 5;
            case "PistonCharge":
                return 6;
            case "PistonRush":
                return 7;
            case "ThorsBurp":
                return 8;

            case "SteamEngine":
                return 50;
            case "ChainMail":
                return 51;


            case "Recharge":
                return 99;

        }
        return 0;
    }

    public float calcDamage(GameObject self, string attack)
    {
        //Initialize
        float calc = 0;

        //Attacks
        if (attack == "Headbutt") // Deals damage based on HP.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().maxHP * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "SteelGrip") //Deals damage base on Power.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.4f * damage[getAttackInfo(attack)]);
        }

        if (attack == "TruckCharge") //Risky attack that deals more damage the FASTER you are, but causes recoil damage
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.5f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.25f);
        }

        if (attack == "PistonCharge") //"Quickly tackle at your enemy.";
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "PistonCrusher") //Deals damage based on both speed and power.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.25f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.25f);
        }

        if (attack == "PistonRush") //Deals more damage the FASTER you are.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "ThorsBurp") //Damage opponent and heal off some of the damage.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.1f * damage[getAttackInfo(attack)]);
        }

        //Healings
        if (attack == "Reboot")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.5f * damage[getAttackInfo(attack)]);
        }

        if (attack == "Recharge")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.5f * damage[getAttackInfo(attack)]);
        }

        if (attack == "Idle")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().HP * 0.1f * damage[getAttackInfo(attack)]);
        }

        if (attack == "SteamEngine")
        {
            calc = 0;
        }

        if (attack == "ChainMail")
        {
            calc = 0;
        }

        if (self.GetComponent<Stats>().Statuses == "PowerSurge")
        {
            calc = calc * 1.3f;
        }

        return Mathf.Round(calc);

    }


    public float applyDamage(GameObject self, GameObject target, string attack)
    {
        //Initialize
        float calc = 0;

        //Attacks
        if (attack == "Headbutt") // Deals damage based on HP.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().maxHP * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "SteelGrip") //Deals damage base on Power.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.4f * damage[getAttackInfo(attack)]);
        }

        if (attack == "TruckCharge") //Risky attack that deals more damage the FASTER you are, but causes recoil damage
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.5f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.25f);
        }

        if (attack == "PistonCharge") //"Quickly tackle at your enemy.";
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "PistonCrusher") //Deals damage based on both speed and power.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.25f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.25f);
        }

        if (attack == "PistonRush") //Deals more damage the FASTER you are.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Speed * 0.1f * damage[getAttackInfo(attack)] + self.GetComponent<Stats>().Power * 0.1f);
        }

        if (attack == "ThorsBurp") //Damage opponent and heal off some of the damage.
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.1f * damage[getAttackInfo(attack)]);
        }

        //Healings
        if (attack == "Reboot")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.5f * damage[getAttackInfo(attack)]);
        }

        if (attack == "Recharge")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().Power * 0.7f * damage[getAttackInfo(attack)]);
        }

        if (attack == "Idle")
        {
            calc = Mathf.Round(self.GetComponent<Stats>().HP * 0.1f * damage[getAttackInfo(attack)]);
        }

        if (attack == "SteamEngine")
        {
            calc = 0;
        }

        if (attack == "ChainMail")
        {
            calc = 0;
        }

        if (self.GetComponent<Stats>().Statuses == "PowerSurge")
        {
            calc = calc * 1.3f;
        }


        if (attack == "Recharge")
        {
            target.GetComponent<Stats>().HP += Mathf.Round(calc);
        }
        else
            target.GetComponent<Stats>().HP -= Mathf.Round(calc);

        //Rng for Status Stuffs
        int randomNum = Random.Range(0, 100);
        print(randomNum);

        //check if number is lower than the % chance
        if (randomNum < statusChance[getAttackInfo(attack)])
        {
            //check if there is a status for the attack
            if (statusType[getAttackInfo(attack)] != "")
            {
                //check if status is not POWERSURGE
                if (statusType[getAttackInfo(attack)] != "PowerSurge")
                {
                    //check if the target already have the exact same status
                    if (statusType[getAttackInfo(attack)] == target.GetComponent<Stats>().Statuses)
                    {
                        //if it does check the current duration of the status and take the bigger one
                        if (target.GetComponent<Stats>().StatusDuration < statusDuration[getAttackInfo(attack)])
                        {
                            target.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)];
                        }
                    }
                    else //otherwise if its not the same status, rewrite it all
                    {
                        target.GetComponent<Stats>().Statuses = statusType[getAttackInfo(attack)];
                        target.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)];
                    }
                }
                else //if the status is POWERSURGE
                {
                    if (attack == "Recharge")
                    {
                        //if used on urself
                        if (target == self)
                        {
                            target.GetComponent<Stats>().Statuses = statusType[getAttackInfo(attack)];
                            target.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)] + 1;
                        }
                        else //used on friend
                        {
                            //check if the target already have the exact same status
                            if (statusType[getAttackInfo(attack)] == target.GetComponent<Stats>().Statuses)
                            {
                                //if it does check the current duration of the status and take the bigger one
                                if (target.GetComponent<Stats>().StatusDuration < statusDuration[getAttackInfo(attack)])
                                {
                                    target.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)];
                                }
                            }
                            else //otherwise if its not the same status, rewrite it all
                            {
                                target.GetComponent<Stats>().Statuses = statusType[getAttackInfo(attack)];
                                target.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)];
                            }
                        }
                    }
                    else //other attacks
                    {
                        self.GetComponent<Stats>().Statuses = statusType[getAttackInfo(attack)];
                        self.GetComponent<Stats>().StatusDuration = statusDuration[getAttackInfo(attack)];
                    }
                }
            }
        }
        
        //Extra Damage Effects
        if (attack == "TruckCharge")
        {
            self.GetComponent<Stats>().HP -= Mathf.Round(calc * 0.2f);
        }

        if (attack == "ThorsBurp")
        {
            self.GetComponent<Stats>().HP += Mathf.Round(calc * 0.25f);
        }

        return Mathf.Round(calc);
    }
}
