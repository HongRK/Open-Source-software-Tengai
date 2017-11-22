using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletControl : MonoBehaviour
{
    public Transform tr;
    private float destroyXpos = -14f;
    private float destroyYpos = -7f;
    private void Awake()
    {
        destroyXpos = -14f;
        destroyYpos = -7f;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.CompareTag("Player"))
			Destroy(this.gameObject);
    }
    private void Update()
    {
        if (tr.position.x < destroyXpos || tr.position.y >-destroyYpos || tr.position.y<destroyYpos)
        {
            Destroy(this.gameObject);
        }
    }

}
