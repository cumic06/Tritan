using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eearth : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("EeathIdleMove", true);
    }
}
