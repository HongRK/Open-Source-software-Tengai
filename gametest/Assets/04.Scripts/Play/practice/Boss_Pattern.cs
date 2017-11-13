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

    public float Fire_Time;
    public float WaitingTime;


	void Start()
	{
        Fire_Time = 0;
        WaitingTime = 4.0f;
		FireState = true;
	}
	void Update()
	{
        Fire();
		
	}

	void Fire()
	{
		if (FireState && MoveState)
		{
			if (true)
			{
				StartCoroutine(FireCycleControl());
                Fire_Time += Time.deltaTime;
                if (Fire_Time < WaitingTime)
                {
                    for (int i = 0; i < bullet_1; i++)
                    {
                        Instantiate(Boss_bullet, pos[i].transform.position, pos[i].transform.rotation);
                    }
                }
                Fire_Time = 0;
			}

		}

	}

	void Charge()
	{
		if (MoveState) {
            iTween.MoveTo(gameObject, iTween.Hash("x", 1f, "speed", 0.01f, "easeType", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
        }
	}

    void Pattern_Cycle()
    {
        int Pattern_Var = Random.Range(0, 1);

        if (Pattern_Var == 0)
            Charge();
        else if (Pattern_Var == 1)
        {
           
                Fire();
            
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

