using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    [SerializeField] private float patternDelayTime;
    private WaitForSeconds patternWait;
    [SerializeField] private GameObject laserObject;

    private Vector3[] missilePos = new Vector3[3];
    private Coroutine[] patternCor = new Coroutine[4];

    protected override void Start()
    {
        base.Start();
        patternWait = new WaitForSeconds(patternDelayTime);
    }

    protected override IEnumerator Attack()
    {
        while (true)
        {
            for (int i = 0; i < patternCor.Length; i++)
            {
                if (patternCor[i] != null)
                {
                    StopCoroutine(patternCor[i]);
                    yield return null;
                }
            }

            int randomPattern = Random.Range(0, monsterAttackData.Count);
            yield return null;
            Pattern(randomPattern);
            yield return patternWait;
        }
    }

    private void Pattern(int randomPattern)
    {
        switch (randomPattern)
        {
            case 0:
                patternCor[0] = StartCoroutine(nameof(NormalAttack));
                patternCor[1] = StartCoroutine(nameof(SectorAttack));
                break;
            case 1:
                patternCor[1] = StartCoroutine(nameof(SectorAttack));
                patternCor[2] = StartCoroutine(nameof(RadialAttack));
                break;
            case 2:
                patternCor[2] = StartCoroutine(nameof(RadialAttack));
                patternCor[3] = StartCoroutine(nameof(LaserAttack));
                //patternCor[3] = StartCoroutine(nameof(MissileAttack));
                break;
            case 3:
                patternCor[0] = StartCoroutine(nameof(NormalAttack));
                patternCor[3] = StartCoroutine(nameof(LaserAttack));
                //patternCor[3] = StartCoroutine(nameof(MissileAttack));
                break;
        }
    }

    private IEnumerator NormalAttack()
    {
        float attackTime = monsterAttackData[0].attackTime;
        WaitForSeconds attackWait = new WaitForSeconds(attackTime);

        while (true)
        {
            SpawnBullet(0);
            yield return attackWait;
        }
    }

    private IEnumerator SectorAttack()
    {
        float attackTime = monsterAttackData[1].attackTime;
        WaitForSeconds attackWait = new WaitForSeconds(attackTime);

        for (int i = 0; i < 2; i++)
        {
            SpawnBullet(1);
            yield return attackWait;
        }
    }

    private IEnumerator RadialAttack()
    {
        float attackTime = monsterAttackData[2].attackTime;
        WaitForSeconds attackWait = new WaitForSeconds(attackTime);

        for (int i = 0; i < 3; i++)
        {
            SpawnBullet(2);
            yield return attackWait;
        }
    }

    private IEnumerator LaserAttack()
    {
        GameObject spawnLaser = Instantiate(laserObject);
        spawnLaser.transform.position = transform.position;
        yield return patternWait;
        Destroy(spawnLaser);
    }

    //private IEnumerator MissileAttack()
    //{
    //    float attackTime = monsterAttackData[3].attackTime;
    //    WaitForSeconds attackWait = new WaitForSeconds(attackTime);

    //    missilePos[0] = transform.position;
    //    missilePos[1] = Player.Instance.transform.position + new Vector3(0, 3, 0);
    //    missilePos[2] = Player.Instance.transform.position;

    //    for (int i = 0; i < 2; i++)
    //    {
    //        GameObject spawnMissileBullet = Instantiate(monsterAttackData[3].bullet);
    //        spawnMissileBullet.GetComponent<MissileBullet>().MisslePos = missilePos;
    //        yield return attackWait;
    //    }
    //}
}
