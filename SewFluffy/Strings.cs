using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings
{
    #region strings
    public static string[] srowtop1 = new string[] { "Q", "W", "E", "R", "T" };
    public static string[] srowtop2 = new string[] { "Y", "U", "I", "O", "P" };
    public static string[] sAll = new string[] { "1", "2", "3", "4", "5", "Q", "W", "E", "R", "T",
                                                    "6", "7", "8", "9", "0", "Y", "U", "I", "O", "P",
                                                    "A", "S", "D", "F", "Z", "X", "C", "V",
                                                    "H", "J", "K", "L", "G", "B", "N", "M"
                                                };
    public static string[] seAll = new string[] { "3","4","5","E","R","T",
                                                    "6","7","8","9","Y","U","I",
                                                    "S","G","D","F","X","C","V",
                                                    "H","J","K","B","N","M" };

    #endregion


    #region keycodes
    //5
    public static KeyCode[] krowtop1 = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T };
    //5
    public static KeyCode[] krowtop2 = new KeyCode[] { KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P };
    //36 - 10, 10, 8, 8
    public static KeyCode[] kAll = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T,
                                                    KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P,
                                                    KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V,
                                                    KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.G, KeyCode.B, KeyCode.N, KeyCode.M
                                                 };
    //26 - 6, 7, 7, 6
    public static KeyCode[] keAll = new KeyCode[] { KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.E, KeyCode.R, KeyCode.T,
                                                    KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Y, KeyCode.U, KeyCode.I,
                                                    KeyCode.S, KeyCode.G, KeyCode.D, KeyCode.F, KeyCode.X, KeyCode.C, KeyCode.V,
                                                    KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.B, KeyCode.N, KeyCode.M };

    #endregion
    
}
