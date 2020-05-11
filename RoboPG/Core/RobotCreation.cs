using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatesManager;

public class RobotCreation : MonoBehaviour
{
    private GameObject Manager;
    [SerializeField] private PlayState pState;

    [SerializeField] private List<GameObject> myRobots;
    public List<GameObject> MyRobots { get => myRobots; set => myRobots = value; }

    #region part stuffs
    [SerializeField] private GameObject bothead;
    [SerializeField] private GameObject botbody;
    [SerializeField] private GameObject botlegs;

    #region bot1
    [SerializeField] private GameObject bot1head;
    [SerializeField] private GameObject bot1body;
    [SerializeField] private GameObject bot1legs;

    private GameObject cur1head;
    private GameObject cur1body;
    private GameObject cur1legs;

    [SerializeField] private GameObject bot1headon;
    [SerializeField] private GameObject bot1bodyon;
    [SerializeField] private GameObject bot1legson;

    #endregion

    #region bot2
    [SerializeField] private GameObject bot2head;
    [SerializeField] private GameObject bot2body;
    [SerializeField] private GameObject bot2legs;

    private GameObject cur2head;
    private GameObject cur2body;
    private GameObject cur2legs;

    [SerializeField] private GameObject bot2headon;
    [SerializeField] private GameObject bot2bodyon;
    [SerializeField] private GameObject bot2legson;
    #endregion

    #region bot3
    [SerializeField] private GameObject bot3head;
    [SerializeField] private GameObject bot3body;
    [SerializeField] private GameObject bot3legs;

    private GameObject cur3head;
    private GameObject cur3body;
    private GameObject cur3legs;

    [SerializeField] private GameObject bot3headon;
    [SerializeField] private GameObject bot3bodyon;
    [SerializeField] private GameObject bot3legson;
    #endregion

    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;

    [SerializeField] private GameObject textAll;

    [SerializeField] private Text headAmount;
    [SerializeField] private Text bodyAmount;
    [SerializeField] private Text legAmount;

    [SerializeField] private Text HPValue;
    [SerializeField] private Text powerValue;
    [SerializeField] private Text speedValue;

    [SerializeField] public List<GameObject> headList;
    [SerializeField] public List<GameObject> bodyList;
    [SerializeField] public List<GameObject> legList;
    #endregion

    public int curRobot;
    //private bool resetting;

    public Transform parts;

    /*
    public GameObject[] HeadList { get => headList; set => headList = value; }
    public GameObject[] BodyList { get => bodyList; set => bodyList = value; }
    public GameObject[] LegList { get => legList; set => legList = value; }
    */
    public int headIndex;
    public int bodyIndex;
    public int legIndex;

    //public GameObject moneyText;
    public int moneys;

    public GameObject hpBar;
    public GameObject powerBar;
    public GameObject speedBar;


    void Start()
    {
        moneys = 0;
        Manager = GameObject.Find("Manager");
        //resetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            moneys += 100;
        }

        //moneyText.GetComponent<Text>().text = moneys + " Gears";


        //editor sprites
        if (headList.Count > 0)
        bothead.GetComponent<Image>().sprite = headList[headIndex].GetComponent<PartStats>().mySprite;
        if (bodyList.Count > 0)
            botbody.GetComponent<Image>().sprite = bodyList[bodyIndex].GetComponent<PartStats>().mySprite;
        if (legList.Count > 0)
            botlegs.GetComponent<Image>().sprite = legList[legIndex].GetComponent<PartStats>().mySprite;


        #region pics for sprites    
        //bot1
        
        if (myRobots[0].transform.GetChild(0).GetComponent<PartStats>().Type == "Head")
            cur1head = myRobots[0].transform.GetChild(0).gameObject;
        else if (myRobots[0].transform.GetChild(0).GetComponent<PartStats>().Type == "Body")
            cur1body = myRobots[0].transform.GetChild(0).gameObject;
        else if (myRobots[0].transform.GetChild(0).GetComponent<PartStats>().Type == "Legs")
            cur1legs = myRobots[0].transform.GetChild(0).gameObject;


        if (myRobots[0].transform.GetChild(1).GetComponent<PartStats>().Type == "Head")
            cur1head = myRobots[0].transform.GetChild(1).gameObject;
        else if (myRobots[0].transform.GetChild(1).GetComponent<PartStats>().Type == "Body")
            cur1body = myRobots[0].transform.GetChild(1).gameObject;
        else if (myRobots[0].transform.GetChild(1).GetComponent<PartStats>().Type == "Legs")
            cur1legs = myRobots[0].transform.GetChild(1).gameObject;

