using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss_Control : MonoBehaviour
{
    public static int hp;
	public Transform tr;
	public GameObject effect;

 

    private void Awake()
    {
        hp = 500;
    }
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
            GameObject.Find("/GameManager").GetComponent<Manager>().SetScore_Boss();
            Instantiate(effect, tr.position, Quaternion.identity);
			Destroy(this.gameObject);
            
		}
	}
}

