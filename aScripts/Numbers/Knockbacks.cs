using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Knockbacks
{
    //player
    private static float neutral = 2;
    private static float forwardTilt = 7;
    private static float downTilt = 6;
    private static float upTilt = 10;
    private static float neutralAir = 4;
    private static float forwardAir = 6;
    private static float backAir = 6;
    private static float downAir = 8;
    private static float upAir = 10;

    //enemies
    private static float hug = 15;
    private static float headbutt = 10;
    private static float leftArm = 10;
    private static float rightArm = 10;
    private static float laserPoint = 7;
    private static float horn = 1;


    //player
    public static float Neutral { get => neutral; }
    public static float ForwardTilt { get => forwardTilt; }
    public static float DownTilt { get => downTilt; }
    public static float UpTilt { get => upTilt; }
    public static float NeutralAir { get => neutralAir; }
    public static float ForwardAir { get => forwardAir; }
    public static float BackAir { get => backAir; }
    public static float DownAir { get => downAir; }
    public static float UpAir { get => upAir; }

    //enemies
    public static float Hug { get => hug; }
    public static float Headbutt { get => headbutt; }
    public static float LeftArm { get => leftArm; }
    public static float RightArm { get => rightArm; }
    public static float LaserPoint { get => laserPoint; }
    public static float Horn { get => horn; }
}
