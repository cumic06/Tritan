using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeSystem : MonoSigleton<CameraShakeSystem>
{
    private Vector3 originPos;
    private void Start()
    {
        originPos = transform.position;
    }

    public void ShakeCamera(float shakeTime, float shakeValue)
    {

        StartCoroutine(Shake());
        IEnumerator Shake()
        {
            float time = 0;

            while (shakeTime >= time)
            {
                Camera.main.transform.localPosition = Random.insideUnitSphere * shakeValue + originPos;
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}
