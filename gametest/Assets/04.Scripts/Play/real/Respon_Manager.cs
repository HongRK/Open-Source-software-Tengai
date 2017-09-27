﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respon_Manager : MonoBehaviour {


    public GameObject obj;
    public Transform ResponTr;
	public float Respawn_Cycle;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(ResponEnemy());
	}

    IEnumerator ResponEnemy()
    {
        while (true)
        {
			yield return new WaitForSeconds(Respawn_Cycle);
            float range = Screen.width / Screen.height * Camera.main.orthographicSize; //
            Instantiate(obj, ResponTr.position + new Vector3(0, Random.Range(-range, range) , 0), Quaternion.identity);
        }
    }
	
	
}
