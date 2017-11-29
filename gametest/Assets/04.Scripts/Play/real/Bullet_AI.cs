using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AI : MonoBehaviour {
    private GameObject player;
    public GameObject bullet;
    private float speed;

    void Awake () {
        player = GameObject.Find("Player");
        speed = 7.0f;
    }
	
	void Update () {
        float mx = player.transform.position.x;
        float my = player.transform.position.y;

        float x = bullet.transform.position.x;
        float y = bullet.transform.position.y;

        float d = Mathf.Sqrt((mx - x) * (mx - x) + (my - y) * (my - y));


        float vx, vy, vx0, vy0, vx1, vy1, vx2, vy2, vx3, vy3;
        vx = -1.0f; vy = 0.0f;
        vx0 = vx; vy0 = vy;
        float theta = 1.0f ;
        

        if (d != 0.0)
        {
            vx1 = (mx - x) / d * speed;
            vy1 = (my - y) / d * speed;
        }
        else
         {
            vx1 = 0.0f;
            vy1 = speed;
        }

        float rad = Mathf.PI / 180 * theta;
        vx2 = Mathf.Cos(rad) * vx0 - Mathf.Sin(rad) * vy0;
        vy2 = Mathf.Sin(rad) * vx0 + Mathf.Cos(rad) * vy0;

        if (vx0 * vx1 + vy0 * vy1 >= vx0 * vx2 + vy0 * vy2)
        {
          vx = vx1;
          vy = vy1;
        }
        else
        {
            vx3 = Mathf.Cos(rad) * vx0 + Mathf.Sin(rad) * vy0;
            vy3 = -1 * Mathf.Sin(rad) * vx0 + Mathf.Cos(rad) * vy0;
        
            float px = mx - x, py = my - y;
        
            if (px * vx2 + py * vy2 >= px * vx3 + py * vy3)
            {
                vx = vx2;
                vy = vy2;
            }
            else
            {
                vx = vx3;
                vy = vy3;
            }
        }
        vx += x;
        vy += y;
        bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, new Vector3(vx, vy, 0), speed * Time.deltaTime);
    }
}
