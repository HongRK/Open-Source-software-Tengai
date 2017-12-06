using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour {

    private int hp;
	public Transform tr;
    public GameObject effect;
    private float destroyXpos;
    private float destroyYpos;

    private void Awake()
    {
        hp = 2;
        destroyXpos = -14;
        destroyYpos = -7f;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PlayerMissile"))
            hp--;


        if (coll.CompareTag("PlayerShortMissile"))
            hp -= 5;
        
        if (hp <= 0)
        {
            GameObject.Find("/GameManager").GetComponent<Manager>().SetScore();
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
