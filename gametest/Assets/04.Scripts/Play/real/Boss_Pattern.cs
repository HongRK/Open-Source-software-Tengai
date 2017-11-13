using UnityEngine;
using System.Collections;

public class Boss_Pattern : MonoBehaviour
{
    public Transform Boss;
    public float speed = 10f;
    // Update is called once per frame
    float starttime;
    float distance;

    Vector3 target;
    Vector3 start;

    public GameObject Boss_bullet;
	public GameObject[] pos;
	public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
	private bool FireState;
	int Num_BossBullet = 7;
	bool Arrive_State = false; //처음에 도착햇는지 나타냄
	// Use this for initializati

    bool a = true;

	void Start()
	{
		FireState = true;

        start = Boss.position;
        target = new Vector3(8, 2, 0);
        starttime = Time.time;
        distance = Vector3.Distance(start, target);


    }
    void Update()
	{
        Fire();
        Dash();
        First_BossMove();
    }

    void First_BossMove()
    {
        if (Arrive_State == false)
        {
            float discovered = (Time.time - starttime) * speed;
            float franjouney = discovered / distance;
            Boss.position = Vector3.Lerp(start, target, franjouney);
            if (Boss.position.x == target.x)
            {
                Arrive_State = true;
            }
        }

    }
    void Fire()
	{
		if (FireState && Arrive_State)////도착 했으면 쏘기 시작함
		{
		    StartCoroutine(FireCycleControl());
            for (int i = 0; i < Num_BossBullet; i++)
            {
                Instantiate(Boss_bullet, pos[i].transform.position, pos[i].transform.rotation);
            }
        }
	}

	void Dash()
	{
        if(Arrive_State == true) //도착 했으면 왕복운동 시작함
        {
            //bool a = true;
            float speed = 15.0f;
            if (a == true)
            {
                transform.Translate(-Vector3.right* Time.deltaTime * speed);
                if (transform.position.x < -2.0f)
                {
                    a = false;
                }
            }
            else if (a == false)
            {             
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (transform.position.x > 10.0f)
                {
                    a = true;
                }
            }
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

