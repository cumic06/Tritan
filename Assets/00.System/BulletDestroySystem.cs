using UnityEngine;

public class BulletDestroySystem : MonoBehaviour
{
    public float distance;

    private void FixedUpdate()
    {
        if (transform.position.sqrMagnitude > distance * distance)
        {
            Destroy(gameObject);
        }
    }
}
