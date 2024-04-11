using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnSystem : MonoSigleton<MonsterSpawnSystem>
{
    [SerializeField] private MonsterSpawnData monsterSpawnData;

    [SerializeField] private float bossSpawnTime;
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform bossPos;

    [SerializeField] private Vector3 boxSize;

    public bool isBossSpawn = false;

    private void Start()
    {
        StartCoroutine(nameof(SpawnMonster));
        StartCoroutine(nameof(SpawnBoss));
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            if (!isBossSpawn)
            {
                int randomSpawn = Random.Range(0, monsterSpawnData.monsterSpawns.Count);
                GameObject spawnMonster = Instantiate(monsterSpawnData.monsterSpawns[randomSpawn].monsterPrefab);
                spawnMonster.transform.position = monsterSpawnData.monsterSpawns[randomSpawn].spawnPoint;
                yield return new WaitForSeconds(monsterSpawnData.monsterSpawns[randomSpawn].spawnTime);
            }
            yield return null;
        }
    }

    IEnumerator SpawnBoss()
    {
        while (true)
        {
            if (TimeManager.Instance.currentTime + (TimeManager.Instance.Min * 60) >= bossSpawnTime && !isBossSpawn && GameManager.Instance.CurrentGameStopPlay != GameStopPlay.GameStop)
            {
                Debug.Log("hi");
                StopCoroutine(nameof(SpawnMonster));
                GameObject spawnBoss = Instantiate(boss);
                spawnBoss.transform.position = bossPos.position;
                isBossSpawn = true;
                yield break;
            }
            yield return null;
        }
    }

    private void FindMonster()
    {
        Collider[] checkMonsterCol = Physics.OverlapBox(transform.position, boxSize);
        foreach (var checkCol in checkMonsterCol)
        {
            if (checkCol.TryGetComponent(out Monster monster))
            {
                foreach (var data in monsterSpawnData.monsterSpawns)
                {

                }
            }
        }
    }
}
