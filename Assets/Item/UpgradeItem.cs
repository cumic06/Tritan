using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : Item
{
    protected override void OnEat()
    {
        base.OnEat();
        LevelUp();
    }

    private void LevelUp()
    {
        Player.Instance.LevelUp();
    }
}