        if (myRobots[0].transform.GetChild(2).GetComponent<PartStats>().Type == "Head")
            cur1head = myRobots[0].transform.GetChild(2).gameObject;
        else if (myRobots[0].transform.GetChild(2).GetComponent<PartStats>().Type == "Body")
            cur1body = myRobots[0].transform.GetChild(2).gameObject;
        else if (myRobots[0].transform.GetChild(2).GetComponent<PartStats>().Type == "Legs")
            cur1legs = myRobots[0].transform.GetChild(2).gameObject;


        bot1head.GetComponent<Image>().sprite = cur1head.GetComponent<PartStats>().mySprite;
        bot1body.GetComponent<Image>().sprite = cur1body.GetComponent<PartStats>().mySprite;
        bot1legs.GetComponent<Image>().sprite = cur1legs.GetComponent<PartStats>().mySprite;
        
        //bot2
        if (myRobots[1].transform.GetChild(0).GetComponent<PartStats>().Type == "Head")
            cur2head = myRobots[1].transform.GetChild(0).gameObject;
        else if (myRobots[1].transform.GetChild(0).GetComponent<PartStats>().Type == "Body")
            cur2body = myRobots[1].transform.GetChild(0).gameObject;
        else if (myRobots[1].transform.GetChild(0).GetComponent<PartStats>().Type == "Legs")
            cur2legs = myRobots[1].transform.GetChild(0).gameObject;


        if (myRobots[1].transform.GetChild(1).GetComponent<PartStats>().Type == "Head")
            cur2head = myRobots[1].transform.GetChild(1).gameObject;
        else if (myRobots[1].transform.GetChild(1).GetComponent<PartStats>().Type == "Body")
            cur2body = myRobots[1].transform.GetChild(1).gameObject;
        else if (myRobots[1].transform.GetChild(1).GetComponent<PartStats>().Type == "Legs")
            cur2legs = myRobots[1].transform.GetChild(1).gameObject;

       // print(myRobots[1].transform.GetChild(2).tag);

        if (myRobots[1].transform.GetChild(2).GetComponent<PartStats>().Type == "Head")
            cur2head = myRobots[1].transform.GetChild(2).gameObject;
        else if (myRobots[1].transform.GetChild(2).GetComponent<PartStats>().Type == "Body")
            cur2body = myRobots[1].transform.GetChild(2).gameObject;
        else if (myRobots[1].transform.GetChild(2).GetComponent<PartStats>().Type == "Legs")
            cur2legs = myRobots[1].transform.GetChild(2).gameObject;

        bot2head.GetComponent<Image>().sprite = cur2head.GetComponent<PartStats>().mySprite;
        bot2body.GetComponent<Image>().sprite = cur2body.GetComponent<PartStats>().mySprite;
        bot2legs.GetComponent<Image>().sprite = cur2legs.GetComponent<PartStats>().mySprite;


        //bot3
        if (myRobots[2].transform.GetChild(0).GetComponent<PartStats>().Type == "Head")
            cur3head = myRobots[2].transform.GetChild(0).gameObject;
        else if (myRobots[2].transform.GetChild(0).GetComponent<PartStats>().Type == "Body")
            cur3body = myRobots[2].transform.GetChild(0).gameObject;
        else if (myRobots[2].transform.GetChild(0).GetComponent<PartStats>().Type == "Legs")
            cur3legs = myRobots[2].transform.GetChild(0).gameObject;


        if (myRobots[2].transform.GetChild(1).GetComponent<PartStats>().Type == "Head")
            cur3head = myRobots[2].transform.GetChild(1).gameObject;
        else if (myRobots[2].transform.GetChild(1).GetComponent<PartStats>().Type == "Body")
            cur3body = myRobots[2].transform.GetChild(1).gameObject;
        else if (myRobots[2].transform.GetChild(1).GetComponent<PartStats>().Type == "Legs")
            cur3legs = myRobots[2].transform.GetChild(1).gameObject;

        if (myRobots[2].transform.GetChild(2).GetComponent<PartStats>().Type == "Head")
            cur3head = myRobots[2].transform.GetChild(2).gameObject;
        else if (myRobots[2].transform.GetChild(2).GetComponent<PartStats>().Type == "Body")
            cur3body = myRobots[2].transform.GetChild(2).gameObject;
        else if (myRobots[2].transform.GetChild(2).GetComponent<PartStats>().Type == "Legs")
            cur3legs = myRobots[2].transform.GetChild(2).gameObject;

