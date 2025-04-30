using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYTURN, ENEMYTURN, WON, LOST };
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHud playerHud;
    public BattleHud enemyHud;


    Unit playerUnit;
    Unit enemyUnit;
    
    public TextMeshProUGUI dialogueText;


    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        //实例化一个玩家的预制体在playerBattleStation的位置上
        GameObject playerGameObject = Instantiate(playerPrefab, playerBattleStation);
        //playerUnit这个组件是playerGameObject.GetComponent上的脚本
        playerUnit = playerGameObject.GetComponent<Unit>();

        GameObject enemyGameObject = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        dialogueText.text = "You met " + enemyUnit.unitName + "!!!";

        playerHud.SetHud(playerUnit);
        enemyHud.SetHud(enemyUnit);

        yield return new WaitForSeconds(2f);

        //前面运行后，转变为玩家回合
        state = BattleState.PLAYTURN;

        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "What is your choice?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
