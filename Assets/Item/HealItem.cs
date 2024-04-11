using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private int healvalue;

    protected override void OnEat()
    {
        base.OnEat();
        PlayerHeal();
    }

    private void PlayerHeal()
    {
        if (Player.Instance.CurrentHp + healvalue >= 100)
        {
            Player.Instance.TakeHeal(100);
        }
        else
        {
            Player.Instance.TakeHeal(healvalue);
        }
    }
}
