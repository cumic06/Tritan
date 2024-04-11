using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string useString;

    protected virtual void OnTriggerEnter(Collider other)
    {
        bool player = other.CompareTag("Player");

        if (player)
        {
            OnEat();
        }
    }

    protected virtual void FixedUpdate()
    {
        transform.Translate(3 * Time.deltaTime * Vector3.back);
        if (transform.position.z <= -6)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnEat()
    {
        InGameUIManager.Instance.UseItemImage(useString);
        Destroy(gameObject);
    }
}
