using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WolfSeq : MonoBehaviour
{
    public int seq = -1;
    [SerializeField] private int oseq = 0;
    private int i = 0;
    [SerializeField] private GameObject textHolder;
    [SerializeField] private int[] wolfNum;
    [SerializeField] private GameObject[] textObjects;
    [SerializeField] private KeyCode[] keyPresses;
    [SerializeField] private bool[] heldDown;

    #region parts
    public GameObject Face;
    public GameObject Eye1;
    public GameObject Eye2;
    public GameObject Ear;
    public GameObject Leg;

    public GameObject Belly0;
    public GameObject Belly1;
    public GameObject Belly2;
    public GameObject Belly3;

    public GameObject Back10;
    public GameObject Back11;
    public GameObject Back12;

    public GameObject Back20;
    public GameObject Back21;
    public GameObject Back22;

    public GameObject Back30;
    public GameObject Back31;
    public GameObject Back32;
    //
    public GameObject Face1;
    public GameObject Eye11;
    public GameObject Eye21;
    public GameObject Ear1;
    public GameObject Leg1;

    public GameObject Belly01;
    public GameObject Belly11;
    public GameObject Belly21;
    public GameObject Belly31;

    public GameObject Back13;
    public GameObject Back14;
    public GameObject Back15;

    public GameObject Back23;
    public GameObject Back24;
    public GameObject Back25;

    public GameObject Back33;
    public GameObject Back34;
    public GameObject Back35;
    #endregion

    [SerializeField] private GameObject faceBroken;
    [SerializeField] private GameObject faceReady;
    [SerializeField] private GameObject facePatched;
    [SerializeField] private GameObject eye1Broken;
    [SerializeField] private GameObject eye1Ready;
    [SerializeField] private GameObject eye1Patched;
    [SerializeField] private GameObject eye2Broken;
    [SerializeField] private GameObject eye2Ready;
    [SerializeField] private GameObject eye2Patched;
    [SerializeField] private GameObject legBroken;
    [SerializeField] private GameObject legReady;
    [SerializeField] private GameObject legPatched;
    [SerializeField] private GameObject bellyBroken;
    [SerializeField] private GameObject bellyReady;
    [SerializeField] private GameObject bellyPatched;

    [SerializeField] private GameObject StitchMarks1;
    [SerializeField] private GameObject StitchMarks2;
    [SerializeField] private GameObject StitchMarks3;
    [SerializeField] private GameObject StitchMarks4;
    [SerializeField] private GameObject StitchMarks5;
    [SerializeField] private GameObject StitchMarks6;
    [SerializeField] private GameObject StitchMarks7;
    [SerializeField] private GameObject StitchMarks8;
    [SerializeField] private GameObject StitchMarks9;
    [SerializeField] private GameObject StitchMarks10;
    [SerializeField] private GameObject StitchMarks11;
    [SerializeField] private GameObject StitchMarks12;
    [SerializeField] private GameObject StitchMarks13;
    [SerializeField] private GameObject StitchMarks14;
    [SerializeField] private GameObject StitchMarks15;
    [SerializeField] private GameObject StitchMarks16;

    public GameObject button;

    public GameObject instText;
    public GameObject title;

    public GameObject mainCam;
    public GameObject faceCam;
    public GameObject eyeCam;
    public GameObject legCam;
    public GameObject bellyCam;
    public GameObject finCam;


    // Start is called before the first frame update
    void Start()
    {
        textObjects = new GameObject[141];
        keyPresses = new KeyCode[141];
        heldDown = new bool[141];
        wolfNum = new int[141];

        foreach (Transform text in textHolder.transform)
        {
            textObjects[i] = text.gameObject;
            i++;
        }

        GenNums();
        GenStringDisp();

        button.SetActive(false);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            GenNums();

        #region refresh
        //face
        if (checkSame(0, 6))
            GenFace(0);

        //eye1
        if (checkSame(6, 12))
            GenFace(6);

        //eye2
        if (checkSame(12, 20))
            GenLegs(12);

        //ear
        if (checkSame(20, 28))
            GenBelly(20);

        //leg
        if (checkSame(28, 36))
            GenLegs(28);

        //belly
        if (checkSame(36, 44))
            GenBelly(36);
        if (checkSame(44, 52))
            GenBelly(44);
        if (checkSame(52, 60))
            GenBelly(52);
        if (checkSame(60, 68))
            GenBelly(60);

        //back1
        if (checkSame(68, 76))
            GenBelly(68);
        if (checkSame(76, 84))
            GenBelly(76);
        if (checkSame(84, 92))
            GenBelly(84);
        //back2
        if (checkSame(92, 100))
            GenBelly(92);
        if (checkSame(100, 108))
            GenBelly(100);
        if (checkSame(108, 116))
            GenBelly(108);
        //back3
        if (checkSame(116, 124))
            GenBelly(116);
        if (checkSame(124, 132))
            GenBelly(124);
        if (checkSame(132, 140))
            GenBelly(132);

        #endregion

        //hide instruction text
        if (seq == 0)
        {
            title.SetActive(false);
            instText.SetActive(false);
        }

        if(seq == -1)
            button.SetActive(false);

        #region face
        if (Input.GetKey(keyPresses[0]) && Input.GetKey(keyPresses[1]) && Input.GetKey(keyPresses[2]) && seq == 0)
            button.SetActive(true);
        else if (seq == 0)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[3]) && Input.GetKey(keyPresses[4]) && Input.GetKey(keyPresses[5]) && seq == 1)
            button.SetActive(true);
        else if (seq == 1)
            button.SetActive(false);
        //seq
        if (seq == 0)
        {
            faceBroken.SetActive(true);
            faceCam.SetActive(true);
            mainCam.SetActive(false);
            Face.SetActive(true);
            changeVisibility(0, 3, true);
        }
        else
        {
            faceBroken.SetActive(false);
            Face.SetActive(false);
            changeVisibility(0, 3, false);
        }

        if (seq == 1)
        {
            faceReady.SetActive(true);
            faceBroken.SetActive(false);
            Face1.SetActive(true);
            StitchMarks1.SetActive(true);
            changeVisibility(3, 6, true);
        }
        else
        {
            faceReady.SetActive(false);
            Face1.SetActive(false);
            changeVisibility(3, 6, false);

        }

        #endregion

        #region eye1
        if (Input.GetKey(keyPresses[6]) && Input.GetKey(keyPresses[7]) && Input.GetKey(keyPresses[8]) && seq == 2)
            button.SetActive(true);
        else if (seq == 2)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[9]) && Input.GetKey(keyPresses[10]) && Input.GetKey(keyPresses[11]) && seq == 3)
            button.SetActive(true);
        else if (seq == 3)
            button.SetActive(false);
        //seq
        if (seq == 2)
        {
            eyeCam.SetActive(true);
            faceCam.SetActive(false);
            Eye1.SetActive(true);
            StitchMarks2.SetActive(true);
            facePatched.SetActive(true);
            faceReady.SetActive(false);
            changeVisibility(6, 9, true);
        }
        else
        {
            Eye1.SetActive(false);
            changeVisibility(6, 9, false);
        }
        if (seq == 3)
        {
            eye1Broken.SetActive(false);
            Eye11.SetActive(true);
            StitchMarks3.SetActive(true);
            changeVisibility(9, 12, true);
        }
        else
        {
            Eye11.SetActive(false);
            changeVisibility(9, 12, false);
        }

        #endregion

        #region eye2
        if (Input.GetKey(keyPresses[12]) && Input.GetKey(keyPresses[13]) && Input.GetKey(keyPresses[14]) && Input.GetKey(keyPresses[15]) && seq == 4)
            button.SetActive(true);
        else if (seq == 4)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[16]) && Input.GetKey(keyPresses[17]) && Input.GetKey(keyPresses[18]) && Input.GetKey(keyPresses[19]) && seq == 5)
            button.SetActive(true);
        else if (seq == 5)
            button.SetActive(false);
        //seq
        if (seq == 4)
        {
            eye1Ready.SetActive(false);
            eye1Patched.SetActive(true);
            StitchMarks4.SetActive(true);
            Eye2.SetActive(true);
            changeVisibility(12, 16, true);
        }
        else
        {
            Eye2.SetActive(false);
            changeVisibility(12, 16, false);
        }
        if (seq == 5)
        {
            eye2Broken.SetActive(false);
            eye2Ready.SetActive(true);
            StitchMarks5.SetActive(true);
            Eye21.SetActive(true);
            changeVisibility(16, 20, true);
        }
        else
        {
            Eye21.SetActive(false);
            changeVisibility(16, 20, false);
        }
        #endregion
        
        #region ear
        if (Input.GetKey(keyPresses[20]) && Input.GetKey(keyPresses[21]) && Input.GetKey(keyPresses[22]) && Input.GetKey(keyPresses[23]) && seq == 6)
            button.SetActive(true);
        else if (seq == 6)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[24]) && Input.GetKey(keyPresses[25]) && Input.GetKey(keyPresses[26]) && Input.GetKey(keyPresses[27]) && seq == 7)
            button.SetActive(true);
        else if (seq == 7)
            button.SetActive(false);
        //seq
        if (seq == 6)
            Ear.SetActive(true);
        else
            Ear.SetActive(false);
        if (seq == 7)
            Ear1.SetActive(true);
        else
            Ear1.SetActive(false);
        #endregion

        if (seq == 6)
            seq = 8;

        #region leg
        if (Input.GetKey(keyPresses[28]) && Input.GetKey(keyPresses[29]) && Input.GetKey(keyPresses[30]) && Input.GetKey(keyPresses[31]) && seq == 8)
            button.SetActive(true);
        else if (seq == 8)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[32]) && Input.GetKey(keyPresses[33]) && Input.GetKey(keyPresses[34]) && Input.GetKey(keyPresses[35]) && seq == 9)
            button.SetActive(true);
        else if (seq == 9)
            button.SetActive(false);
        //seq
        if (seq == 8)
        {
            eye2Patched.SetActive(true);
            eye2Ready.SetActive(false);
            StitchMarks6.SetActive(true);
            legCam.SetActive(true);
            eyeCam.SetActive(false);
            Leg.SetActive(true);
            changeVisibility(28, 32, true);
        }
        else
        {
            Leg.SetActive(false);
            changeVisibility(28, 32, false);
        }
        if (seq == 9)
        {
            legReady.SetActive(true);
            legBroken.SetActive(false);
            StitchMarks7.SetActive(true);
            Leg1.SetActive(true);
            changeVisibility(32, 36, true);
        }
        else
        {
            Leg1.SetActive(false);
            changeVisibility(32, 36, false);
        }
        #endregion

        #region belly0
        if (Input.GetKey(keyPresses[36]) && Input.GetKey(keyPresses[37]) && Input.GetKey(keyPresses[38]) && Input.GetKey(keyPresses[39]) && seq == 10)
            button.SetActive(true);
        else if (seq == 10)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[40]) && Input.GetKey(keyPresses[41]) && Input.GetKey(keyPresses[42]) && Input.GetKey(keyPresses[43]) && seq == 11)
            button.SetActive(true);
        else if (seq == 11)
            button.SetActive(false);
        //seq
        if (seq == 10)
        {
            legReady.SetActive(false);
            legPatched.SetActive(true);
            StitchMarks8.SetActive(true);
            bellyCam.SetActive(true);
            legCam.SetActive(false);
            Belly0.SetActive(true);
            changeVisibility(36, 40, true);
        }
        else
        {
            Belly0.SetActive(false);
            changeVisibility(36, 40, false);
        }
        if (seq == 11)
        {
            bellyPatched.SetActive(true);
            StitchMarks9.SetActive(true);
            Belly01.SetActive(true);
            changeVisibility(40, 44, true);
        }
        else
        {
            Belly01.SetActive(false);
            changeVisibility(40, 44, false);
        }
        #endregion

        #region belly1
        if (Input.GetKey(keyPresses[44]) && Input.GetKey(keyPresses[45]) && Input.GetKey(keyPresses[46]) && Input.GetKey(keyPresses[47]) && seq == 12)
            button.SetActive(true);
        else if (seq == 12)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[48]) && Input.GetKey(keyPresses[49]) && Input.GetKey(keyPresses[50]) && Input.GetKey(keyPresses[51]) && seq == 13)
            button.SetActive(true);
        else if (seq == 13)
            button.SetActive(false);
        //seq
        if (seq == 12)
        {
            StitchMarks10.SetActive(true);
            Belly1.SetActive(true);
            changeVisibility(44, 48, true);
        }
        else
        {
            Belly1.SetActive(false);
            changeVisibility(44, 48, false);
        }
        if (seq == 13)
        {
            StitchMarks11.SetActive(true);
            Belly11.SetActive(true);
            changeVisibility(48, 52, true);
        }
        else
        {
            Belly11.SetActive(false);
            changeVisibility(48, 52, false);
        }
        #endregion

        #region belly2
        if (Input.GetKey(keyPresses[52]) && Input.GetKey(keyPresses[53]) && Input.GetKey(keyPresses[54]) && Input.GetKey(keyPresses[55]) && seq == 14)
            button.SetActive(true);
        else if (seq == 14)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[56]) && Input.GetKey(keyPresses[57]) && Input.GetKey(keyPresses[58]) && Input.GetKey(keyPresses[59]) && seq == 15)
            button.SetActive(true);
        else if (seq == 15)
            button.SetActive(false);
        //seq
        if (seq == 14)
        {
            StitchMarks12.SetActive(true);
            Belly2.SetActive(true);
            changeVisibility(52, 56, true);
        }
        else
        {
            Belly2.SetActive(false);
            changeVisibility(52, 56, false);
        }
        if (seq == 15)
        {
            StitchMarks13.SetActive(true);
            bellyBroken.SetActive(false);
            Belly21.SetActive(true);
            changeVisibility(56, 60, true);
        }
        else
        {
            Belly21.SetActive(false);
            changeVisibility(56, 60, false);
        }
        #endregion

        #region belly3
        if (Input.GetKey(keyPresses[60]) && Input.GetKey(keyPresses[61]) && Input.GetKey(keyPresses[62]) && Input.GetKey(keyPresses[63]) && seq == 16)
            button.SetActive(true);
        else if (seq == 16)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[64]) && Input.GetKey(keyPresses[65]) && Input.GetKey(keyPresses[66]) && Input.GetKey(keyPresses[67]) && seq == 17)
            button.SetActive(true);
        else if (seq == 17)
            button.SetActive(false);
        //seq
        if (seq == 16)
        {
            StitchMarks14.SetActive(true);
            Belly3.SetActive(true);
            changeVisibility(60, 64, true);
        }
        else
        {
            Belly3.SetActive(false);
            changeVisibility(60, 64, false);
        }
        if (seq == 17)
        {
            StitchMarks15.SetActive(true);
            Belly31.SetActive(true);
            changeVisibility(64, 68, true);
        }
        else
        {
            Belly31.SetActive(false);
            changeVisibility(64, 68, false);
        }
        #endregion

        #region back10
        if (Input.GetKey(keyPresses[68]) && Input.GetKey(keyPresses[69]) && Input.GetKey(keyPresses[70]) && Input.GetKey(keyPresses[71]) && seq == 18)
            button.SetActive(true);
        else if (seq == 18)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[72]) && Input.GetKey(keyPresses[73]) && Input.GetKey(keyPresses[74]) && Input.GetKey(keyPresses[75]) && seq == 19)
            button.SetActive(true);
        else if (seq == 19)
            button.SetActive(false);
        //seq
        if (seq == 18 || seq == 19)
            Back10.SetActive(true);
        else
            Back10.SetActive(false);
        #endregion

        #region back11
        if (Input.GetKey(keyPresses[76]) && Input.GetKey(keyPresses[77]) && Input.GetKey(keyPresses[78]) && Input.GetKey(keyPresses[79]) && seq == 20)
            button.SetActive(true);
        else if (seq == 20)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[80]) && Input.GetKey(keyPresses[81]) && Input.GetKey(keyPresses[82]) && Input.GetKey(keyPresses[83]) && seq == 21)
            button.SetActive(true);
        else if (seq == 21)
            button.SetActive(false);
        //seq
        if (seq == 20 || seq == 21)
            Back11.SetActive(true);
        else
            Back11.SetActive(false);
        #endregion

        #region back12
        if (Input.GetKey(keyPresses[84]) && Input.GetKey(keyPresses[85]) && Input.GetKey(keyPresses[86]) && Input.GetKey(keyPresses[87]) && seq == 22)
            button.SetActive(true);
        else if (seq == 22)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[88]) && Input.GetKey(keyPresses[89]) && Input.GetKey(keyPresses[90]) && Input.GetKey(keyPresses[91]) && seq == 23)
            button.SetActive(true);
        else if (seq == 23)
            button.SetActive(false);
        //seq
        if (seq == 22 || seq == 23)
            Back12.SetActive(true);
        else
            Back12.SetActive(false);
        #endregion

        #region back20
        if (Input.GetKey(keyPresses[92]) && Input.GetKey(keyPresses[93]) && Input.GetKey(keyPresses[94]) && Input.GetKey(keyPresses[95]) && seq == 24)
            button.SetActive(true);
        else if (seq == 24)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[96]) && Input.GetKey(keyPresses[97]) && Input.GetKey(keyPresses[98]) && Input.GetKey(keyPresses[99]) && seq == 25)
            button.SetActive(true);
        else if (seq == 25)
            button.SetActive(false);
        //seq
        if (seq == 24 || seq == 25)
            Back20.SetActive(true);
        else
            Back20.SetActive(false);
        #endregion

        #region back21
        if (Input.GetKey(keyPresses[100]) && Input.GetKey(keyPresses[101]) && Input.GetKey(keyPresses[102]) && Input.GetKey(keyPresses[103]) && seq == 26)
            button.SetActive(true);
        else if (seq == 26)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[104]) && Input.GetKey(keyPresses[105]) && Input.GetKey(keyPresses[106]) && Input.GetKey(keyPresses[107]) && seq == 27)
            button.SetActive(true);
        else if (seq == 27)
            button.SetActive(false);
        //seq
        if (seq == 26 || seq == 27)
            Back21.SetActive(true);
        else
            Back21.SetActive(false);
        #endregion

        #region back22
        if (Input.GetKey(keyPresses[108]) && Input.GetKey(keyPresses[109]) && Input.GetKey(keyPresses[110]) && Input.GetKey(keyPresses[111]) && seq == 28)
            button.SetActive(true);
        else if (seq == 28)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[112]) && Input.GetKey(keyPresses[113]) && Input.GetKey(keyPresses[114]) && Input.GetKey(keyPresses[115]) && seq == 29)
            button.SetActive(true);
        else if (seq == 29)
            button.SetActive(false);
        //seq
        if (seq == 28 || seq == 29)
            Back22.SetActive(true);
        else
            Back22.SetActive(false);
        #endregion

        #region back30
        if (Input.GetKey(keyPresses[116]) && Input.GetKey(keyPresses[117]) && Input.GetKey(keyPresses[118]) && Input.GetKey(keyPresses[119]) && seq == 30)
            button.SetActive(true);
        else if (seq == 30)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[120]) && Input.GetKey(keyPresses[121]) && Input.GetKey(keyPresses[122]) && Input.GetKey(keyPresses[123]) && seq == 31)
            button.SetActive(true);
        else if (seq == 31)
            button.SetActive(false);
        //seq
        if (seq == 30 || seq == 31)
            Back30.SetActive(true);
        else
            Back30.SetActive(false);
        #endregion

        #region back31
        if (Input.GetKey(keyPresses[124]) && Input.GetKey(keyPresses[125]) && Input.GetKey(keyPresses[126]) && Input.GetKey(keyPresses[127]) && seq == 32)
            button.SetActive(true);
        else if (seq == 32)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[128]) && Input.GetKey(keyPresses[129]) && Input.GetKey(keyPresses[130]) && Input.GetKey(keyPresses[131]) && seq == 33)
            button.SetActive(true);
        else if (seq == 33)
            button.SetActive(false);
        //seq
        if (seq == 32 || seq == 33)
            Back31.SetActive(true);
        else
            Back31.SetActive(false);
        #endregion

        #region back32
        if (Input.GetKey(keyPresses[132]) && Input.GetKey(keyPresses[133]) && Input.GetKey(keyPresses[134]) && Input.GetKey(keyPresses[135]) && seq == 34)
            button.SetActive(true);
        else if (seq == 34)
            button.SetActive(false);

        if (Input.GetKey(keyPresses[136]) && Input.GetKey(keyPresses[137]) && Input.GetKey(keyPresses[138]) && Input.GetKey(keyPresses[139]) && seq == 35)
            button.SetActive(true);
        else if (seq == 35)
            button.SetActive(false);
        //seq
        if (seq == 34 || seq == 35)
            Back32.SetActive(true);
        else
            Back32.SetActive(false);
        #endregion

        if (seq == 18)
        {
            StitchMarks16.SetActive(true);
            StartCoroutine(done());
        }


    }

    IEnumerator done()
    {
        yield return new WaitForSeconds(3f);
        finCam.SetActive(true);
        bellyCam.SetActive(false);
    }

    private void changeVisibility(int lowIndex, int highIndex, bool visible)
    {
        for (int v = lowIndex; v < highIndex; v++)
            textObjects[v].SetActive(visible);

    }


    private bool checkSame(int lowIndex, int highIndex)
    {
        int current = lowIndex;

        for (int c = current; c < highIndex; c++)
        {
            for (int d = c+1; d < highIndex; d++)
            {
                if (wolfNum[c] == wolfNum[d])
                {
                    print(wolfNum[c] + " == " + wolfNum[d]);
                    return true;
                }
            }
        }
        return false;
    }

    private bool checkHeld(int lowIndex, int highIndex)
    {
        for(int i = lowIndex; i < highIndex+1; i++)
        {
            if (!heldDown[i])
                return true;
        }
        return false;
    }

    private void GenNums()
    {
        //print(repeated++);

        #region indexi
        /*
         * 6 face-6 3x2 
         *    (0, 1, 2)
         *    (3, 4, 5)
         * 6 eye-12 3x2 
         *    (6, 7, 8)
         *    (9, 10, 11)
         * 8 eye-20 
         *    (12, 13, 14, 15)
         *    (16, 17, 18, 19)
         * 8 ear-28 
         *    (20, 21, 22, 23)
         *    (24, 25, 26, 27)
         * 8 leg-36 
         *    (28, 29, 30, 31)
         *    (32, 33, 34, 35)
         * 32 belly-68 8x4 
         *    (36, 37, 38, 39) 
         *    (40, 41, 42, 43)
         *    (44, 45, 46, 47)
         *    (48, 49, 50, 51)
         *    (52, 53, 54, 55)
         *    (56, 57, 58, 59)
         *    (60, 61, 62, 63)
         *    (64, 65, 66, 67)
         * 24 back.1-92 8x3
         *    (68, 69, 70, 71)
         *    (72, 73, 74, 75)
         *    (76, 77, 78, 79)
         *    (80, 81, 82, 83)
         *    (84, 85, 86, 87)
         *    (88, 89, 90, 91)
         * 24 back.2-116 8x3
         *    (92, 93, 94, 95)
         *    (96, 97, 98, 99)
         *    (100, 101, 102, 103)
         *    (104, 105, 106, 107)
         *    (108, 109, 110, 110)
         *    (112, 113, 114, 115)
         * 24 back.3-140 8x3
         *    (116, 117, 118, 119)
         *    (120, 121, 122, 123)
         *    (124, 125, 126, 127)
         *    (128, 129, 130, 131)
         *    (132, 133, 134, 135)
         *    (136, 137, 138, 139)
         */
        #endregion

        wolfNum = new int[] { Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 26), Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 26),
                                Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 26), Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 26),

                                Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 20), Random.Range(20,26), Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 20), Random.Range(20,26),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),

                                Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 20), Random.Range(20,26), Random.Range(0, 6), Random.Range(6, 13), Random.Range(13, 20), Random.Range(20,26),

                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),

                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),

                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),

                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                                Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36), Random.Range(0, 10), Random.Range(10, 20), Random.Range(20, 28), Random.Range(28, 36),
                          };

        

    }
    private void GenFace(int firstIndex)
    {
        //print(repeated++);
        wolfNum[firstIndex] = Random.Range(0, 6);
        wolfNum[firstIndex + 1] = Random.Range(6, 13);
        wolfNum[firstIndex + 2] = Random.Range(13, 26);
        wolfNum[firstIndex + 3] = Random.Range(0, 6);
        wolfNum[firstIndex + 4] = Random.Range(6, 13);
        wolfNum[firstIndex + 5] = Random.Range(13, 26);

        GenStringDisp();
    }

    private void GenLegs(int firstIndex)
    {
        //print(repeated++);
        wolfNum[firstIndex] = Random.Range(0, 6);
        wolfNum[firstIndex+1] = Random.Range(6, 13);
        wolfNum[firstIndex+2] = Random.Range(13, 20);
        wolfNum[firstIndex+3] = Random.Range(20, 26);

        wolfNum[firstIndex+4] = Random.Range(0, 6);
        wolfNum[firstIndex+5] = Random.Range(6, 13);
        wolfNum[firstIndex+6] = Random.Range(13, 20);
        wolfNum[firstIndex+7] = Random.Range(20, 26);

        GenStringDisp();
    }

    private void GenBelly(int firstIndex)
    {
        //print(repeated++);
        wolfNum[firstIndex] = Random.Range(0, 10);
        wolfNum[firstIndex+1] = Random.Range(10, 20);
        wolfNum[firstIndex+2] = Random.Range(20, 28);
        wolfNum[firstIndex+3] = Random.Range(28, 36);
        wolfNum[firstIndex+4] = Random.Range(0, 10);
        wolfNum[firstIndex+5] = Random.Range(10, 20);
        wolfNum[firstIndex+6] = Random.Range(20, 28);
        wolfNum[firstIndex+7] = Random.Range(28, 36);

        GenStringDisp();
    }

    private void GenStringDisp()
    {
        #region text
        for (int a = 0; a < 20; a++)
            textObjects[a].GetComponent<Text>().text = Strings.seAll[wolfNum[a]];
        for (int b = 20; b < 28; b++)
            textObjects[b].GetComponent<Text>().text = Strings.sAll[wolfNum[b]];
        for (int c = 28; c < 36; c++)
            textObjects[c].GetComponent<Text>().text = Strings.seAll[wolfNum[c]];
        for (int d = 36; d < 140; d++)
            textObjects[d].GetComponent<Text>().text = Strings.sAll[wolfNum[d]];
        #endregion

        #region keyPress
        for (int a = 0; a < 20; a++)
            keyPresses[a] = Strings.keAll[wolfNum[a]];
        for (int b = 20; b < 28; b++)
            keyPresses[b] = Strings.kAll[wolfNum[b]];
        for (int c = 28; c < 36; c++)
            keyPresses[c] = Strings.keAll[wolfNum[c]];
        for (int d = 36; d < 140; d++)
            keyPresses[d] = Strings.kAll[wolfNum[d]];
        #endregion
    }

}
