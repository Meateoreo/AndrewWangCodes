using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager
{
    public enum PlayState { TITLE, TOWN, BATTLE, MENU, ROBOTMENU, ROBOTMENU2 }

    public enum BattleState { END, START, PREPARE, MYTURN, TARGET, ATTACK, ATTACKING, THINKING, AUTO, AUTOING, WIN, LOSE, ITEM, CHECKSTATUSSTART, CHECKSTATUSEND, ENDINGTURN }

    public enum StageState { SKIRMISH, ARENA }
    
}
