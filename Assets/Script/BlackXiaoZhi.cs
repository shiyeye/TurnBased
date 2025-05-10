using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackXiaoZhi : EnemyUnit
{
    
    // Start is called before the first frame update
    void Awake()
    {
        base.isDead = false;
        if (enemyUnitCurrentHealth >= enemyUnitMaxHealth)
        {
            enemyUnitCurrentHealth = enemyUnitMaxHealth;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}//2025.5.10
