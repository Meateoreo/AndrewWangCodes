using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurt : MonoBehaviour
{
    [SerializeField] private Status myStatus; //script from above object

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip hitSound;


    IEnumerator hit()
    {
        myStatus.Hit = true;
        transform.parent.transform.position += Vector3.up * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.parent.transform.position += Vector3.down * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.parent.transform.position += Vector3.left * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.parent.transform.position += Vector3.right * 0.1f;
        yield return new WaitForSeconds(0.7f);
        myStatus.Hit = false;
    }

    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (hitbox.tag == "Hitbox")
        {
            Debug.Log("hi");
            //Player Hitboxes
            #region PlayerAttacks
            //Neutral
            if (hitbox.gameObject.name == "NA")
            {
                Debug.Log("boss Hit");
                StartCoroutine(hit());
                myStatus.HP -= Damages.Neutral;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Forward Tilt
            if (hitbox.gameObject.name == "ForwardTilt")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.ForwardTilt;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Up Tilt
            if (hitbox.gameObject.name == "UpTilt")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.UpTilt;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Down Tilt
            if (hitbox.gameObject.name == "DownTilt")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.DownTilt;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Neutral Air
            if (hitbox.gameObject.name == "Nair")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.NeutralAir;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Forward Air
            if (hitbox.gameObject.name == "Fair")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.ForwardAir;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Back Air
            if (hitbox.gameObject.name == "Bair")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.BackAir;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Up Air
            if (hitbox.gameObject.name == "Uair")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.UpAir;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }

            //Down Air
            if (hitbox.gameObject.name == "Dair")
            {
                StartCoroutine(hit());
                myStatus.HP -= Damages.DownAir;

                if (!source.isPlaying)
                    source.PlayOneShot(hitSound);
            }
            #endregion


        }
    }
    
}
