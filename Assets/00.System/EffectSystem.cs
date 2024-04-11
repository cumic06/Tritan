using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private WaitForSeconds destroyWait;

    private void Awake()
    {
        destroyWait = new WaitForSeconds(destroyTime);
    }

    private void Start()
    {
        StartCoroutine(nameof(DestroyEffect));
    }

    IEnumerator DestroyEffect()
    {
        yield return destroyWait;
        Destroy(gameObject);
    }
}
