using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    #region º¯¼ö
    private Monster monster;

    [SerializeField] protected List<AttackData> monsterAttackData = new();

    protected WaitForSeconds attackWait;
    #endregion

    protected void Awake()
    {
        monster = GetComponent<Monster>();
        attackWait = new WaitForSeconds(monsterAttackData[0].attackTime);
    }

    protected virtual void Start()
    {
        StartCoroutine(nameof(MonsterState));
    }

    protected void FixedUpdate()
    {
        if (monster.look && GameManager.Instance.CurrentGameStopPlay == GameStopPlay.GamePlay)
        {
            transform.LookAt(Player.Instance.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0);
        }
    }

    IEnumerator MonsterState()
    {
        StartCoroutine(nameof(Attack));
        yield return null;
    }

    protected virtual IEnumerator Attack()
    {
        while (true)
        {
            SpawnBullet(monsterAttackData.Count - 1);
            yield return attackWait;
        }
    }

    protected void SpawnBullet(int value)
    {
        for (int i = 0; i < monsterAttackData[value].bulletCount; i++)
        {
            GameObject spawnBullet = Instantiate(monsterAttackData[value].bullet);
            spawnBullet.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, ReturnAngle() - (monsterAttackData[value].attackAngle * i), 0));
        }
    }

    protected float ReturnAngle()
    {
        return monsterAttackData[0].bulletCount * monsterAttackData[0].attackAngle * 0.5f + transform.eulerAngles.y + 90;
    }
}
