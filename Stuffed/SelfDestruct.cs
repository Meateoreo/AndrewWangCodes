using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public int timer;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(50, 100);
        rb.velocity = Vector2.up * Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        --timer;

        if (timer <= 0)
            Destroy(this.gameObject);

        rb.velocity += Vector2.right * Random.Range(0, 2);
        rb.velocity += Vector2.left * Random.Range(0, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            StartCoroutine(destroying());
    }

    IEnumerator destroying()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
