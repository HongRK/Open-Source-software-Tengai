using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitalflight2 : MonoBehaviour
{
    GameObject Enemy;   
    void Start()
    {
        
    }
    void Update()
    {
        float speed = 5.0f;
        float h = -2 * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + h, transform.position.y);
    }
}
