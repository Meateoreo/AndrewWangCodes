using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesManager;

//public enum PlayState { TOWN, BATTLE, MENU, ROBOTMENU }


public class GameState : MonoBehaviour
{
    public PlayState pState;
    public GameObject BackButton;
    [SerializeField] private GameObject Manager;

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject robotMenu;
    [SerializeField] private GameObject robotMenu2;
    [SerializeField] private GameObject battleMenu;

    [SerializeField] private GameObject combatStuffs;

    public GameObject MainCanvas;
    public GameObject GarageFadeObject;
    public AnimationClip garageAnimation;

    void Start()
    {
        Manager = GameObject.Find("Manager");
        pState = PlayState.TITLE;
        BackButton = GameObject.Find("BackButton");

    }

    // Update is called once per frame
    void Update()
    {
        switch (pState)
        {
            case PlayState.TITLE:
                BackButton.SetActive(false);
                title.SetActive(true);
                mainMenu.SetActive(false);
                robotMenu.SetActive(false);
                robotMenu2.SetActive(false);
                battleMenu.SetActive(false);
                combatStuffs.SetActive(false);
                Manager.GetComponent<SoundList>().SwitchMusic(2);
                break;

            case PlayState.TOWN:
                //Manager.GetComponent<turnManager>().bState = BattleState.END;

                BackButton.SetActive(true);
                title.SetActive(false);
                mainMenu.SetActive(true);
                robotMenu.SetActive(false);
                robotMenu2.SetActive(false);
                battleMenu.SetActive(false);
                combatStuffs.SetActive(false);
                if (Input.GetKeyDown(Keys.Menu))
                    pState = PlayState.MENU;
                if (Input.GetKeyDown(Keys.RobotMenu))
                    pState = PlayState.ROBOTMENU;
                /*
                if (Input.GetKeyDown(KeyCode.B))
                    pState = PlayState.BATTLE;
                */
                Manager.GetComponent<SoundList>().SwitchMusic(2);
                //Manager.GetComponent<RobotCreation>().moneyText.SetActive(false);

                break;

            case PlayState.MENU:
                BackButton.SetActive(true);
                /*
                if (Input.GetKeyDown(Keys.Menu))
                    pState = PlayState.TOWN;
                    */
                Manager.GetComponent<SoundList>().SwitchMusic(2);
                break;

            case PlayState.ROBOTMENU:
                BackButton.SetActive(true);
                title.SetActive(false);
                mainMenu.SetActive(false);
                robotMenu.SetActive(true);
                robotMenu2.SetActive(false);
                battleMenu.SetActive(false);
                combatStuffs.SetActive(false);

                /*
                if (Input.GetKeyDown(Keys.RobotMenu))
                    pState = PlayState.TOWN;
                */

                Manager.GetComponent<SoundList>().SwitchMusic(0);
                //Manager.GetComponent<RobotCreation>().moneyText.SetActive(true);
                break;

            case PlayState.ROBOTMENU2:
                BackButton.SetActive(true);
                title.SetActive(false);
                mainMenu.SetActive(false);
                robotMenu.SetActive(false);
                robotMenu2.SetActive(true);
                battleMenu.SetActive(false);
                combatStuffs.SetActive(false);

                /*
                if (Input.GetKeyDown(Keys.RobotMenu))
                    pState = PlayState.TOWN;
                */
                break;

            case PlayState.BATTLE:
                BackButton.SetActive(true);
                title.SetActive(false);
                mainMenu.SetActive(false);
                robotMenu.SetActive(false);
                robotMenu2.SetActive(false);
                battleMenu.SetActive(true);
                combatStuffs.SetActive(true);
                /*
                if (Input.GetKeyDown(Keys.Menu))
                    pState = PlayState.TOWN;
                    */
                if (Manager.GetComponent<EnemyController>().sState == StageState.ARENA && Manager.GetComponent<EnemyController>().Stage == 3)
                    Manager.GetComponent<SoundList>().SwitchMusic(3);
                else
                    Manager.GetComponent<SoundList>().SwitchMusic(1);
                //Manager.GetComponent<RobotCreation>().moneyText.SetActive(false);
                break;


        }

    }

    public void ChangeScene(PlayState newState)
    {
        Instantiate(GarageFadeObject, MainCanvas.transform);

        StartCoroutine(SceneFade(newState));
    }

    IEnumerator SceneFade(PlayState newState)
    {
        yield return new WaitForSeconds(garageAnimation.length/2);

        Manager.GetComponent<turnManager>().clearTurnManager();
        Manager.GetComponent<GameState>().pState = newState;
    }

    public void startGame()
    {
        ChangeScene(PlayState.TOWN);
    }

    public void fight()
    {
        if (pState == PlayState.BATTLE)
        {
            ChangeScene(PlayState.TOWN);
        }
        else
        {
            Manager.GetComponent<EnemyController>().randomize = Random.Range(7, 10);
            ChangeScene(PlayState.BATTLE);
            Manager.GetComponent<EnemyController>().sState = StageState.ARENA;
            Manager.GetComponent<EnemyController>().setEnemySprite = false;
        }
    }
    public void skirmish()
    {
        if (pState == PlayState.BATTLE)
        {
            ChangeScene(PlayState.TOWN);
        }
        else
        {
            Manager.GetComponent<EnemyController>().randomize = Random.Range(0, 10);
            ChangeScene(PlayState.BATTLE);
            Manager.GetComponent<EnemyController>().sState = StageState.SKIRMISH;
            Manager.GetComponent<EnemyController>().setEnemySprite = false;
        }
    }

    public void robots()
    {
        if (pState == PlayState.ROBOTMENU)
        {
            ChangeScene(PlayState.TOWN);
        }
        else
            ChangeScene(PlayState.ROBOTMENU);
    }

}
