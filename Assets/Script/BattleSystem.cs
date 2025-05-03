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

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHud.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack was successful! ";

        yield return new WaitForSeconds(2f); 

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHud.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost the battle!";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "What is your choice?";
    }
    
    IEnumerator PlayerPropButton()
    {
        playerUnit.Prop(50);

        playerHud.SetHP(playerUnit.currentHP);
        dialogueText.text = "You used a prop!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnPropButton()
    {
        if (state != BattleState.PLAYTURN)
            return;
        
        StartCoroutine(PlayerPropButton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
