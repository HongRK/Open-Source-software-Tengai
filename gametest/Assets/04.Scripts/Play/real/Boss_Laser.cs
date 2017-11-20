using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Laser : MonoBehaviour {
    GameObject Boss_Laser_Bullet;

	// Use this for initialization
	void Start () {
        Boss_Laser_Bullet = GameObject.FindGameObjectWithTag("EnemyLaser");
	}
	
	// Update is called once per frame
	void Update () {
        Boss_Laser_Bullet.transform.localScale += new Vector3(14, 0, 0);
        Destroy(this.gameObject, 1.7f);

	}
}
