using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportOur : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private int bombCount;

    [SerializeField] private Vector3 movePos;

    private void Start()
    {
        StartCoroutine(SupportMove());
        StartCoroutine(DestroyThis());
        StartCoroutine(DropBomb());
    }

    private IEnumerator SupportMove()
    {
        yield return null;

        for (float t = 0; t < 1; t += Time.deltaTime * 0.015f)
        {
            transform.position = Vector3.Lerp(transform.position, movePos, t);
            yield return null;
        }
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    private IEnumerator DropBomb()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i <= bombCount; i++)
        {
            int x = Random.Range(-11, 11);
            int z = Random.Range(-3, 8);

            GameObject spawnBomb = Instantiate(bomb);
            spawnBomb.transform.position = new Vector3(x, 0, z);
        }
    }
}
