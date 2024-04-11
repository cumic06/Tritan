using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMoveMent : MonsterMoveMent
{
    private Vector3 startPos;

    protected override void Start()
    {
        startPos = transform.position;
        base.Start();
    }

    protected override IEnumerator Move()
    {
        WaitForSeconds moveDelayWait = new WaitForSeconds(moveDelayTime);

        while (true)
        {
            for (int i = 0; i < movePos.Length; i++)
            {
                while (Vector3.Distance(transform.position, movePos[i]) >= 0.5f)
                {
                    transform.position += monster.CurrentMoveSpeed * Time.deltaTime * MoveDir(i);
                    yield return null;
                }

                if (Vector3.Distance(transform.position, movePos[i]) <= 0.5f)
                {
                    monster.look = true;
                    transform.position = movePos[i];
                    yield return null;
                }
                else
                {
                    monster.look = false;
                    yield return null;
                }
                yield return moveDelayWait;
            }

            if (Vector3.Distance(transform.position, movePos[^1]) <= 0.5f)
            {
                while (Vector3.Distance(startPos, transform.position) >= 0.5f)
                {
                    Debug.Log("BackMove");
                    Vector3 dir = startPos - transform.position;
                    dir.Normalize();
                    transform.position += monster.CurrentMoveSpeed * Time.deltaTime * dir;
                    yield return null;
                }
            }
            yield return null;
        }
    }
}