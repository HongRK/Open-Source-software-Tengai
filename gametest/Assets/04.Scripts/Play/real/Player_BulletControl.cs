using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletControl : MonoBehaviour {

    public Transform tr;
    private float destroyXpos;
    private void Awake()
    {
        destroyXpos = 22;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
           Destroy(this.gameObject);
		if (coll.CompareTag("Boss"))
			Destroy(this.gameObject);
    }
    private void Update()
    {
        if(tr.position.x>destroyXpos)
        {
            Destroy(this.gameObject);
        }
    }
}
