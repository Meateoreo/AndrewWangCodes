using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPartController : MonoBehaviour
{
    [SerializeField] private GameObject robot;
    [SerializeField] private Sprite mySprite;
    [SerializeField] private GameObject Manager;

    public string partPosition;


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (partPosition == "Head")
        {
            mySprite = robot.GetComponent<Stats>().headPart;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = checkHead();

        }

        if (partPosition == "Body")
        {
            mySprite = robot.GetComponent<Stats>().bodyPart;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = checkBody();
        }
    }

    private RuntimeAnimatorController checkHead()
    {
        /*
        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[0])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[0];
        }*/

        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[0])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[1];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[1])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[2];
        }
        
        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[2])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[3];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[3])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[4];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[4])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[5];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().HeadSprites[5])
        {
            return Manager.GetComponent<IMGparts>().animationControllersHead[6];
        }

        return Manager.GetComponent<IMGparts>().animationControllersHead[0];

    }

    private RuntimeAnimatorController checkBody()
    {

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[0])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[1];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[1])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[2];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[2])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[3];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[3])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[4];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[4])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[5];
        }

        if (mySprite == Manager.GetComponent<IMGparts>().BodySprites[5])
        {
            return Manager.GetComponent<IMGparts>().animationControllersBody[6];
        }

        return Manager.GetComponent<IMGparts>().animationControllersBody[0];
    }
}

   
