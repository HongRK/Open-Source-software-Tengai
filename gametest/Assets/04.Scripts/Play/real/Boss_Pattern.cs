using UnityEngine;
using System.Collections;

public class Boss_Pattern : MonoBehaviour
{
    public Transform Boss;
    private float speed;
    private float starttime;
    private float distance;

    Vector3 target;
    Vector3 start;

    public GameObject Boss_bullet;
	public GameObject[] pos;
	private float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;
	private int Num_BossBullet;
    // Use this for initializati
    private bool Arrive_State; //처음에 도착햇는지 나타냄
    private bool DashState;  // 왕복 운동 도착 했는지를 나타냄
    private bool PatternState;
    private float PatternDelay;
    private int PatternInt;

    public GameObject Boss_Laser;
    public GameObject Boss_Laser_Effect;
    private float timespan;
    private float checktime;
    private float checktime2;

    public GameObject Alarm;
    
    
	void Awake()
	{
        speed = 10f;
        starttime = Time.time;
        target = new Vector3(8, 2, 0);
        distance = Vector3.Distance(start, target);
        start = Boss.position;

        FireState = true;
        Arrive_State = false;
        DashState = true;
        PatternState = true;
        

        Num_BossBullet = 7;
        PatternInt = -1;
        checktime = 4.0f;
        checktime2 = 2.5f;
        FireDelay = 0.3f;
        PatternDelay = 4f;
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
            if (timespan > checktime2 && timespan < checktime)
            {
                Instantiate(Alarm, Alarm.transform.position, Alarm.transform.rotation);
                
            }
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
         
            float speed = 25.0f;
            if (DashState == true)
            {
                transform.Translate(-Vector3.right* Time.deltaTime * speed);
                if (transform.position.x < -10.0f)
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

    IEnumerator PatternCycleControl()
    {
        PatternState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(PatternDelay);
        // FireState를 true로 만든다.
        PatternState = true;
    }
}

