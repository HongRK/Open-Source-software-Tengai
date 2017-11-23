using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respon_Manager : MonoBehaviour {


    public GameObject obj;
    public Transform ResponTr;
	public float Respawn_Cycle;
    public int Respawn_Scale;
    public float Respawn_InnerDelay;

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
            float range = Screen.width / Screen.height * Camera.main.orthographicSize; 
			float y_range = Random.Range(-range,range);

            for (int monsters = 0; monsters < Respawn_Scale; monsters++)
            {
                yield return new WaitForSeconds(Respawn_InnerDelay);
                Instantiate(obj, ResponTr.position + new Vector3(range, y_range, 0), Quaternion.identity);
            }
        }
    }

}
