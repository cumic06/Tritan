using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MonsterSpawnData", menuName = "MonsterSpawnData", order = 0)]
public class MonsterSpawnData : ScriptableObject
{
    public List<MonsterSpawnInfo> monsterSpawns = new();
}

[Serializable]
public class MonsterSpawnInfo
{
    public MonsterType monsterType;
    public GameObject monsterPrefab;
    public float spawnTime;
    public Vector3 spawnPoint;
}