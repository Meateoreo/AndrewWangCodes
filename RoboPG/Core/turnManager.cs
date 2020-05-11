using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatesManager;


public class turnManager : MonoBehaviour
{
    public BattleState bState;

    private GameObject Manager;
 
    //public GameObject turnArrow;
    //private Vector3 ArrowPosition;
    public List<GameObject> takingTurn;

    private GameObject enemyTarget;
    public GameObject target;
    public string attack;
    public bool go;

    #region prefabs
    public GameObject robotPrefab1;
    public GameObject robotPrefab2;
    public GameObject robotPrefab3;

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    #endregion
    #region placements
    public Transform robotPlacement1;
    public Transform robotPlacement2;
    public Transform robotPlacement3;

    public Transform enemyPlacement1;
    public Transform enemyPlacement2;
    public Transform enemyPlacement3;
    #endregion

    public List<GameObject> fighters;
    public List<GameObject> friends;
    public List<GameObject> enemies;

    [SerializeField] private float[] speedList;

    public GameObject itemConfirm;
    [SerializeField] private GameObject damageText;
    [SerializeField] private GameObject CombatCanvas;
    [SerializeField] private GameObject PlayerMoves;
    [SerializeField] private Text battleText;
    
    public Text attackDescriptionText;


    private float rustPerDamage = 0.15f;

    private Coroutine statusStartCheckCoroutine;

    private void Start()
    {
        Manager = GameObject.Find("Manager");
        bState = BattleState.END;
        //ArrowPosition = turnArrow.transform.position;

    }
   

    private void Update()
    {   
        if (Manager.GetComponent<GameState>().pState == PlayState.BATTLE && bState == BattleState.END)
        {
            StartCoroutine(StartDelay());
        }

        /*
        if (Manager.GetComponent<GameState>().pState == PlayState.BATTLE)
        {
            if (takingTurn.Count > 0)
            {
                if (takingTurn[0] != null)
                    turnArrow.transform.position = new Vector3(takingTurn[0].transform.position.x, takingTurn[0].transform.position.y + 1.5f);
                else
                    turnArrow.transform.position = ArrowPosition;
            }
        }*/

        switch (bState)
        {
            case BattleState.PREPARE:
                if (!checkFriendsAlive())
                    bState = BattleState.LOSE;
                if (!checkEnemiesAlive())
                    bState = BattleState.WIN;

                if (takingTurn.Count > 0 && takingTurn[0] != null && takingTurn[0].gameObject.GetComponent<Stats>().Side == "Friend")
                    bState = BattleState.MYTURN;
                else if (takingTurn.Count > 0 && takingTurn[0] != null && takingTurn[0].gameObject.GetComponent<Stats>().Side == "Enemy")
                {
                    print("changing");
                    bState = BattleState.THINKING;
                }
                break;

            case BattleState.MYTURN:
                if (!checkFriendsAlive())
                    bState = BattleState.LOSE;
                if (!checkEnemiesAlive())
                    bState = BattleState.WIN;
                StopAllCoroutines();
                StartCoroutine(checkStatusStart());
                break;

            case BattleState.CHECKSTATUSSTART:
                break;

            case BattleState.CHECKSTATUSEND:
                StopAllCoroutines();
                StartCoroutine(checkStatusEnd());
                break;

            case BattleState.TARGET:
                if (!checkFriendsAlive())
                    bState = BattleState.LOSE;
                if (!checkEnemiesAlive())
                    bState = BattleState.WIN;

                break;
            
            case BattleState.ATTACK:
                bState = BattleState.ATTACKING;
                if (!checkFriendsAlive())
                    bState = BattleState.LOSE;
                if (!checkEnemiesAlive())
                    bState = BattleState.WIN;

                StartCoroutine(AttackDelay());
                break;

            case BattleState.THINKING:
                StopAllCoroutines();
                StartCoroutine(AutoDelay());
                break;

            case BattleState.AUTO:
                bState = BattleState.AUTOING;
                //print("auto");

                if (!checkFriendsAlive())
                    bState = BattleState.LOSE;
                if (!checkEnemiesAlive())
                    bState = BattleState.WIN;
                if (go)
                {
                    StopAllCoroutines();
                    StartCoroutine(EnemyAttack());
                }
                break;

            //

            case BattleState.LOSE:
                StartCoroutine(EndDelay());
                break;

            case BattleState.WIN:
                Manager.GetComponent<EnemyController>().createPart();
                if (Manager.GetComponent<EnemyController>().sState == StageState.ARENA)
                {
                    Manager.GetComponent<EnemyController>().Stage++;
                }
                StartCoroutine(itemGet());
                break;

            case BattleState.END:
                //Manager.GetComponent<EnemyController>().setEnemySprite = false;
                break;
        }

        if (takingTurn.Count == 0)
        {
            PlayerMoves.SetActive(false);
            battleText.text = "Robots getting READY...";

        }
        else if (takingTurn[0].GetComponent<Stats>().Side == "Friend")
        {
            if (attack == "")
                battleText.text = "Choose an ATTACK!";
            else
                battleText.text = "";

            PlayerMoves.SetActive(true);
        }
        else if (takingTurn[0].GetComponent<Stats>().Side == "Enemy")
        {
            PlayerMoves.SetActive(false);
            battleText.text = "Enemy Turn...";
        }


        /*
        if (takingTurn[0] != null)
            takingTurn[0].GetComponent<Stats>().Ready = 0;
            */
    }


