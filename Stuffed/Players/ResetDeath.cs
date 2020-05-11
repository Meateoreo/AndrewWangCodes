using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDeath : MonoBehaviour
{
    //[SerializeField] private 
        public Vector3 deathPosition;
    [SerializeField] private Status myStatus;
    [SerializeField] private HurtBox myHurtBox;

    [SerializeField] private GameObject[] heads;

    private Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        myStatus.Lives = 3;
        alpha = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = alpha;

        if (myStatus.Lives > 0 && myStatus.Dead)
        {
            myHurtBox.Vulnerable = false;
            deathPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            heads[myStatus.Lives - 1].gameObject.SetActive(false);
            myStatus.Lives--;

            if (myStatus.Lives > 0)
            {
                myStatus.resetStatus();
                StopAllCoroutines();
                StartCoroutine(reset());
            }
        }

        if (myStatus.Lives <= 0)
        {

        }
    }

    IEnumerator reset()
    {
        Debug.Log("reset");
        yield return new WaitForSeconds(1f);
        StartCoroutine(flashy());
    }

    IEnumerator flashy()
    {
        Debug.Log("oo");
        transform.position = deathPosition;
        myStatus.resetStatus();
        alpha.a = 0.3f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.9f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.3f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.9f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.3f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.9f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.3f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.9f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 0.3f;
        yield return new WaitForSeconds(0.1f);
        alpha.a = 1f;
        myHurtBox.Vulnerable = true;
    }

}
