using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;
    public TextMeshProUGUI hpText;

    //公开一个SetHud 引用Unit脚本里的参数
    public void SetHud(Unit Unit)
    {
        nameText.text = Unit.unitName;
        levelText.text = "Level " + Unit.unitLevel;
        hpSlider.maxValue = Unit.maxHP;
        hpSlider.value = Unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
