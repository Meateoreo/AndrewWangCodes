using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    #region strings
    [SerializeField] private string[] stopright = new string[] { "Q", "W", "E", "R", "T", "A", "S" };
    [SerializeField] private string[] stopleft = new string[] { "Y", "U", "I", "O", "P", "G", "H" };
    [SerializeField] private string[] sbottomright = new string[] { "D", "F", "Z", "X", "C", "V" };
    [SerializeField] private string[] sbottomleft = new string[] { "J", "K", "L", "B", "N", "M" };
    [SerializeField] private string[] sall = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    [SerializeField] private string[] srowtop1 = new string[] { "Q", "W", "E", "R", "T" };
    [SerializeField] private string[] srowtop2 = new string[] { "Y", "U", "I", "O", "P" };
    #endregion

    #region keycodes
    [SerializeField] private KeyCode[] ktopright = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.A, KeyCode.S };
    [SerializeField] private KeyCode[] ktopleft = new KeyCode[] { KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.G, KeyCode.H };
    [SerializeField] private KeyCode[] kbottomright = new KeyCode[] { KeyCode.D, KeyCode.F, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V };
    [SerializeField] private KeyCode[] kbottomleft = new KeyCode[] { KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.B, KeyCode.N, KeyCode.M };
    [SerializeField] private KeyCode[] kall = new KeyCode[] { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };
    [SerializeField] private KeyCode[] krowtop1 = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T };
    [SerializeField] private KeyCode[] krowtop2 = new KeyCode[] { KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P };
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
