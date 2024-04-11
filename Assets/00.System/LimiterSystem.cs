using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiterSystem : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(nameof(Limit));
    }

    IEnumerator Limit()
    {
        WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewPos.x > 1.0f || viewPos.x < 0.0f || viewPos.y > 1.04f || viewPos.y < -0.2f)
            {
                Debug.Log("Limit");
                Destroy(gameObject);
            }
            yield return fixedWait;
        }
    }
}
