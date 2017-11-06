using UnityEngine;
using System.Collections;

public class Boss_Control : MonoBehaviour
{
	public int hp = 30;
	public Transform tr;
	public GameObject effect;



	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag("PlayerMissile"))
			hp--;


		if (coll.CompareTag("PlayerShortMissile"))
			hp -= 1;

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

