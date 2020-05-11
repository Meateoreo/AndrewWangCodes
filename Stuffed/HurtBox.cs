using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] private Status myStatus; //script from above object
    [SerializeField] private StartingGame StartStuck;
    [SerializeField] private bool vulnerable;
    [SerializeField] private int stunned;

    public int Stunned { get => stunned; set => stunned = value; }
    public bool Vulnerable { get => vulnerable; set => vulnerable = value; }

    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        vulnerable = true;
        //myStatus = GetComponentInParent<Status>();
    }

    #region Stunned Stuffs
    private void FixedUpdate()
    {
        if (myStatus != null)
        {
            if (stunned != 0)
            {
                stunned--;
            }

            if (stunned <= 0)
            {
                stunned = 0;
                myStatus.Hit = false;
            }
        }
        else
            Debug.Log("no status????????");
    }

    private void Update()
    {
        if (stunned != 0)
        {
            myStatus.Hit = true;
        }
    }

    IEnumerator hitStun(float stunTime)
    {
        vulnerable = false;
        myStatus.Hit = true;
        yield return new WaitForSeconds(0.5f);
        vulnerable = true;
        yield return new WaitForSeconds(stunTime); //delay before moving
        Debug.Log("bloop");
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        //find the rigidbody of this object
        //Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();

        float hpPercent; //create local variable

        //check for all these things
        if (rb != null && vulnerable && myStatus.HP != -1 && hitbox.tag == "Hitbox")
        {
            //calculate the damage taken and change it to a float
            float difference = (myStatus.MaxHP - myStatus.HP);
            hpPercent = (difference / myStatus.MaxHP);

            //Player Hitboxes
            #region PlayerAttacks
            //Neutral
            if (hitbox.gameObject.name == "NA")
            {
                myStatus.HP -= Damages.Neutral;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1, 0.15f) * Globals.knockbackCalc(Knockbacks.Neutral, hpPercent, myStatus.Weight);
                            
                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, 0.15f) * Globals.knockbackCalc(Knockbacks.Neutral, hpPercent, myStatus.Weight);

                stunned = StunTime.Neutral;
                
            }

            //Forward Tilt
            if (hitbox.gameObject.name == "ForwardTilt")
            {
                myStatus.HP -= Damages.ForwardTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1, 0.8f) * Globals.knockbackCalc(Knockbacks.ForwardTilt, hpPercent, myStatus.Weight);
                
                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, 0.8f) * Globals.knockbackCalc(Knockbacks.ForwardTilt, hpPercent, myStatus.Weight);

                stunned = StunTime.ForwardTilt;
            }

            //Up Tilt
            if (hitbox.gameObject.name == "UpTilt")
            {
                myStatus.HP -= Damages.UpTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.1f, 1f) * Globals.knockbackCalc(Knockbacks.UpTilt, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.1f, 1f) * Globals.knockbackCalc(Knockbacks.UpTilt, hpPercent, myStatus.Weight);

                stunned = StunTime.UpTilt;
            }

            //Down Tilt
            if (hitbox.gameObject.name == "DownTilt")
            {
                myStatus.HP -= Damages.DownTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1f, 0.9f) * Globals.knockbackCalc(Knockbacks.DownTilt, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1f, 0.9f) * Globals.knockbackCalc(Knockbacks.DownTilt, hpPercent, myStatus.Weight);

                stunned = StunTime.DownTilt;
            }

            //Neutral Air
            if (hitbox.gameObject.name == "Nair")
            {
                myStatus.HP -= Damages.NeutralAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.25f, 1f) * Globals.knockbackCalc(Knockbacks.NeutralAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.25f, 1f) * Globals.knockbackCalc(Knockbacks.NeutralAir, hpPercent, myStatus.Weight);

                stunned = StunTime.NeutralAir;
            }

            //Forward Air
            if (hitbox.gameObject.name == "Fair")
            {
                myStatus.HP -= Damages.ForwardAir;
                
                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1f, 0.5f) * Globals.knockbackCalc(Knockbacks.ForwardAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1f, 0.5f) * Globals.knockbackCalc(Knockbacks.ForwardAir, hpPercent, myStatus.Weight);

                stunned = StunTime.ForwardAir;
            }

            //Back Air
            if (hitbox.gameObject.name == "Bair")
            {
                myStatus.HP -= Damages.BackAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1, 0.25f) * Globals.knockbackCalc(Knockbacks.BackAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, 0.25f) * Globals.knockbackCalc(Knockbacks.BackAir, hpPercent, myStatus.Weight);

                stunned = StunTime.BackAir;
            }

            //Up Air
            if (hitbox.gameObject.name == "Uair")
            {
                myStatus.HP -= Damages.UpAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.1f, 1f) * Globals.knockbackCalc(Knockbacks.UpAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.1f, 1f) * Globals.knockbackCalc(Knockbacks.UpAir, hpPercent, myStatus.Weight);

                stunned = StunTime.UpAir;
            }

            //Down Air
            if (hitbox.gameObject.name == "Dair")
            {
                myStatus.HP -= Damages.DownAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1f, 0.5f) * Globals.knockbackCalc(Knockbacks.DownAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1f, 0.5f) * Globals.knockbackCalc(Knockbacks.DownAir, hpPercent, myStatus.Weight);

                stunned = StunTime.DownAir;
            }
            #endregion


            //Enemy Hitboxes
            #region EnemyAttacks
            if (this.gameObject.tag == "thePlayer")
            {
                Debug.Log(hitbox.gameObject.name);
                if (hitbox.gameObject.name == "hugBox")
                {
                    Debug.Log("hit");
                    myStatus.HP -= Damages.Hug;

                    if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(1, 0.5f) * Globals.knockbackCalc(Knockbacks.Hug, hpPercent, myStatus.Weight);

                    if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(-1, 0.5f) * Globals.knockbackCalc(Knockbacks.Hug, hpPercent, myStatus.Weight);

                    stunned = StunTime.Hug;

                }
                
                if (hitbox.gameObject.name == "headbuttBox")
                {
                    Debug.Log("hit");
                    myStatus.HP -= Damages.Headbutt;

                    if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(1, 0.5f) * Globals.knockbackCalc(Knockbacks.Headbutt, hpPercent, myStatus.Weight);

                    if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(-1, 0.5f) * Globals.knockbackCalc(Knockbacks.Headbutt, hpPercent, myStatus.Weight);

                    stunned = StunTime.Headbutt;

                }

                if (hitbox.gameObject.name == "LeftArm")
                {
                    Debug.Log("ow");
                    myStatus.HP -= Damages.LeftArm;

                    if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(1, 0.75f) * Globals.knockbackCalc(Knockbacks.LeftArm, hpPercent, myStatus.Weight);

                    if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(-1, 0.75f) * Globals.knockbackCalc(Knockbacks.LeftArm, hpPercent, myStatus.Weight);

                    stunned = StunTime.Headbutt;

                }

                if (hitbox.gameObject.name == "RightArm")
                {
                    Debug.Log("hehe");
                    myStatus.HP -= Damages.RightArm;

                    if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(1, 0.75f) * Globals.knockbackCalc(Knockbacks.RightArm, hpPercent, myStatus.Weight);

                    if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(-1, 0.75f) * Globals.knockbackCalc(Knockbacks.RightArm, hpPercent, myStatus.Weight);

                    stunned = StunTime.Headbutt;

                }

                if (hitbox.gameObject.name == "LaserPoint")
                {
                    Debug.Log("hehe");
                    myStatus.HP -= Damages.LaserPoint;

                    if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(1, 0.75f) * Globals.knockbackCalc(Knockbacks.LaserPoint, hpPercent, myStatus.Weight);

                    if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                        rb.velocity = new Vector2(-1, 0.75f) * Globals.knockbackCalc(Knockbacks.LaserPoint, hpPercent, myStatus.Weight);

                    stunned = StunTime.Headbutt;

                }
            }
            #endregion
        }
    }
}