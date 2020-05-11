using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBattleFieldPositions : MonoBehaviour
{
    [SerializeField] private Transform fighter;
    [SerializeField] private int place;

    public float yValue;
    public float yValue2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(place)
        {
            case 1:
                transform.position = fighter.transform.position + new Vector3(0,yValue);
                break;
            case 2:
                transform.position = fighter.transform.position;
                break;
            case 3:
                transform.position = fighter.transform.position + new Vector3(0,-yValue2);
                break;

        }
    }
}
