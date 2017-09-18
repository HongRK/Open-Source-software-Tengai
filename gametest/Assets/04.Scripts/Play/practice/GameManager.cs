using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // 핸드폰 화면 안꺼지게
        Screen.SetResolution(600, 1024, true); // 화면 해상도 고정
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
