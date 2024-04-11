using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Normal,
    Sector,
    Radial
}

public class Monster : Unit
{
    [SerializeField] private MonsterType monsterType;
    public MonsterType MonsterType => monsterType;
    [SerializeField] private int score;
    public bool look;


    protected override void Dead()
    {
        ScoreSystem.Instance.AddScore(score);
        ItemSpawnSystem.Instance.SpawnItem(transform.position);
        base.Dead();
        ScoreUIManager.Instance.ActivePopScoreUI(transform.position, score);
        CameraShakeSystem.Instance.ShakeCamera(0.3f, 0.1f);
    }
}
