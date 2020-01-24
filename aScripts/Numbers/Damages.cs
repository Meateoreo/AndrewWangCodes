using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    //player
    private static int neutral = 2;
    private static int forwardTilt = 8;
    private static int downTilt = 10;
    private static int upTilt = 5;
    private static int neutralAir = 3;
    private static int forwardAir = 8;
    private static int backAir = 5;
    private static int downAir = 10;
    private static int upAir = 5;

    //enemies
    private static int hug = 7;
    private static int headbutt = 5;
    private static int leftArm = 15;
    private static int rightArm = 15;
    private static int laserPoint = 5;
    private static int horn = 3;


    //player
    public static int Neutral { get => neutral; }
    public static int ForwardTilt { get => forwardTilt; }
    public static int DownTilt { get => downTilt; }
    public static int UpTilt { get => upTilt; }
    public static int NeutralAir { get => neutralAir; }
    public static int ForwardAir { get => forwardAir; }
    public static int BackAir { get => backAir; }
    public static int DownAir { get => downAir; }
    public static int UpAir { get => upAir; }

    //enemies
    public static int Hug { get => hug; }
    public static int Headbutt { get => headbutt; }
    public static int LeftArm { get => leftArm; }
    public static int RightArm { get => rightArm; }
    public static int LaserPoint { get => laserPoint; }
    public static int Horn { get => horn; }
}
