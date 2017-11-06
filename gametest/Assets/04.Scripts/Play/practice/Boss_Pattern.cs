using UnityEngine;
using System.Collections;

public class Boss_Pattern : MonoBehaviour
{
	public GameObject Boss_bullet;
	public GameObject[] pos;
	public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
	private bool FireState;
	public static int bullet_1 = 7;
	public static bool MoveState = false;
	// Use this for initialization

	// Boss Pattern
	public float time = 0;
	public Transform tr;
	public GameObject[] SpellLev;
	public GameObject Spell;



	void Start()
	{
		FireState = true;
	}
	void Update()
	{
		{
			if (FireState == true ) {
				Fire ();
			}
		}
	}

	void Fire()
	{
		if (FireState && MoveState)
		{
			if (true)
			{
				StartCoroutine(FireCycleControl());

				for (int i = 0; i < bullet_1; i++)
				{
					Instantiate(Boss_bullet, pos[i].transform.position, pos[i].transform.rotation);
				}
			}

		}

	}

	void Charge()
	{
		if (MoveState) {
			iTween.MoveBy (gameObject, iTween.Hash ("x", -10.0f, "time", 3.0f, "delay", 0.5f, "x", 10.0f));
		}
	}




	IEnumerator FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(FireDelay);
		// FireState를 true로 만든다.
		FireState = true;
	}
}

