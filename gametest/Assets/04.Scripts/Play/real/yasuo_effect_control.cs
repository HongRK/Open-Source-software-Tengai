using UnityEngine;
using System.Collections;

public class yasuo_effect_control : MonoBehaviour
{
    private float Speed = 7f;

    private void Awake()
    {
        Speed = 10f;
    }
    void Update()
	{
		Move ();
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.UpArrow))  // ↑ 방향키를 누를 때
		{
			// Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다.
			transform.Translate(Vector2.up * Speed * Time.deltaTime);
			// Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
		}
		if (Input.GetKey(KeyCode.DownArrow))  // ↓ 방향키를 누를 때
		{
			transform.Translate(Vector2.down * Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
		{
			transform.Translate(Vector2.right * Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
		{
			transform.Translate(Vector2.left * Speed * Time.deltaTime);
		}
	}
}