    IEnumerator StartDelay()
    {
        canStart();
        yield return new WaitForSeconds(1f);
        bState = BattleState.PREPARE;

        //takingTurn.RemoveAt(0);
    }
    IEnumerator AttackDelay()
    {
        print("Attacking");
        //Manager.GetComponent<turnManager>().turnArrow.gameObject.transform.position = ArrowPosition;
        yield return new WaitForSeconds(0.5f);
        print(attack);
        takingTurn[0].transform.position = target.transform.position - new Vector3(2,0);

        //damageText.GetComponent<Text>().text = Manager.GetComponent<AttackList>().applyDamage(takingTurn[0], target, attack).ToString();

        //create and set damage text
        GameObject tempText = Instantiate(damageText, CombatCanvas.transform);

        Vector3 robotPosition = Camera.main.WorldToScreenPoint(target.transform.position);
        tempText.transform.position = new Vector3(robotPosition.x, robotPosition.y+(Screen.height/8));

        tempText.GetComponent<Text>().text = Manager.GetComponent<AttackList>().applyDamage(takingTurn[0], target, attack).ToString();

        //make attack animation
        GameObject tempAttackAni = Instantiate(Manager.GetComponent<AttackList>().AttackAnimations[Manager.GetComponent<AttackList>().AttackIndex[Manager.GetComponent<AttackList>().getAttackInfo(attack)]], CombatCanvas.transform);
        tempAttackAni.transform.position = new Vector3(robotPosition.x + Random.Range(-10f,10f), robotPosition.y + Random.Range(-30f, 30f));

        //play hitSound
        Manager.GetComponent<SoundList>().sfxSource.PlayOneShot(Manager.GetComponent<SoundList>().sfxClips[Random.Range(8, 10)], 1f);
        

        //wait then Move back
        yield return new WaitForSeconds(0.5f);
        takingTurn[0].transform.position = takingTurn[0].GetComponent<Stats>().oldPosition;
        yield return new WaitForSeconds(0.25f);


        bState = BattleState.CHECKSTATUSEND;
    }
    
    IEnumerator AutoDelay()
    {
        bState = BattleState.AUTO;
        print("delay");
        yield return new WaitForEndOfFrame();
        go = true;
    }

