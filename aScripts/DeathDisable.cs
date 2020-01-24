using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDisable : MonoBehaviour
{
    [SerializeField] private Status myStatus;
    [SerializeField] private miniBearMovement miniBearMovement;
    [SerializeField] private raBBITMovement raBBITMovement;
    [SerializeField] private UniAI uniAI;

    [SerializeField] private bool dead;


    // Start is called before the first frame update
    void Start()
    {
        dead = myStatus.Dead;
    }

    // Update is called once per frame
    void Update()
    {
        dead = myStatus.Dead;

        if (dead)
        {
            if (miniBearMovement != null)
                miniBearMovement.enabled = false;
            if (raBBITMovement != null)
                raBBITMovement.enabled = false;
            if (uniAI != null)
                uniAI.enabled = false;

            StartCoroutine(Delete());
        }
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
