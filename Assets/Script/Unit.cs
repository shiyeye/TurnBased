using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int maxHP;
    public int currentHP;
    public int damage;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
            return true; // Unit is dead
        else
            return false; // Unit is still alive
    }

    public void Prop(int prop)
    {
        currentHP += prop; // Assuming prop has an effectValue property
        if (currentHP > maxHP)
            currentHP = maxHP; // Ensure HP does not exceed maxHP
    }

    public void Heal(int heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