        bot3head.GetComponent<Image>().sprite = cur3head.GetComponent<PartStats>().mySprite;
        bot3body.GetComponent<Image>().sprite = cur3body.GetComponent<PartStats>().mySprite;
        bot3legs.GetComponent<Image>().sprite = cur3legs.GetComponent<PartStats>().mySprite;

        //on field sprites
        bot1headon.GetComponent<SpriteRenderer>().sprite = cur1head.GetComponent<PartStats>().mySprite;
        bot1bodyon.GetComponent<SpriteRenderer>().sprite = cur1body.GetComponent<PartStats>().mySprite;
        bot1legson.GetComponent<SpriteRenderer>().sprite = cur1legs.GetComponent<PartStats>().mySprite;
        bot2headon.GetComponent<SpriteRenderer>().sprite = cur2head.GetComponent<PartStats>().mySprite;
        bot2bodyon.GetComponent<SpriteRenderer>().sprite = cur2body.GetComponent<PartStats>().mySprite;
        bot2legson.GetComponent<SpriteRenderer>().sprite = cur2legs.GetComponent<PartStats>().mySprite;
        bot3headon.GetComponent<SpriteRenderer>().sprite = cur3head.GetComponent<PartStats>().mySprite;
        bot3bodyon.GetComponent<SpriteRenderer>().sprite = cur3body.GetComponent<PartStats>().mySprite;
        bot3legson.GetComponent<SpriteRenderer>().sprite = cur3legs.GetComponent<PartStats>().mySprite;

        #endregion

        float totalHP = 1;
        float totalPower = 1;
        float totalSpeed = 1;

        if (headList.Count > 0 && bodyList.Count > 0 && legList.Count > 0)
        {
            text1.GetComponent<Text>().text = "Hp: " + headList[headIndex].GetComponent<PartStats>().HP +
                                                "\nPower: " + headList[headIndex].GetComponent<PartStats>().Power +
                                                "\nSpeed: " + headList[headIndex].GetComponent<PartStats>().Speed +
                                                "\nAttack: " + headList[headIndex].GetComponent<PartStats>().AttackName;


            totalHP = 100 + headList[headIndex].GetComponent<PartStats>().HP + bodyList[bodyIndex].GetComponent<PartStats>().HP + legList[legIndex].GetComponent<PartStats>().HP;

            if (totalHP < 0)
                totalHP = 1;
        
            text2.GetComponent<Text>().text = "Hp: " + bodyList[bodyIndex].GetComponent<PartStats>().HP +
                                                "\nPower: " + bodyList[bodyIndex].GetComponent<PartStats>().Power +
                                                "\nSpeed: " + bodyList[bodyIndex].GetComponent<PartStats>().Speed +
                                                "\nAttack: " + bodyList[bodyIndex].GetComponent<PartStats>().AttackName;

            totalPower = 10 + headList[headIndex].GetComponent<PartStats>().Power + bodyList[bodyIndex].GetComponent<PartStats>().Power + legList[legIndex].GetComponent<PartStats>().Power;

            if (totalPower < 0)
                totalPower = 1;
        
            text3.GetComponent<Text>().text = "Hp: " + legList[legIndex].GetComponent<PartStats>().HP +
                                                "\nPower: " + legList[legIndex].GetComponent<PartStats>().Power +
                                                "\nSpeed: " + legList[legIndex].GetComponent<PartStats>().Speed +
                                                "\nAttack: " + legList[legIndex].GetComponent<PartStats>().AttackName;

            totalSpeed = 100 + headList[headIndex].GetComponent<PartStats>().Speed + bodyList[bodyIndex].GetComponent<PartStats>().Speed + legList[legIndex].GetComponent<PartStats>().Speed;

            if (totalSpeed < 0)
                totalSpeed = 1;
        }


        string attackList = "";


