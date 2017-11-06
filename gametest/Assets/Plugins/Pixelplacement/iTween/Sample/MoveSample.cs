using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", -10.0f, "time",1.5f, "delay",0 ,"easetype", iTween.EaseType.easeInOutCubic ));
	}
}

