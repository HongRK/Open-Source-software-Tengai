using UnityEngine;
using System.Collections;

public class Boss_Shot_Control : MonoBehaviour {

	public float oneShoting;
	public GameObject bullet;
	public GameObject stage1_Boss;
	public float speed;


	IEnumerator SpellStart()
	{
		float NGLE = 360 / oneShoting;

		do{ 

			for(int i =0;i<oneShoting;i++) 
			{ Debug.Log(i); 
				GameObject obj; 
				obj=(GameObject)Instantiate(bullet,stage1_Boss.transform.position,Quaternion.identity); 

				//보스의 위치에 bullet을 생성합니다.
				obj.GetComponent<Rigidbody2D>().AddForce( new Vector2(speed*Mathf.Cos(Mathf.PI*2*i/oneShoting),speed*Mathf.Sin(Mathf.PI*i*2/oneShoting)));


				obj.transform.Rotate(new Vector3(0f,0f,360*i/oneShoting -90)); 
			} 



			//지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

			yield return new WaitForSeconds(1f); 
		}while(true); 
	}


	void Start(){
		SpellStart ();
	}

	void Update(){
	}



}



