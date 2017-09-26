using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveControl : MonoBehaviour {


    public Transform tr;
    public float speed = 10f;
    // Update is called once per frame
    float starttime;
    float distance;
    Vector3 target;
    Vector3 start;

    void Start()
    {
        start = tr.position;
        target = new Vector3(8, 0, 0);
        starttime = Time.time;
        distance = Vector3.Distance(start, target);
        Debug.Log("Debug");
    }

    void Update ()
    {
        float discovered = (Time.time - starttime) * speed;
        float franjouney = discovered / distance;
        tr.position = Vector3.Lerp(start, target, franjouney);
	}
}
