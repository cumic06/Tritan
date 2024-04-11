using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    protected virtual void Start()
    {
        MonsterSpawnSystem.Instance.isBossSpawn = true;
        BossHpUI.Instance.ActiveBossHpUI(true);
    }

    protected void FixedUpdate()
    {
        BossHpUI.Instance.BossHpSlider(GetMaxHp(), CurrentHp);
    }

    protected override void Dead()
    {
        base.Dead();
        GameManager.Instance.ClearGame();
        BossHpUI.Instance.ActiveBossHpUI(false);
        CameraShakeSystem.Instance.ShakeCamera(1.5f, 0.3f);
    }
}
