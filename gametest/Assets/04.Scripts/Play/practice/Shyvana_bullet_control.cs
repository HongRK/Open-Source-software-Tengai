using UnityEngine;
using System.Collections;

public class Shyvana_bullet_control : MonoBehaviour
{
	public Transform tr;
	public float destroyXpos;
	void OnTriggerEnter2D(Collider2D coll)
	{
		
	}
	private void Update()
	{
		if(tr.position.x>destroyXpos)
		{
			Destroy(this.gameObject);
		}
	}
}

