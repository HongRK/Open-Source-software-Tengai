using UnityEngine;
using System.Collections;

public class Boss_Pattern : MonoBehaviour
{
    public Transform Boss;
    public float speed = 10f;
    float starttime;
    float distance;

    Vector3 target = new Vector3(8,2,0);
    Vector3 start;

    public GameObject Boss_bullet;
	public GameObject[] pos;
	public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState = true;
	int Num_BossBullet = 7;
    // Use this for initializati
    bool Arrive_State = false; //처음에 도착햇는지 나타냄
    bool DashState = true;  // 왕복 운동 도착 했는지를 나타냄
    bool PatternState = true;
    public float PatternDelay;
    int PatternInt = -1;

    public GameObject Boss_Laser;
    public GameObject Boss_Laser_Effect;
    float timespan;
    float checktime = 3f;
	void Start()
	{
        start = Boss.position;
        starttime = Time.time;
        distance = Vector3.Distance(start, target);
    }
    void Update()
	{
        First_BossMove();


        if (Pattern()==0)
            Fire();
        if(Pattern()==1)
            Dash();
        if (Pattern() == 2)
            Laser();
    }

    int Pattern()
    {
        if (PatternState && Arrive_State)
        {
            StartCoroutine(PatternCycleControl());
            PatternInt =  Random.Range(0, 3);
            return PatternInt;
        }
        return PatternInt;
    }
    IEnumerator PatternCycleControl()
    {
        PatternState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(PatternDelay);
        // FireState를 true로 만든다.
        PatternState = true;
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
    void Laser()
    {
        timespan += Time.deltaTime;

        if (transform.position.x > 9f)
        {
            if (timespan < checktime)
                Debug.Log("알림");
            if (timespan > checktime)
            {
                if (GameObject.FindGameObjectWithTag("EnemyLaser") == null)
                {
                    Instantiate(Boss_Laser, Boss_Laser.transform.position, Boss_Laser.transform.rotation);
                    Instantiate(Boss_Laser_Effect, Boss_Laser_Effect.transform.position, Boss_Laser.transform.rotation);
                    timespan = 0;
                }
            }
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
	void Dash()
	{
         
            float speed = 15.0f;
            if (DashState == true)
            {
                transform.Translate(-Vector3.right* Time.deltaTime * speed);
                if (transform.position.x < -2.0f)
                {
                    DashState = false;
                }
            }
            else if (DashState == false)
            {             
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (transform.position.x > 10.0f)
                {
                    DashState = true;
                }
            }
        
        
    }
    void Fire()
    {
        if (transform.position.x > 9f)
        {
            if (FireState)////도착 했으면 쏘기 시작함
            {
                StartCoroutine(FireCycleControl());
                for (int i = 0; i < Num_BossBullet; i++)
                {
                    Instantiate(Boss_bullet, pos[i].transform.position, pos[i].transform.rotation);
                }
            }
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
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

