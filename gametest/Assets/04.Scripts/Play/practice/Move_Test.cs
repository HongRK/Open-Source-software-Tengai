using UnityEngine;
using System.Collections;

public class Move_Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        iTween.MoveBy(gameObject,iTween.Hash("x", -16,"easeType", "easeInOutExpo","loopType", "pingPong","delay", 0.2));


    }

    // Update is called once per frame
    void Update()
    {

    }
}
