using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPGet : MonoBehaviour
{
    [SerializeField] private Status myStatus; //script from above object

    // Start is called before the first frame update
    void Awake()
    {
        myStatus = GetComponent<Status>();

        if (this.gameObject.tag == "thePlayer")
        {
            myStatus.HP = Globals.PlayerHP;
            myStatus.MaxHP = Globals.PlayerHP;
        }

        if (this.gameObject.tag == "miniBear")
        {
            myStatus.HP = Globals.MiniBearHP;
            myStatus.MaxHP = Globals.MiniBearHP;
        }

        if (this.gameObject.tag == "raBBIT")
        {
            myStatus.HP = Globals.RaBBIT;
            myStatus.MaxHP = Globals.RaBBIT;
        }

        if (this.gameObject.tag == "Unicorn")
        {
            myStatus.HP = Globals.Unicorn;
            myStatus.MaxHP = Globals.Unicorn;
        }

        if (this.gameObject.tag == "Boss")
        {
            myStatus.HP = Globals.Boss;
            myStatus.MaxHP = Globals.Boss;
        }
    }
    
}
