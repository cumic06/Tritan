using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveMent))]
[RequireComponent(typeof(PlayerAttackMent))]
public class Player : Unit
{
    #region º¯¼ö
    public static Player Instance;

    private bool isGod;
    [SerializeField] private float godTime;

    [SerializeField] private GameObject shield;

    [SerializeField] private int level;

    public int Level => level;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        Instance = GetComponent<Player>();
    }

    private void Update()
    {
        ChangeLevel();
    }

    private float GetHpPer()
    {
        return (float)CurrentHp / (float)GetMaxHp();
    }

    private void ChangeLevel()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            level = 0;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            level = 1;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            level = 2;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            level = 3;
        }
    }

    public void LevelUp()
    {
        if (level >= 3) return;
        level++;

        Debug.Log(level);
    }

    public override void TakeDamage(int damageValue)
    {
        if (isGod) return;
        base.TakeDamage(damageValue);
        StartCoroutine(nameof(GodMode));
        StartCoroutine(nameof(HitEffect));
    }

    public override void TakeHeal(int healValue)
    {
        base.TakeHeal(healValue);
        StartCoroutine(nameof(HealEffect));
    }

    protected override void ChangeHp(int value)
    {
        base.ChangeHp(value);
        PlayerHpUI.Instance.PlayerHpSlider(GetHpPer());
    }

    protected override void Dead()
    {
        base.Dead();
        GameManager.Instance.GameOver();
    }

    public IEnumerator GodMode()
    {
        WaitForSeconds godWait = new(godTime);
        isGod = true;
        shield.SetActive(true);
        yield return godWait;
        isGod = false;
        shield.SetActive(false);
    }

    IEnumerator HitEffect()
    {
        float onOffTime = 0.2f;
        WaitForSeconds onOffWait = new WaitForSeconds(onOffTime);

        for (int i = 0; i < 2; i++)
        {
            PlayerUIEffect.Instance.ActiveHitEffect(true);
            yield return onOffWait;
            PlayerUIEffect.Instance.ActiveHitEffect(false);
            yield return onOffWait;
        }
    }

    IEnumerator HealEffect()
    {
        float onOffTime = 0.2f;
        WaitForSeconds onOffWait = new WaitForSeconds(onOffTime);

        for (int i = 0; i < 2; i++)
        {
            PlayerUIEffect.Instance.ActiveHealEffect(true);
            yield return onOffWait;
            PlayerUIEffect.Instance.ActiveHealEffect(false);
            yield return onOffWait;
        }
    }
}