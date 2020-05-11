using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatesManager;

public class EnemyController : MonoBehaviour
{
    public int randomize;
    
    [SerializeField] private Sprite[] EnemySprites;
    private GameObject Manager;

    public bool setEnemySprite;

    public StageState sState;

    [SerializeField] private GameObject partHolder;
    [SerializeField] private GameObject newPart;

    [SerializeField] private GameObject itemConfirmIMG;
    [SerializeField] private GameObject itemConfirmText;

    [SerializeField] private int stage;

    public GameObject endScreenStuffs;
    public int Stage { get => stage; set => stage = value; }

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
        stage = 0;
        setEnemySprite = true;
        sState = StageState.SKIRMISH;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage >= 4)
        {
            stage = 3;

            endScreenStuffs.SetActive(true);
        }

        if (Manager.GetComponent<GameState>().pState == PlayState.BATTLE)
        {
            //ARENA 1 Fights
            if (sState == StageState.ARENA)
            {
                switch (stage)
                {
                    case 0:
                        if (!setEnemySprite)
                        {
                            if (Manager.GetComponent<turnManager>().enemies.Count > 0)
                            {
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(300, 50, 180, "Headbutt", "Headbutt", "Headbutt");
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(500, 50, 200, "Headbutt", "Headbutt", "Headbutt");
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(300, 50, 180, "Headbutt", "Headbutt", "Headbutt");
                            }
                            setEnemySprite = true;
                        }
                        break;
                    case 1:
                        if (!setEnemySprite)
                        {
                            if (Manager.GetComponent<turnManager>().enemies.Count > 0)
                            {
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 80, 250, "Headbutt", "SteelGrip", "Headbutt");
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(600, 100, 200, "SteelGrip", "SteelGrip", "Headbutt");
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(500, 80, 250, "Headbutt", "SteelGrip", "Headbutt");
                            }
                            setEnemySprite = true;

                        }
                        break;
                    case 2:
                        if (!setEnemySprite)
                        {
                            if (Manager.GetComponent<turnManager>().enemies.Count > 0)
                            {
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(600, 100, 250, "Headbutt", "SteelGrip", "Headbutt");
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(800, 120, 200, "Headbutt", "SteelGrip", "ThorsBurp");
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(600, 100, 250, "Headbutt", "SteelGrip", "Headbutt");
                            }
                            setEnemySprite = true;

                        }

                        break;
                    case 3:
                        if (!setEnemySprite)
                        {
                            if (Manager.GetComponent<turnManager>().enemies.Count > 0)
                            {
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];
                                Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1000, 200, 200, "Headbutt", "SteelGrip", "TruckCharge");
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[10];
                                Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 250, 300, "PistonCrusher", "SteelGrip", "ThorsBurp");
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];
                                Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(750, 100, 350, "Headbutt", "PistonCharge", "PistonCrusher");
                            }
                            setEnemySprite = true;

                        }

                        break;
                        /*
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;*/
                }
            }

            if (sState == StageState.SKIRMISH)
            {
                switch (stage)
                {
                    case 0:
                        if (!setEnemySprite)
                        {
                            switch (randomize)
                            {
                                case 0: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 1: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 2: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 3: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 4: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 5: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 6: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 7: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 30, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 8: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 30, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 9: //superRare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(200, 60, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(400, 30, 170, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                            }
                        }
                        break;
                    case 1:
                        if (!setEnemySprite)
                        {
                            switch (randomize)
                            {

                                case 0: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 1: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 2: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 3: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 4: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 5: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 6: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 7: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 8: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(600, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 9: //superRare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(400, 85, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(600, 60, 185, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (!setEnemySprite)
                        {
                            switch (randomize)
                            {

                                case 0: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 1: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 2: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 3: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 4: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 5: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 6: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 7: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 8: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(750, 100, 200, "Headbutt", "Headbutt", "ThorsBurp");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 9: //superRare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(500, 100, 200, "Headbutt", "Headbutt", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(750, 100, 200, "Headbutt", "Headbutt", "ThorsBurp");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                            }
                        }
                        break;

                    case 3:
                        if (!setEnemySprite)
                        {
                            switch (randomize)
                            {

                                case 0: //common

                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 1: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 2: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 3: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 4: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 5: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 6: //common
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(0, 0, 0, "Headbutt", "Headbutt", "Headbutt");
                                    setEnemySprite = true;
                                    break;
                                case 7: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(3000, 500, 200, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[3];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];
                                    setEnemySprite = true;
                                    break;
                                case 8: //rare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[0];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(3000, 500, 200, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[5];
                                    setEnemySprite = true;
                                    break;
                                case 9: //superRare
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[0].GetComponent<SpriteRenderer>().sprite = EnemySprites[2];

                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<Stats>().SetStats(3000, 500, 200, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[1].GetComponent<SpriteRenderer>().sprite = EnemySprites[1];

                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<Stats>().SetStats(1500, 300, 250, "Headbutt", "SteelGrip", "Headbutt");
                                    Manager.GetComponent<turnManager>().enemies[2].GetComponent<SpriteRenderer>().sprite = EnemySprites[4];
                                    setEnemySprite = true;
                                    break;
                            }
                        }
                        break;
                        /*
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;
                    case 0:

                        break;*/
                }
            }






        }
    }

    public void createPart()
    {
        GameObject aPart = Instantiate(newPart);
        aPart.transform.parent = partHolder.transform;

        switch (stage)
        {
            //First Set of Mobs
            case 0:
                switch (randomize)
                {
                    #region set1
                    case 0:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(100, 150), 0, Random.Range(50, 75), "Headbutt");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 1:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(100, 150), 0, Random.Range(50, 75), "Headbutt");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 2:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(100, 150), 0, Random.Range(50, 75), "Headbutt");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 3:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[0];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(150, 200), Random.Range(75, 100), 0, "PistonCrusher");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 4:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[0];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(150, 200), Random.Range(75, 100), 0, "PistonCrusher");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 5:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(25, 50), Random.Range(50, 100), "PistonCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 6:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(25, 50), Random.Range(50, 100), "PistonCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 7:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[1];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(350, 500), Random.Range(50, 75), 0, "Headbutt");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 8:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[1];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(10, 25), Random.Range(75, 100), "PistonCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 9:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[1];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(100, 150), Random.Range(10, 25), Random.Range(50, 75), "PistonCrusher");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                        #endregion
                }
                break;
            //Second Set of Mobs
            case 1:
                switch (randomize)
                {
                    #region set2
                    case 0:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 1:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 2:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 3:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[2];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(400, 500), Random.Range(50, 100), Random.Range(-50,-35), "SteelGrip");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 4:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[2];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(400, 500), Random.Range(50, 100), Random.Range(-50, -35), "SteelGrip");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 5:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(-100, -65), Random.Range(120, 160), "TruckCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 6:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(-100, -65), Random.Range(120, 160), "TruckCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 7:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[3];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 8:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[3];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(-300,-200), 0, Random.Range(120, 150), "TruckCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 9:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[3];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(250, 500), Random.Range(100, 150), Random.Range(-100, -70), "SteelGrip");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                        #endregion
                }
                break;
            //Triple Set of Mobs
            case 2:
                switch (randomize)
                {
                    #region set3
                    case 0:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "ThorsBurp");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 1:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "ThorsBurp");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 2:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "ThorsBurp");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 3:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[4];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(650, 750), Random.Range(100, 150), Random.Range(-100, -75), "ChainMail");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 4:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[4];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(650, 750), Random.Range(100, 150), Random.Range(-100, -75), "ChainMail");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 5:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(-200, -150), Random.Range(150, 200), Random.Range(0, 25), "PistonRush");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 6:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(-200, -150), Random.Range(150, 200), Random.Range(0, 25), "PistonRush");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 7:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[5];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(100, 150), Random.Range(150, 175), Random.Range(-25, -10), "ThorsBurp");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 8:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[5];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(50, 100), Random.Range(100, 125), Random.Range(10, 35), "PistonRush");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 9:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[5];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(400, 500), Random.Range(50, 75), 0, "ChainMail");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                        #endregion
                }
                break;
            //Fourth Set of Mobs
            case 3:
                switch (randomize)
                {
                    #region set4
                    case 0:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(500, 550), 0, Random.Range(50, 75), "Headbutt");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 1:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(200, 225), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 2:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[4];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "ThorsBurp");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 3:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[3];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(500, 600), Random.Range(100, 150), Random.Range(-50,-35), "SteelGrip");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 4:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[4];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(1000, 1200), Random.Range(100, 150), Random.Range(-100, -75), "ChainMail");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 5:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[5];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(50, 100), Random.Range(175, 225), Random.Range(10, 35), "PistonRush");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;

                        break;
                    case 6:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[0];
                        aPart.GetComponent<PartStats>().setStats("Legs", 0, Random.Range(25, 50), Random.Range(125, 165), "PistonCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 7:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().HeadSprites[2];
                        aPart.GetComponent<PartStats>().setStats("Head", Random.Range(10, 40), Random.Range(50, 100), Random.Range(30, 60), "SteamEngine");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 8:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().LegSprites[3];
                        aPart.GetComponent<PartStats>().setStats("Legs", Random.Range(-300, -200), 0, Random.Range(120, 150), "TruckCharge");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                    case 9:
                        aPart.GetComponent<PartStats>().mySprite = Manager.GetComponent<IMGparts>().BodySprites[1];
                        aPart.GetComponent<PartStats>().setStats("Body", Random.Range(300, 400), Random.Range(150, 200), 0, "PistonCrusher");

                        itemConfirmIMG.GetComponent<Image>().sprite = aPart.GetComponent<PartStats>().mySprite;
                        itemConfirmText.GetComponent<Text>().text = "Hp: " + aPart.GetComponent<PartStats>().HP +
                                                        "\nPower: " + aPart.GetComponent<PartStats>().Power +
                                                        "\nSpeed: " + aPart.GetComponent<PartStats>().Speed +
                                                        "\nAttack: " + aPart.GetComponent<PartStats>().AttackName;
                        break;
                        #endregion
                }
                break;
        }

        
        //print(aPart.GetComponent<PartStats>().Type);

        //Manager.GetComponent<RobotCreation>().AddToPartList(aPart);

    }

    
    public void testCreatePart()
    {
        randomize = Random.Range(0, 10);
        createPart();
    }


}
