using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private float TimeSpan;
    private float CheckTime;
    private bool Boss_State;
    
    public GameObject Boss;
    public Transform BossTr;
    public Text LifeText;
    public Text ScoreText;
    public Text PauseText;
    private bool Pause_state = false;
    public Slider hp_Bar;

    public GameObject Final_Icon;
    
    private int Final_Stack;


    private int life;
    private int score;
    public static int Rank_Score;

    public void SetScore_Boss()
    {
        score += 1000;
    }
    public void SetScore()
    {
        score += 100;
    }
    public int GetScore()
    {
        return score;
    }
    private void Awake()
    {
        TimeSpan = 0.0f;
        CheckTime = 15.0f;
        Boss_State = true;
        hp_Bar.transform.localScale = new Vector3(0, 1, 1);
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // 핸드폰 화면 안꺼지게
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true); // 화면 해상도 16:9
        score = 0;
    }


    // Update is called once per frame
    private void Update()
    {
        life = GameObject.Find("/Player").GetComponent<Player_Control>().GetLife();
        Final_Stack = GameObject.Find("/Player").GetComponent<Player_Control>().GetFinalStack();
        Puase();
        GameOver();
        Show_Final_Stack();
        LifeText.text = "LIFE : " + life.ToString("00");
        ScoreText.text = "SCORE : " + score.ToString("000000");

        TimeSpan += Time.deltaTime;
        
        if (TimeSpan > CheckTime && Boss_State)
        {
            Instantiate(Boss, BossTr.position, Quaternion.identity);
            Boss_State = false;
            hp_Bar.transform.localScale = new Vector3(1,1,1);
        }
        hp_Bar.value = Boss_Control.hp;
        Rank_Score = score;
    }

    private void Puase()
    {
        
        if(Pause_state == false)
        {
            Time.timeScale = 1;
            PauseText.text = "";
        }
        else
        {
            PauseText.text = "PAUSE";
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown("p"))
        {
            Debug.Log("push P");

            if (Pause_state == true)
                Pause_state = false;
            else
                Pause_state = true;
        }
    }
    private void GameOver()
    {
        if (life == 0)
            SceneManager.LoadScene("End");
    }

    private void Show_Final_Stack()
    {   

        Vector3 position = Final_Icon.transform.position;
        for(int i=0; i<Final_Stack; i++)
        {
            position = new Vector3(position.x + 1, position.y, position.z);
            Instantiate(Final_Icon, position, Final_Icon.transform.rotation);
        }
    }

}
