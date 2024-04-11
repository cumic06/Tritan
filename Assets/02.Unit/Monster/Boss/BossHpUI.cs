using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpUI : MonoSigleton<BossHpUI>
{
    [SerializeField] private Slider bossHpHandler;

    public void ActiveBossHpUI(bool value)
    {
        bossHpHandler.gameObject.SetActive(value);
    }

    public void BossHpSlider(int maxHp, int currentHp)
    {
        float hpPer = (float)currentHp / (float)maxHp;
        bossHpHandler.value = hpPer;
    }
}
