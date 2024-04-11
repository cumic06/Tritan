using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MujukItem : Item
{
    [SerializeField] private float mujukTime;

    protected override void OnEat()
    {
        base.OnEat();
        Mujuk();
    }

    private void Mujuk()
    {
        Player.Instance.StartCoroutine(Player.Instance.GodMode());
    }
}
