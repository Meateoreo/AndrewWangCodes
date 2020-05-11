using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys
{
    [SerializeField] private static KeyCode a = KeyCode.Z;
    [SerializeField] private static KeyCode b = KeyCode.X;

    [SerializeField] private static KeyCode left = KeyCode.LeftArrow;
    [SerializeField] private static KeyCode right = KeyCode.RightArrow;
    [SerializeField] private static KeyCode up = KeyCode.UpArrow;
    [SerializeField] private static KeyCode down = KeyCode.DownArrow;


    [SerializeField] private static KeyCode menu = KeyCode.Escape;
    [SerializeField] private static KeyCode robotMenu = KeyCode.LeftControl;


    public static KeyCode A { get => a; }
    public static KeyCode B { get => b; }
    public static KeyCode Left { get => left; }
    public static KeyCode Right { get => right; }
    public static KeyCode Up { get => up; }
    public static KeyCode Down { get => down; }

    public static KeyCode Menu { get => menu; }
    public static KeyCode RobotMenu { get => robotMenu; }


}
