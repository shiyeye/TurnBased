using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyUnit : MonoBehaviour
{
    public string enemyUnitName;
    public int enemyUnitMaxHealth;
    public int enemyUnitCurrentHealth;
    public ushort enemyUnitLevel;
    public int enemyUnitDamage;
    public bool isDead;
    private BattleState currentState;
    public EnemyBattleHud enemyUpdateHud;
    // Start is called before the first frame update
    void Start()
    {
        enemyUpdateHud = FindObjectOfType<EnemyBattleHud>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        enemyUnitCurrentHealth -= damage;
        if (enemyUnitCurrentHealth <= 0)
        {
            enemyUnitCurrentHealth = 0;
            Die();
        }
        enemyUpdateHud.healthText.text = enemyUnitCurrentHealth + "/" + enemyUnitMaxHealth;
        enemyUpdateHud.healthSlider.value = enemyUnitCurrentHealth;
    }

    void Die()
    {
        isDead = true;
        
        Destroy(gameObject);
        currentState = BattleState.WON;
    }

}//2025.5.10
