using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTime : MonoBehaviour
{
    //player
    private static int neutral = 30;
    private static int forwardTilt = 30;
    private static int downTilt = 45;
    private static int upTilt = 30;
    private static int neutralAir = 15;
    private static int forwardAir = 30;
    private static int backAir = 15;
    private static int downAir = 30;
    private static int upAir = 45;

    //enemies
    private static int hug = 30;
    private static int headbutt = 15;


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
}
