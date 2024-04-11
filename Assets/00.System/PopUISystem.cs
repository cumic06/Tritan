using System.Collections;
using UnityEngine;

public class PopUISystem : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Start()
    {
        StartCoroutine(nameof(DestroyUI));
        StartCoroutine(nameof(UpPos));
    }

    IEnumerator DestroyUI()
    {
        WaitForSeconds destroyWait = new WaitForSeconds(destroyTime);

        yield return destroyWait;
        Destroy(gameObject);
    }

    IEnumerator UpPos()
    {
        int upSpeed = 40;

        while (true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * upSpeed);
            yield return new WaitForFixedUpdate();
        }
    }
}
