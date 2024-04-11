using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public struct UnitStat
{
    public int maxHp;
    public int minHp;
    public float moveSpeed;
}

public enum TeamType
{
    MyTeam,
    Enemy
}

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour, IDamageable, IHealable
{
    #region º¯¼ö
    [SerializeField] private UnitStat unitStat;

    private int currentHp;
    public int CurrentHp => currentHp;

    private float currentMoveSpeed;
    public float CurrentMoveSpeed => currentMoveSpeed;

    private float changeColorTime = 0.15f;
    private WaitForSeconds changeColorWait;

    private List<MeshRenderer> meshRenderers = new();

    [SerializeField] private TeamType teamType;

    [SerializeField] private GameObject deadEffect;
    #endregion

    protected virtual void Awake()
    {
        ResetStat();
        meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
        changeColorWait = new WaitForSeconds(changeColorTime);
    }

    public int GetMaxHp()
    {
        return unitStat.maxHp;
    }

    public TeamType GetTeamType()
    {
        return teamType;
    }

    #region ResetStat
    private void ResetStat()
    {
        ResetHp();
        ResetSpeed();
    }

    public void ResetHp()
    {
        currentHp = unitStat.maxHp;
    }

    public void ResetSpeed()
    {
        currentMoveSpeed = unitStat.moveSpeed;
    }
    #endregion

    #region ChangeHp
    public virtual void TakeDamage(int damageValue)
    {
        ChangeHp(-damageValue);
        StartCoroutine(nameof(ChangeColor));
    }

    public virtual void TakeHeal(int healValue)
    {
        ChangeHp(healValue);
    }

    protected virtual void ChangeHp(int value)
    {
        ClampHp(value);
        int changeValue = currentHp + value;
        currentHp = changeValue;
        if (currentHp <= 0)
        {
            Dead();
        }
    }

    protected void ClampHp(int value)
    {
        if (currentHp + value >= unitStat.maxHp)
        {
            currentHp = unitStat.maxHp;
        }

        if (currentHp + value <= unitStat.minHp)
        {
            currentHp = unitStat.minHp;
        }
    }

    protected virtual void Dead()
    {
        GameObject spawnEffect = Instantiate(deadEffect);
        spawnEffect.transform.position = transform.position;
        Destroy(gameObject);
    }
    #endregion

    IEnumerator ChangeColor()
    {
        for (int i = 0; i < 2; i++)
        {
            meshRenderers.ForEach((m) => m.enabled = false);
            yield return changeColorWait;
            meshRenderers.ForEach((m) => m.enabled = true);
            yield return changeColorWait;
        }
    }
}