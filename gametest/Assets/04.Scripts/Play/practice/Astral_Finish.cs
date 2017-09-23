using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Astral_Finish : MonoBehaviour {

	// Use this for initialization
	// Use this for initialization

	public Transform tr;
	public GameObject effect;

	void AstralFinish()
	{
			if (Input.GetKey("d"))
			{
				Instantiate(effect, tr.position, Quaternion.identity);
			}


	}
}
