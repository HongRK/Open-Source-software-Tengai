﻿using UnityEngine;

public class Enemy_Missile_Move : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날라가는 속도
    public float DestroyXPos;   // 미사일이 사라지는 지점

    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.x <= DestroyXPos)
        {
            // 미사일을 제거
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("충돌");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}