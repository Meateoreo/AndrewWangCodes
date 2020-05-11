using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private Status playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatus.Hit)
            shakey();
    }

    //move LEFT after a delay
    IEnumerator shakey()
    {
        transform.position += Vector3.up * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.down * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.left * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.position += Vector3.right * 0.1f;
    }
}
