using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatDisappear : MonoBehaviour
{
    public Text myText;

    public float disappearTime;
    public float timeFactor;
    
    private void Start()
    {
        Destroy(this.gameObject, disappearTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * timeFactor;
    }
}
