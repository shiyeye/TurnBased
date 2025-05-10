using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBattleHud : MonoBehaviour
{
    //公开文本和血条，让别的脚本可以调用
    public TextMeshProUGUI nameText, levelText, healthText;
    public Slider healthSlider;

    //传入一个Unit对象，设置血条和文本
    public void SetHud(PlayerUnit unit)
    {
        nameText.text = unit.playerUnitName;
        levelText.text = "Lv." + unit.playerUnitLevel;
        healthSlider.maxValue = unit.playerUnitMaxHealth;
        healthSlider.value = unit.playerUnitCurrentHealth;
        healthText.text = unit.playerUnitCurrentHealth + "/" + unit.playerUnitMaxHealth;
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}//2025.5.10
