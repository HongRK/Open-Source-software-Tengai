using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Laser : MonoBehaviour {

    private GameObject Boss_Laser_Bullet;
	
	void Awake () {
        Boss_Laser_Bullet = GameObject.FindGameObjectWithTag("EnemyLaser");
	}
	
	void Update () {
        Boss_Laser_Bullet.transform.localScale += new Vector3(14, 0, 0);
        GameObject.FindGameObjectWithTag("EnemyLaser").GetComponent<BoxCollider2D>().size += new Vector2(14, 0);
        Destroy(this.gameObject, 1.7f);
	}
}
