using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int attackDamage;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        LaserRotate();
    }

    private void LaserRotate()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(LaserAttack(player));
        }
    }

    IEnumerator LaserAttack(Player player)
    {
        Debug.Log("Player");
        player.TakeDamage(attackDamage);
        yield return new WaitForSeconds(0.5f);
    }
}
