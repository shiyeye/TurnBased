using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyBattleHud : MonoBehaviour
{
    //公开文本和血条，让别的脚本可以调用
    public TextMeshProUGUI nameText, levelText, healthText;
    public Slider healthSlider;

    //传入一个Unit对象，设置血条和文本
    public void SetHud(EnemyUnit unit)
    {
        nameText.text = unit.enemyUnitName;
        levelText.text = "Lv." + unit.enemyUnitLevel;
        healthSlider.maxValue = unit.enemyUnitMaxHealth;
        healthSlider.value = unit.enemyUnitCurrentHealth;
        healthText.text = unit.enemyUnitCurrentHealth + "/" + unit.enemyUnitMaxHealth;
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}//2025.5.10
