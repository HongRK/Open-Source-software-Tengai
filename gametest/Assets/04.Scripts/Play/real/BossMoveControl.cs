using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveControl : MonoBehaviour {


    public Transform Boss;
    public float speed = 10f;
    // Update is called once per frame
    float starttime;
    float distance;
    Vector3 target;
    Vector3 start;



    void Start()
    {
        start = Boss.position;
        target = new Vector3(8, 2, 0);
        starttime = Time.time;
        distance = Vector3.Distance(start, target);
	}

	

    void Update ()
    {
        BossMove();
	}
    void BossMove()
    {
        float discovered = (Time.time - starttime) * speed;
        float franjouney = discovered / distance;
        Boss.position = Vector3.Lerp(start, target, franjouney);
        if (Boss.position.x == target.x)
        {
            Boss_Pattern.MoveState = true;
        }
    }
}
