using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManager : MonoBehaviour
{
    //Controller Stuffs
    public Vector2 controllerMovement;

    private bool Abutton; //0
    private bool Bbutton; //1
    private bool Xbutton; //2
    private bool Ybutton; //3
    private bool start; //7
    
    public bool AButton { get => Abutton; }
    public bool BButton { get => Bbutton; }
    public bool XButton { get => Xbutton; }
    public bool YButton { get => Ybutton; }
    public bool Start { get => start; }

    // Update is called once per frame
    void Update()
    {
        //Controller Joystick Axis
        controllerMovement.x = Input.GetAxis("Horizontal");
        controllerMovement.y = Input.GetAxis("Vertical");

        //Controller Button True (positive?)
        Abutton = Input.GetButtonDown("Button A");
        Bbutton = Input.GetButtonDown("Button B");
        Xbutton = Input.GetButtonDown("Button X");
        Ybutton = Input.GetButtonDown("Button Y");
        start = Input.GetButtonDown("Start");
    }
}
