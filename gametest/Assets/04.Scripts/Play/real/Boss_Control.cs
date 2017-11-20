using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss_Control : MonoBehaviour
{
	public static int hp = 500;
	public Transform tr;
	public GameObject effect;

    GameObject Hp;


    private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag("PlayerMissile"))
        {
            hp--;
            //Manager.hp_Bar.value -= 1;
        }
			
		if (coll.CompareTag("PlayerShortMissile"))
        {
            hp -= 1;
            //Manager.hp_Bar.value -= 1;
        }
			

		if (hp <= 0)
		{
			Manager.score += 100;
			Instantiate(effect, tr.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}


	private void Update()
	{
		
	}
}

