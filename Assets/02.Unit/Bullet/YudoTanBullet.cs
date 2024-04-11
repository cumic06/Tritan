using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YudoTanBullet : Bullet
{
    [SerializeField] private Vector3 boxSize;

    [SerializeField] private Transform[] beizorPos; 

    protected override void Move()
    {
        if (TryGetMonster(out Monster monster))
        {
            transform.LookAt(monster.transform);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
        transform.eulerAngles = new Vector2(90, transform.eulerAngles.y);
    }
    private bool TryGetMonster(out Monster monster)
    {
        monster = null;
        Collider[] checkMonsterCol = Physics.OverlapBox(Vector3.zero, boxSize);

        foreach (var boxCol in checkMonsterCol)
        {
            if (boxCol.TryGetComponent(out Monster checkMonster))
            {
                monster = checkMonster;
                return true;
            }
        }
        return false;
    }
}
