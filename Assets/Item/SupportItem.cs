using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportItem : Item
{
    [SerializeField] private GameObject supportOur;

    protected override void OnEat()
    {
        base.OnEat();
        Instantiate(supportOur);
    }
}
