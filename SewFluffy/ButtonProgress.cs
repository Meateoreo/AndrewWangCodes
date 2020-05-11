using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonProgress : MonoBehaviour
{
    public GameObject hold;

    public void StitchClick()
    {
        print(hold.GetComponent<WolfSeq>().seq);
        hold.GetComponent<WolfSeq>().seq = hold.GetComponent<WolfSeq>().seq+1;
        print(hold.GetComponent<WolfSeq>().seq);
        this.gameObject.SetActive(false);
    }
}
