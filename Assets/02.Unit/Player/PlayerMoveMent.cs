using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
            ClampMove();
            PlayerAngle();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    private void Move()
    {
        transform.Translate(player.CurrentMoveSpeed * Time.deltaTime * GetMoveVec());
    }

    private Vector3 GetMoveVec()
    {
        Vector3 moveVec = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized;
        return moveVec;
    }

    private void ClampMove()
    {
        float LimitX = Mathf.Clamp(transform.position.x, -5f, 5f);
        float LimitZ = Mathf.Clamp(transform.position.z, -2.5f, 8.3f);

        transform.position = new Vector3(LimitX, 0, LimitZ);
    }

    private void PlayerAngle()
    {
        transform.rotation = Quaternion.Euler(Input.GetAxis("Horizontal") * 15, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