    IEnumerator EnemyAttack()
    {
        if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses != "")
        {
            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses != "PowerSurge")
                takingTurn[0].gameObject.GetComponent<Stats>().StatusDuration--;

            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses == "Rust")
            {
                takingTurn[0].gameObject.GetComponent<Stats>().HP -= takingTurn[0].gameObject.GetComponent<Stats>().maxHP * 0.1f;
            }

            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses == "Lag")
            {
                bState = BattleState.CHECKSTATUSEND;
                StopAllCoroutines();
            }
        }

        enemyTarget = friends[Random.Range(0, friends.Count)];

        print("Auto attacking");
        yield return new WaitForSeconds(0.5f);
        //Manager.GetComponent<turnManager>().turnArrow.gameObject.transform.position = ArrowPosition;
        attack = takingTurn[0].GetComponent<Stats>().Attacks[Random.Range(0,3)];
        //print(attack);
        //Manager.GetComponent<AttackList>().applyDamage(takingTurn[0], enemyTarget, attack);
        yield return new WaitForSeconds(0.5f);
        takingTurn[0].transform.position = enemyTarget.transform.position - new Vector3(-2, 0);

        //create and set damage text
        GameObject tempText = Instantiate(damageText, CombatCanvas.transform);

        Vector3 robotPosition = Camera.main.WorldToScreenPoint(enemyTarget.transform.position);
        tempText.transform.position = new Vector3(robotPosition.x, robotPosition.y + (Screen.height / 8));

        tempText.GetComponent<Text>().text = Manager.GetComponent<AttackList>().applyDamage(takingTurn[0], enemyTarget, attack).ToString();

        //make attack animation
        GameObject tempAttackAni = Instantiate(Manager.GetComponent<AttackList>().AttackAnimations[Manager.GetComponent<AttackList>().AttackIndex[Manager.GetComponent<AttackList>().getAttackInfo(attack)]], CombatCanvas.transform);
        tempAttackAni.transform.position = new Vector3(robotPosition.x + Random.Range(-10f, 10f), robotPosition.y + Random.Range(-30f, 30f));

        //play Hitsound
        Manager.GetComponent<SoundList>().sfxSource.PlayOneShot(Manager.GetComponent<SoundList>().sfxClips[Random.Range(8, 10)], 1f);

        yield return new WaitForSeconds(0.5f);
        takingTurn[0].transform.position = takingTurn[0].GetComponent<Stats>().oldPosition;

        go = false;
        bState = BattleState.CHECKSTATUSEND;
    }

    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(1f);
        bState = BattleState.END;
        Manager.GetComponent<GameState>().ChangeScene(PlayState.TOWN);
    }
    IEnumerator itemGet()
    {
        bState = BattleState.ITEM;
        yield return new WaitForSeconds(1f);
        itemConfirm.SetActive(true);
    }

        private int findIndexOfNextHighestValue(int index)
    {
        int result = index;

        for (int i = index + 1; i < speedList.Length; i++)
            if (speedList[i] > speedList[result])
                result = i;

        return result;
    }
    //Specific Swap
    private void swap(int index, int index2)
    {
        GameObject holderGO = fighters[index];
        float holderSpeed = speedList[index];

        fighters[index] = fighters[index2];
        speedList[index] = speedList[index2];

        fighters[index2] = holderGO;
        speedList[index2] = holderSpeed;

    }
    //General GameObject Array Swap
    private void swap(GameObject[] array, int a, int b)
    {
        GameObject hold = array[a];
        array[a] = array[b];
        array[b] = hold;
    }
    /*
    public void removeFighter()
    {
        for (int r = 0; r < takingTurn.Length - 1; r++)
            swap(takingTurn, r, r + 1);

        takingTurn[takingTurn.Length-1] = null;
    }*/

    /*
    public int add()
    {
        
        int temp;

        for (temp = 0; temp < takingTurn.Count+1; temp++)
        {
            if (takingTurn[temp] == null)
                return temp;
        }

        return temp;
    }*/
    /*
    public float attackThis()
    {
       return Manager.GetComponent<AttackList>().applyDamage(takingTurn[0], target, attack);
    }
    */
    public void attackAll(string side)
    {
        if(side == "Friend")
        {

        }

        if(side == "Enemy")
        {

        }
    }

    /*
    private void checkDupe()
    {
        for (int r = 0; r < takingTurn.Count; r++)
            swap(takingTurn, r, r + 1);
    }*/


    public void clearTurnManager()
    {
        StopAllCoroutines();
        go = false;

        attack = "";
        target = null;

        foreach (GameObject robot in Manager.GetComponent<turnManager>().fighters)
        {
            robot.GetComponent<Stats>().ResetStats();
            robot.transform.position = robot.GetComponent<Stats>().oldPosition;
        }

        Manager.GetComponent<EnemyController>().setEnemySprite = false;


        bState = BattleState.END;
    }

    private void canStart()
    {
        fighters = new List<GameObject>();
        friends = new List<GameObject>(); 
        enemies = new List<GameObject>();

        takingTurn = new List<GameObject>();
        go = false;

        foreach (GameObject fighter in GameObject.FindGameObjectsWithTag("Robot"))
        {
            fighters.Add(fighter);
        }
        speedList = new float[fighters.Count];
        attack = "";
        target = null;

        int r = 0;
        foreach (GameObject robot in fighters)
        {
            if (robot.GetComponent<Stats>().Side == "Friend")
                robot.GetComponent<Stats>().ResetStats();

            if (robot.GetComponent<Stats>())
            {
                speedList[r] = robot.GetComponent<Stats>().Speed + Random.Range(0, 5);
                r++;
            }

            if (robot.GetComponent<Stats>().Side == "Friend")
                friends.Add(robot);
            if (robot.GetComponent<Stats>().Side == "Enemy")
                enemies.Add(robot);

        }
        Manager.GetComponent<EnemyController>().setEnemySprite = false;

        for (int i = 0; i < fighters.Count - 1; i++)
        {
            int index = findIndexOfNextHighestValue(i);
            swap(index, i);
        }
    }

    private bool checkFriendsAlive()
    {
        foreach (GameObject robot in friends)
        {
            if (robot.GetComponent<Stats>().Alive)
                return true;
        }

        return false;
    }
    private bool checkEnemiesAlive()
    {
        foreach (GameObject robot in enemies)
        {
            if (robot.GetComponent<Stats>().Alive)
                return true;
        }

        return false;
    }

    public void mainMenuButton()
    {
        itemConfirm.SetActive(false);
        Manager.GetComponent<GameState>().ChangeScene(PlayState.TOWN);

    }
    public void robotMenuButton()
    {
        itemConfirm.SetActive(false);
        Manager.GetComponent<GameState>().ChangeScene(PlayState.ROBOTMENU);

    }

    public void resetAfterAttack()
    {
        attack = "";
        attackDescriptionText.text = "";

    }

    IEnumerator checkStatusStart()
    {
        bState = BattleState.CHECKSTATUSSTART;

        //print("hi");
        if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses != "")
        {
            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses != "PowerSurge")
                takingTurn[0].gameObject.GetComponent<Stats>().StatusDuration--;

            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses == "Rust")
            {
                takingTurn[0].gameObject.GetComponent<Stats>().HP -= takingTurn[0].gameObject.GetComponent<Stats>().maxHP * rustPerDamage;
            }

            if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses == "Lag")
            {
                bState = BattleState.CHECKSTATUSEND;
                StopAllCoroutines();
            }
            

        }
        yield return new WaitForSeconds(1f);
        //print("here");
        bState = BattleState.TARGET;
    }

    IEnumerator checkStatusEnd()
    {
        bState = BattleState.ENDINGTURN;

        if (takingTurn[0].gameObject.GetComponent<Stats>().Statuses == "PowerSurge")
            takingTurn[0].gameObject.GetComponent<Stats>().StatusDuration--;

        if (takingTurn[0].gameObject.GetComponent<Stats>().StatusDuration <= 0)
        {
            takingTurn[0].gameObject.GetComponent<Stats>().Statuses = "";
        }
            
        yield return new WaitForSeconds(1f);

        //print("yes");

        resetAfterAttack();
        takingTurn.RemoveAt(0);
        bState = BattleState.PREPARE;

    }

}
