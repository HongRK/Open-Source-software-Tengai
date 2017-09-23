using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAttack_Control : MonoBehaviour {

       
    void Start()
    {
        Invoke("destroy", 1.5f);
    }
    void destroy()
    {
        Destroy(this.gameObject);
    }

}