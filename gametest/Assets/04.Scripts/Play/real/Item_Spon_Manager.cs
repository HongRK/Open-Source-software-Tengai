using UnityEngine;
using System.Collections;

public class Item_Spon_Manager : MonoBehaviour
{

	public GameObject obj;
	public Transform ResponTr;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(ResponEnemy());
	}

	IEnumerator ResponEnemy()
	{
		while (true)
		{
			yield return new WaitForSeconds(9.0f);
			float range = Screen.width / Screen.height * Camera.main.orthographicSize; //
			Instantiate(obj, ResponTr.position + new Vector3(0, Random.Range(-range, range) , 0), Quaternion.identity);
		}
	}
}

