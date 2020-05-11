using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTagPlacement : MonoBehaviour
{
    [SerializeField] private Text tag;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 tagPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        tag.transform.position = tagPosition;
    }
}
