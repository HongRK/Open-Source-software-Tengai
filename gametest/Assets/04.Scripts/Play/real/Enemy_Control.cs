﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour {

    public int hp = 5;
	public Transform tr;
    public GameObject effect;
    float destroyXpos = -14;
    float destroyYpos = -7f;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PlayerMissile"))
            hp--;


        if (coll.CompareTag("PlayerShortMissile"))
            hp -= 5;
        
        if (hp <= 0)
        {
            Manager.score += 100;
            Instantiate(effect, tr.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


        private void Update()
    {
        if (tr.position.x < destroyXpos || tr.position.y < destroyYpos)
        {
            Destroy(this.gameObject);
        }
    }
}
