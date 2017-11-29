using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    private Transform Player;  //플레이어의 위치값
    public GameObject effect;
    private float Speed;
    private int hp;
    private int initHp;
    private int life;
    public static int Rank_Life;
	private int BulletStack;
	private int FinalStack;
	private Vector3 Respawn;

    public int GetBulletStack()
    {
        return BulletStack;
    }
    public int GetFinalStack()
    {
        return FinalStack;
    }
    public void SetFinalStack()
    {
        FinalStack -=1;
    }
    public int GetLife()
    {
        return life;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Speed = 10f;
        initHp = 25;
        hp = initHp;
        life = 10;
        BulletStack = 1;
        FinalStack = 3;
        Respawn = new Vector3(-25, 0, 0);
    }
    void Update()
    {
        Move();
        Rank_Life = life;
    }
    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        /////////////////////////Y값에 대한 /////////////////////
        float size = Camera.main.orthographicSize;
        float offset = 0.9f;
        if (Player.position.y >= size - offset)
        {
            Player.position = new Vector3(Player.position.x, size - offset, 0);
        }
        if (Player.position.y <= -(size - offset))
        {
            Player.position = new Vector3(Player.position.x, -(size - offset), 0);
        }
        /////////////////////////////////////////////////////
        float ScreenRation = (float)Screen.width / (float)Screen.height;
        float Wsize = Camera.main.orthographicSize * ScreenRation; // 가로 사이즈

        if (Player.position.x >= Wsize - offset)
        {
            Player.position = new Vector3(Wsize - offset, Player.position.y, 0);
        }
        if (Player.position.x <= -(Wsize - offset))
        {
            Player.position = new Vector3(-(Wsize - offset), Player.position.y, 0);
        }
        // 매 프레임마다 메소드 호출

        if (Input.GetKey(KeyCode.UpArrow))  // ↑ 방향키를 누를 때
        {
            // Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다.
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            // Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
        }
        if (Input.GetKey(KeyCode.DownArrow))  // ↓ 방향키를 누를 때
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("EnemyMissile"))
            hp--;
        if (coll.CompareTag("Enemy"))
            hp -= 2;
		if (coll.CompareTag ("Boss"))
			hp -= 5;
        if (coll.CompareTag("EnemyLaser"))
            hp -= 7;
        if (coll.CompareTag("Item"))
        {
            BulletStack++;
            if (BulletStack >= 3)
                BulletStack = 3;
        }
		if (coll.CompareTag ("FinalItem")) {
			FinalStack +=1;
			if (FinalStack > 3)
				FinalStack = 3;
		}
	
        if (hp <= 0)
        {
            life--;
            Instantiate(effect, Player.position, Quaternion.identity);
			Player.position = Respawn;
			hp = initHp;
			BulletStack = 1;
			FinalStack = 3;
 
        }

    }
		

}