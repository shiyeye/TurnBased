using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_PengFei_He : PlayerUnit
{
    public float attackInterval;
    public GameObject currentTarget;
    private float lastAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            FindEnemyTarget();
        }

        if (currentTarget != null && Time.time - lastAttackTime > attackInterval)
        {
            Attack();
        }
    }

    void FindEnemyTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            currentTarget = enemies[0];
        }
    }

    void Attack()
    {
        lastAttackTime = Time.time;

        if (currentTarget == null)
        {
            FindEnemyTarget();
            return;
        }

        EnemyUnit enemyUnit = currentTarget.GetComponent<EnemyUnit>();
        if (enemyUnit == null || enemyUnit.enemyUnitCurrentHealth <= 0)
        {
            currentTarget = null;
            return;
        }

        enemyUnit.TakeDamage(playerUnitDamage);

    }

}//2025.5.10
