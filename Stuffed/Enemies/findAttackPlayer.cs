using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findAttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 targetDirection;
    [SerializeField] private Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter");

        targetPosition = player.transform.position;
        targetDirection = targetPosition - transform.position;


        Vector3 diff = targetPosition - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        //newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 1f * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(newDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "thePlayer")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponentInParent<Status>().HP -= Damages.Horn;

            if (transform.position.x > collision.gameObject.transform.position.x)
                collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(1, 0.5f) * Globals.knockbackCalc(Knockbacks.Hug, 0, "medium");

            if (transform.position.x < collision.gameObject.transform.position.x)
                collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(-1, 0.5f) * Globals.knockbackCalc(Knockbacks.Hug, 0, "medium");

            collision.gameObject.GetComponent<HurtBox>().Stunned = 10;
        }

    }
}
