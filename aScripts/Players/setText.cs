using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour
{
    public Text text;
    [SerializeField] private Status myStatus;

    // Start is called before the first frame update
    void Start()
    {
        text.text = myStatus.HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = myStatus.HP.ToString();
    }
}
