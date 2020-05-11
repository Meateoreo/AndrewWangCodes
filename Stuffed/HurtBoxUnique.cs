using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxUnique : MonoBehaviour
{
    [SerializeField] private Status myStatus; //script from above object
    
    [SerializeField] private Rigidbody2D rb;
    

    IEnumerator hit()
    {
        myStatus.Hit = true;
        yield return new WaitForSeconds(0.5f);
        myStatus.Hit = false;
    }

    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        float hpPercent; //create local variable

        //check for all these things
        if (rb != null && myStatus.HP != -1 && hitbox.tag == "Hitbox")
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
                    rb.velocity = new Vector2(1, -0.15f) * Globals.knockbackCalc(Knockbacks.Neutral, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, -0.15f) * Globals.knockbackCalc(Knockbacks.Neutral, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Forward Tilt
            if (hitbox.gameObject.name == "ForwardTilt")
            {
                myStatus.HP -= Damages.ForwardTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1, -0.8f) * Globals.knockbackCalc(Knockbacks.ForwardTilt, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, -0.8f) * Globals.knockbackCalc(Knockbacks.ForwardTilt, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Up Tilt
            if (hitbox.gameObject.name == "UpTilt")
            {
                myStatus.HP -= Damages.UpTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.1f, -0.1f) * Globals.knockbackCalc(Knockbacks.UpTilt, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.1f, -0.1f) * Globals.knockbackCalc(Knockbacks.UpTilt, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Down Tilt
            if (hitbox.gameObject.name == "DownTilt")
            {
                myStatus.HP -= Damages.DownTilt;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1f, -0.9f) * Globals.knockbackCalc(Knockbacks.DownTilt, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1f, -0.9f) * Globals.knockbackCalc(Knockbacks.DownTilt, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Neutral Air
            if (hitbox.gameObject.name == "Nair")
            {
                myStatus.HP -= Damages.NeutralAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.25f, -0.25f) * Globals.knockbackCalc(Knockbacks.NeutralAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.25f, -0.25f) * Globals.knockbackCalc(Knockbacks.NeutralAir, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Forward Air
            if (hitbox.gameObject.name == "Fair")
            {
                myStatus.HP -= Damages.ForwardAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.1f, -1f) * Globals.knockbackCalc(Knockbacks.ForwardAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.1f, -1f) * Globals.knockbackCalc(Knockbacks.ForwardAir, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Back Air
            if (hitbox.gameObject.name == "Bair")
            {
                myStatus.HP -= Damages.BackAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1, -0.25f) * Globals.knockbackCalc(Knockbacks.BackAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1, -0.25f) * Globals.knockbackCalc(Knockbacks.BackAir, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Up Air
            if (hitbox.gameObject.name == "Uair")
            {
                myStatus.HP -= Damages.UpAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(0.1f, 0.1f) * Globals.knockbackCalc(Knockbacks.UpAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-0.1f, 0.1f) * Globals.knockbackCalc(Knockbacks.UpAir, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }

            //Down Air
            if (hitbox.gameObject.name == "Dair")
            {
                myStatus.HP -= Damages.DownAir;

                if (transform.position.x > hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(1f, -0.5f) * Globals.knockbackCalc(Knockbacks.DownAir, hpPercent, myStatus.Weight);

                if (transform.position.x < hitbox.gameObject.transform.parent.position.x)
                    rb.velocity = new Vector2(-1f, -0.5f) * Globals.knockbackCalc(Knockbacks.DownAir, hpPercent, myStatus.Weight);

                StartCoroutine(hit());
            }
            #endregion
        }
    }
}