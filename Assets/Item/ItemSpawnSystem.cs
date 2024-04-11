using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnSystem : MonoSigleton<ItemSpawnSystem>
{
    [SerializeField] private GameObject[] items;

    public void SpawnItem(Vector3 pos)
    {
        int randomItem = Random.Range(0, items.Length);
        GameObject spawnItem = Instantiate(items[randomItem]);
        spawnItem.transform.position = pos;
    }
}
