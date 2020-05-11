using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFight : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera thisCamera;

    [SerializeField] private CameraFollow Follow;
    [SerializeField] private CameraFollowSimple FollowSimple;

    [SerializeField] private GameObject LeftWall;
    [SerializeField] private GameObject RightWall;

    [SerializeField] private GameObject ShowUI;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float totalHP;

    [SerializeField] private GameObject HealBlock;
    [SerializeField] private int dropped;

    private void Start()
    {
        totalHP = CheckEnemyHp(enemies);
        dropped = Random.Range(1, 3);

        foreach (GameObject enemy in enemies)
            enemy.SetActive(false);

    }

    private void FixedUpdate()
    {
        totalHP = CheckEnemyHp(enemies);


        if (totalHP <= 0)
        {
            StartCoroutine(Free());
            if (dropped > 0)
            {
                --dropped;

                StartCoroutine(HealDrop());
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "thePlayer")
        {
            Debug.Log("hi");
            /*
            thisCamera.GetComponent<Camera>().enabled = true;
            MainCamera.GetComponent<Camera>().enabled = false;
            */
            //MainCamera.transform.position = transform.position;
            //Follow.enabled = false;
            //FollowSimple.enabled = true;

            foreach (GameObject enemy in enemies)
                enemy.SetActive(true);

            LeftWall.SetActive(true);
            RightWall.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            ShowUI.SetActive(true);
        }
    }

    float CheckEnemyHp(GameObject[] enemies)
    {
        float totalHp = 0;

        foreach (GameObject enemy in enemies)
            totalHp += enemy.GetComponent<Status>().HP;

        return totalHp;
    }

    IEnumerator Free()
    {
        yield return new WaitForSeconds(2f);
        /*
        MainCamera.GetComponent<Camera>().enabled = true;
        thisCamera.GetComponent<Camera>().enabled = false;
        */
        //Follow.enabled = true;
        //FollowSimple.enabled = false;

        LeftWall.SetActive(false);
        RightWall.SetActive(false);
    }

    IEnumerator HealDrop()
    {
        yield return new WaitForSeconds(1f);
        GameObject block;
        block = Instantiate(HealBlock, transform.position, transform.rotation);

        block.GetComponent<Rigidbody2D>().velocity = Vector3.up;
    }
}
