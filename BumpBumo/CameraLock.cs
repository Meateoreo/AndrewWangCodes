using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField] private Transform otherPlayer;

    void Update()
    {
        //Debug.Log(name + " -- Before: " + transform.eulerAngles);
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(otherPlayer.transform.position - transform.position, Vector3.up) , Time.deltaTime*2);
        //Debug.Log(name + " -- After: " + transform.eulerAngles);
    }
}
