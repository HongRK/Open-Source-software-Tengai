using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respon_Manager_Vertical : MonoBehaviour {

    public GameObject obj;
    public Transform ResponTr;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ResponEnemy());
    }

    IEnumerator ResponEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            float range = Screen.width / Screen.height * Camera.main.orthographicSize; //
            Instantiate(obj, ResponTr.position + new Vector3( Random.Range(-range, range), 0, 0), Quaternion.identity);
        }
    }
}
