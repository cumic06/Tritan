using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSystem : MonoBehaviour
{
    [SerializeField] private Vector3 boxSize;
    private void Update()
    {
        if (GameManager.Instance.CurrentGameStopPlay == GameStopPlay.GamePlay)
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                AllKillCheat();
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                HealCheat();
            }

            TimeCheat();
        }
    }

    private void AllKillCheat()
    {
        Collider[] checkMonster = Physics.OverlapBox(transform.position, boxSize);
        foreach (var check in checkMonster)
        {
            if (check.TryGetComponent(out Monster monster))
            {
                monster.TakeDamage(100);
            }

            if (check.TryGetComponent(out Bullet bullet))
            {
                if (bullet.GetTeamType() == TeamType.Enemy)
                {
                    Destroy(bullet.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void HealCheat()
    {
        Player.Instance.TakeHeal(999);
    }


    private void TimeCheat()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameSpeedSystem.Instance.GameTimeScale(4);
        }
        if (Input.GetKeyUp(KeyCode.F7))
        {
            GameSpeedSystem.Instance.GameTimeScale(1);
        }
    }
}
