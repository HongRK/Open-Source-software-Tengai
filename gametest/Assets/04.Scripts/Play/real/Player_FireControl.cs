using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FireControl : MonoBehaviour {

    private Transform Player;

    public GameObject[] Normal_Pos;
    public GameObject Normal_bullet;
    private float Normal_FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool Normal_FireState;             // 미사일 발사 속도를 제어할 변수

    public GameObject[] Short_Pos;
    public GameObject Short_bullet;
    private float Short_FireDelay;
    private bool Short_FireState;

	private bool Final_FireState;
    private float Final_FireDelay;


	public GameObject Short_Effect;
    public GameObject Final_Effect;
    
    private int BulletStack;
    private int FinalStack;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Normal_FireDelay = 0.1f;
        Short_FireDelay = 0.3f;
        Final_FireDelay = 1f;
        Normal_FireState = true;
        Short_FireState = true;
		Final_FireState = true;
    }
    void Update ()
    {   
        if(Normal_FireState == true)
            Normal_Fire();
        if(Short_FireState == true)
            Short_Fire();
		if(Final_FireState == true)
        	Final_Fire();
        BulletStack = GameObject.Find("/Player").GetComponent<Player_Control>().GetBulletStack();
        FinalStack = GameObject.Find("/Player").GetComponent<Player_Control>().GetFinalStack();

    }

    void Normal_Fire()
    {
        if (Normal_FireState)
        {
            if (Input.GetKey("a"))
            {
                StartCoroutine(Normal_FireCycleControl());
				for (int i = 0; i < BulletStack; i++)
                {
                    Instantiate(Normal_bullet, Normal_Pos[i].transform.position, Normal_Pos[i].transform.rotation);
                }
            }
            
        }
    }
    void Short_Fire()
    {
        if (Short_FireState)
        {
            if (Input.GetKey("s"))
            {
                StartCoroutine(Short_FireCycleControl());
				Instantiate(Short_Effect, Player.position, Quaternion.identity); // 쇼트불렛 이펙트
                for (int i = 0; i < Short_Pos.Length; i++)
                {
                    Instantiate(Short_bullet, Short_Pos[i].transform.position, Short_Pos[i].transform.rotation); //쇼트불렛만들기
                }
            }

        }
    }
    void Final_Fire()
    {
		if (Final_FireState) {
			if (Input.GetKeyDown("d")) {
				StartCoroutine(Final_FireCycleControl());
				if (FinalStack > 0) {
					Instantiate (Final_Effect, Player.position * 0, Quaternion.identity);
                    GameObject.Find("/Player").GetComponent<Player_Control>().SetFinalStack();
                    Debug.Log (FinalStack);
                    var Final_Stack =GameObject.FindGameObjectsWithTag("Final_Icon");
                    foreach (var FinalStack in Final_Stack)
                    {
                        Destroy(FinalStack);
                    }
					var objects = GameObject.FindGameObjectsWithTag ("EnemyMissile");
					foreach (var enemy in objects) {
						Destroy (enemy);
					}
					objects = GameObject.FindGameObjectsWithTag ("Enemy");
					foreach (var enemy in objects) {
						Destroy (enemy);
					}
				}
			}
		}
   	}

	IEnumerator Normal_FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		Normal_FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(Normal_FireDelay);
		// FireState를 true로 만든다.
		Normal_FireState = true;
	}
	IEnumerator Short_FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		Short_FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(Short_FireDelay);
		// FireState를 true로 만든다.
		Short_FireState = true;
	}
	IEnumerator Final_FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		Final_FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(Final_FireDelay);
		// FireState를 true로 만든다.
		Final_FireState = true;
	}
}