        if (headList.Count > 0 && headList[headIndex].GetComponent<PartStats>().AttackName != "None")
        {
            attackList += headList[headIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(headList[headIndex].GetComponent<PartStats>().AttackName)] + "\n\n";

            if (bodyList.Count > 0 && bodyList[bodyIndex].GetComponent<PartStats>().AttackName != "None")
            {
                attackList += bodyList[bodyIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(bodyList[bodyIndex].GetComponent<PartStats>().AttackName)] + "\n\n";

                if (legList.Count > 0 && legList[legIndex].GetComponent<PartStats>().AttackName != "None")
                    attackList += legList[legIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(legList[legIndex].GetComponent<PartStats>().AttackName)];
            }
            else if (legList.Count > 0 && legList[legIndex].GetComponent<PartStats>().AttackName != "None")
                attackList += legList[legIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(legList[legIndex].GetComponent<PartStats>().AttackName)];
        }
        else if (headList.Count > 0 && bodyList.Count > 0 && 
            bodyList[bodyIndex].GetComponent<PartStats>().AttackName != "None" && 
            headList[headIndex].GetComponent<PartStats>().AttackName == "None")
        {
            attackList += bodyList[bodyIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(bodyList[bodyIndex].GetComponent<PartStats>().AttackName)];

            if (legList.Count > 0 &&  legList[legIndex].GetComponent<PartStats>().AttackName != "None")
                attackList += legList[legIndex].GetComponent<PartStats>().AttackName + ":  " + Manager.GetComponent<AttackList>().Description[Manager.GetComponent<AttackList>().getAttackInfo(legList[legIndex].GetComponent<PartStats>().AttackName)];
        }
        else if (headList.Count > 0 && bodyList.Count > 0 && legList.Count > 0 &&
            legList[legIndex].GetComponent<PartStats>().AttackName != "None" && 
            headList[headIndex].GetComponent<PartStats>().AttackName == "None" && 
            bodyList[bodyIndex].GetComponent<PartStats>().AttackName == "None")
            attackList += legList[legIndex].GetComponent<PartStats>().AttackName;
        else
            attackList = "None";


        #region TextStuffs

        textAll.GetComponent<Text>().text = attackList;
        
        hpBar.transform.localScale = new Vector3(hpBar.transform.localScale.x, totalHP/1500, hpBar.transform.localScale.z);
        powerBar.transform.localScale = new Vector3(powerBar.transform.localScale.x, totalPower / 400, powerBar.transform.localScale.z);
        speedBar.transform.localScale = new Vector3(speedBar.transform.localScale.x, totalSpeed / 500, speedBar.transform.localScale.z);

        HPValue.text = totalHP.ToString();
        powerValue.text = totalPower.ToString();
        speedValue.text = totalSpeed.ToString();

