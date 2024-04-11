using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveMent : MonoBehaviour
{
    protected Monster monster;
    [SerializeField] protected Vector3[] movePos;
    [SerializeField] protected float moveDelayTime;

    protected void Awake()
    {
        monster = GetComponent<Monster>();
    }

    protected virtual void Start()
    {
        StartCoroutine(nameof(Move));
    }

    protected virtual IEnumerator Move()
    {
        WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
        while (Vector3.Distance(transform.position, movePos[0]) >= 0.5f)
        {
            transform.position += monster.CurrentMoveSpeed * Time.deltaTime * MoveDir(0);
            yield return fixedWait;
        }
    }

    protected Vector3 MoveDir(int value)
    {
        Vector3 dir = movePos[value] - transform.position;
        dir.Normalize();
        return dir;
    }
}
