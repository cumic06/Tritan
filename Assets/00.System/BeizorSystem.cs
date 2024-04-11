using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeizorSystem : MonoBehaviour
{
    public static Vector3 GetBeizor(Vector3[] transforms, float lerpTime)
    {
        for (int i = transforms.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                transforms[j] = Vector3.Lerp(transforms[j], transforms[j + 1], lerpTime);
            }
        }
        return transforms[0];
    }
}
