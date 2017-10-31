using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour {


    public GameObject[] pos;
    public GameObject bullet;
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수

    public GameObject[] Shortpos;
    public GameObject Shortbullet;
    public float ShortFireDelay;
    private bool ShortFireState;

	private bool final_FireState;
	public float final_FireDelay;  

    public AudioClip sfx;
    public AudioSource audioSource;

	public Transform tr;
	public GameObject effect;
    public GameObject Final_Effect;


    void Start()
    {
        FireState = true;
        ShortFireState = true;
		final_FireState = true;
    }
    void Update ()
    {   
        if(FireState == true)
            Fire();
        if(ShortFireState == true)
            ShortFire();
		if(final_FireState == true)
        	FinalFire(); 
    }

    void Fire()
    {
        if (FireState)
        {
            if (Input.GetKey("a"))
            {
                StartCoroutine(FireCycleControl());
                audioSource.PlayOneShot(sfx, 0.3f);
				for (int i = 0; i < Player_Control.BulletStack; i++)
                {
                    Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
                }
            }
            
        }
    }

    void ShortFire()
    {
        if (ShortFireState)
        {
            if (Input.GetKey("s"))
            {
                StartCoroutine(ShortFireCycleControl());
                audioSource.PlayOneShot(sfx, 0.3f);
				Instantiate(effect, tr.position, Quaternion.identity); // 쇼트불렛 이펙트
                for (int i = 0; i < pos.Length; i++)
                {
                    Debug.Log("S");
                    Instantiate(Shortbullet, pos[i].transform.position, pos[i].transform.rotation); //쇼트불렛만들기
                }
            }

        }
    }
    void FinalFire()
    {
		if (final_FireState) {
			if (Input.GetKeyDown("d")) {
				StartCoroutine(final_FireCycleControl());
				if (Player_Control.FinalStack > 0) {
					Instantiate (Final_Effect, tr.position * 0, Quaternion.identity);
					Player_Control.FinalStack = Player_Control.FinalStack - 1;			
					Debug.Log (Player_Control.FinalStack);

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

	IEnumerator FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(FireDelay);
		// FireState를 true로 만든다.
		FireState = true;
	}
	IEnumerator ShortFireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		ShortFireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(ShortFireDelay);
		// FireState를 true로 만든다.
		ShortFireState = true;
	}
	IEnumerator final_FireCycleControl()
	{
		// 처음에 FireState를 false로 만들고
		final_FireState = false;
		// FireDelay초 후에
		yield return new WaitForSeconds(final_FireDelay);
		// FireState를 true로 만든다.
		final_FireState = true;
	}
}
    
