using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : MonsterBullet
{
    public Vector3[] MisslePos = new Vector3[3];

    protected override void Move()
    {
        transform.Translate(BeizorSystem.GetBeizor(MisslePos, 0.5f) * Time.deltaTime * bulletSpeed);
    }
}