        headAmount.text = headIndex + 1 + "  |  " + headList.Count;
        bodyAmount.text = bodyIndex + 1 + "  |  " + bodyList.Count;
        legAmount.text = legIndex + 1 + "  |  " + legList.Count;
        #endregion
    }

    /*
    #region adds
    public void addHead(GameObject part)
    {
        List <GameObject> temp = new List<GameObject>();

        for (int a = 0; a < headList.Count; a++)
            temp[a] = headList[a];

        temp[temp.Count-1] = part;

        headList = temp;
    }
    public void addBody(GameObject part)
    {
        GameObject[] temp = new GameObject[bodyList.Length + 1];

        for (int a = 0; a < bodyList.Length; a++)
            temp[a] = bodyList[a];

        temp[temp.Length-1] = part;

        bodyList = temp;
    }
    public void addLegs(GameObject part)
    {
        GameObject[] temp = new GameObject[legList.Length + 1];

        for (int a = 0; a < legList.Length; a++)
            temp[a] = legList[a];

        temp[temp.Length-1] = part;

        legList = temp;
    }
#endregion
        */
    /*
#region removes
public void removeHead(int index)
{
    GameObject[] temp = new GameObject[headList.Length - 1];

    for (int r = index; r < headList.Length - 1; r++)
    {
        swap(headList, r, r + 1);
    }

    for (int a = 0; a < temp.Length; a++)
        temp[a] = headList[a];


    headList = temp;
}
public void removeBody(int index)
{
    GameObject[] temp = new GameObject[bodyList.Length - 1];

    for (int r = index; r < bodyList.Length - 1; r++)
    {
        swap(bodyList, r, r + 1);
    }

    for (int a = 0; a < temp.Length; a++)
        temp[a] = bodyList[a];


    bodyList = temp;
}
public void removeLegs(int index)
{
    GameObject[] temp = new GameObject[legList.Length - 1];

    for (int r = index; r < legList.Length - 1; r++)
    {
        swap(legList, r, r + 1);
    }

    for (int a = 0; a < temp.Length; a++)
        temp[a] = legList[a];


    legList = temp;
}
#endregion
    */

    private void swap(GameObject[] array, int a, int b)
    {
        GameObject hold = array[a];
        array[a] = array[b];
        array[b] = hold;
    }

    /*
    public void clearHeadList()
    {
        GameObject[] temp = new GameObject[0];
        headList = temp;
    }
    public void clearBodyList()
    {
        GameObject[] temp = new GameObject[0];
        bodyList = temp;
    }
    public void clearLegList()
    {
        GameObject[] temp = new GameObject[0];
        legList = temp;
    }*/

    /*
    public void resetList()
    {
        resetting = true;
        clearHeadList();
        clearBodyList();
        clearLegList();

        foreach(Transform part in parts)
        {
            part.GetComponent<PartStats>().AddToPartList();
        }

        resetting = false;
    }
    */

    public void AddToPartList(GameObject me)
    {
        if (me.GetComponent<PartStats>().Type == "Head")
        {
            headList.Add(me);
        }

        if (me.GetComponent<PartStats>().Type == "Body")
        {
            bodyList.Add(me);
        }

        if (me.GetComponent<PartStats>().Type == "Legs")
        {
            legList.Add(me);
        }
    }
    public void sellPart(string partType)
    {
        
        switch(partType)
        {
            case "Head":
                if (headList.Count > 1 && headIndex != headList.Count-1)
                {
                    moneys += headList[headIndex].GetComponent<PartStats>().sellPrice;
                    Destroy(headList[headIndex]);
                    headList.RemoveAt(headIndex);
                }
                break;
            case "Body":
                if (bodyList.Count > 1 && bodyIndex != bodyList.Count-1)
                {
                    moneys += bodyList[bodyIndex].GetComponent<PartStats>().sellPrice;
                    Destroy(bodyList[bodyIndex]);
                    bodyList.RemoveAt(bodyIndex);
                }
                break;
            case "Legs":
                if (legList.Count > 1 && legIndex != legList.Count-1)
                {
                    moneys += legList[legIndex].GetComponent<PartStats>().sellPrice;
                    Destroy(legList[legIndex]);
                    legList.RemoveAt(legIndex);
                }
                break;

        }

    }

    #region editButtons
    public void editBot1()
    {
        headList.Add(cur1head);
        bodyList.Add(cur1body);
        legList.Add(cur1legs);

        headIndex = headList.Count - 1;
        bodyIndex = bodyList.Count - 1;
        legIndex = legList.Count - 1;

        Manager.GetComponent<GameState>().ChangeScene(PlayState.ROBOTMENU2);
        curRobot = 1;
    }

    public void editBot2()
    {
        headList.Add(cur2head);
        bodyList.Add(cur2body);
        legList.Add(cur2legs);

        headIndex = headList.Count - 1;
        bodyIndex = bodyList.Count - 1;
        legIndex = legList.Count - 1;

        Manager.GetComponent<GameState>().ChangeScene(PlayState.ROBOTMENU2);
        curRobot = 2;
    }

    public void editBot3()
    {
        headList.Add(cur3head);
        bodyList.Add(cur3body);
        legList.Add(cur3legs);

        headIndex = headList.Count - 1;
        bodyIndex = bodyList.Count - 1;
        legIndex = legList.Count - 1;

        Manager.GetComponent<GameState>().ChangeScene(PlayState.ROBOTMENU2);
        curRobot = 3;
    }
    #endregion

    #region part selection
    public void LastHead()
    {
        if (headList.Count > 1)
        {
            if (headIndex == 0)
                headIndex = headList.Count - 1;
            else
                headIndex--;
        }
    }

    public void NextHead()
    {
        if (headList.Count > 1)
        {
            if (headIndex == headList.Count - 1)
                headIndex = 0;
            else
                headIndex++;
        }
    }

    public void LastBody()
    {

        if (bodyList.Count > 1)
        {
            if (bodyIndex == 0)
                bodyIndex = bodyList.Count - 1;
            else
                bodyIndex--;
        }
    }

    public void NextBody()
    {
        if (bodyList.Count > 1)
        {
            if (bodyIndex == bodyList.Count - 1)
                bodyIndex = 0;
            else
                bodyIndex++;
        }
    }

    public void LastLeg()
    {
        if (legList.Count > 1)
        {
            if (legIndex == 0)
                legIndex = legList.Count - 1;
            else
                legIndex--;
        }
    }

    public void NextLeg()
    {
        if (legList.Count > 1)
        {
            if (legIndex == legList.Count - 1)
                legIndex = 0;
            else
                legIndex++;
        }
    }
    #endregion
}
