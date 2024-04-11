using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerAttackMent : MonoBehaviour
{
    private WaitForSeconds attackWait;
    [SerializeField] private List<AttackData> attackData = new();
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject[] pets;
    [SerializeField] private Transform youdoPos;

    private Coroutine[] attackCor = new Coroutine[4];

    private void Start()
    {
        StartCoroutine(nameof(Attack));
    }

    IEnumerator Attack()
    {
        while (true)
        {
            for (int i = 0; i < attackCor.Length; i++)
            {
                if (attackCor[i] != null)
                {
                    StopCoroutine(attackCor[i]);
                    yield return null;
                }
            }

            if (Input.GetMouseButton(0))
            {
                switch (Player.Instance.Level)
                {
                    case 0:
                        attackCor[0] = StartCoroutine(nameof(Lvl1Attack));
                        for (int i = 0; i < pets.Length; i++)
                        {
                            pets[i].SetActive(false);
                        }
                        break;
                    case 1:
                        attackCor[0] = StartCoroutine(nameof(Lvl1Attack));
                        attackCor[1] = StartCoroutine(nameof(Lvl2Attack));
                        for (int i = 0; i < pets.Length; i++)
                        {
                            pets[i].SetActive(false);
                        }
                        break;
                    case 2:
                        attackCor[0] = StartCoroutine(nameof(Lvl1Attack));
                        attackCor[1] = StartCoroutine(nameof(Lvl2Attack));
                        for (int i = 0; i < pets.Length; i++)
                        {
                            pets[i].SetActive(true);
                        }
                        attackCor[2] = StartCoroutine(nameof(Lvl3Attack));
                        break;
                    case 3:
                        attackCor[0] = StartCoroutine(nameof(Lvl1Attack));
                        attackCor[1] = StartCoroutine(nameof(Lvl2Attack));
                        attackCor[2] = StartCoroutine(nameof(Lvl3Attack));
                        attackCor[3] = StartCoroutine(nameof(Lvl4Attack));
                        break;
                }
            }
            yield return new WaitForSeconds(attackData[0].attackTime);
        }
    }

    private IEnumerator Lvl1Attack()
    {
        attackWait = new WaitForSeconds(attackData[0].attackTime);
        GameObject spawnBullet = Instantiate(attackData[0].bullet);
        spawnBullet.transform.position = bulletPos.position;
        yield return attackWait;
    }

    private IEnumerator Lvl2Attack()
    {
        attackWait = new WaitForSeconds(attackData[1].attackTime);
        for (int i = 0; i < attackData[1].bulletCount; i++)
        {
            for (int j = -1; j < 2; j += 2)
            {
                GameObject spawnBullet = Instantiate(attackData[0].bullet);
                spawnBullet.transform.SetPositionAndRotation(bulletPos.position, Quaternion.Euler(new Vector3(90, 0, attackData[1].attackAngle * j)));
                yield return null;
            }
        }
        yield return attackWait;
    }

    private IEnumerator Lvl3Attack()
    {
        attackWait = new WaitForSeconds(attackData[1].attackTime);
        for (int i = 0; i < pets.Length; i++)
        {
            pets[i].SetActive(true);
            GameObject spawnBullet = Instantiate(attackData[0].bullet);
            spawnBullet.transform.position = pets[i].transform.position;
            yield return null;
        }
        yield return attackWait;
    }

    private IEnumerator Lvl4Attack()
    {
        GameObject spawnMissleBullet = Instantiate(attackData[3].bullet);
        spawnMissleBullet.transform.position = youdoPos.position;
        yield return null;
    }
}