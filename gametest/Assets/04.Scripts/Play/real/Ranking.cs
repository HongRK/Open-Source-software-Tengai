using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour {

    public Text Ranking_Text;
    public bool is_Ranking;
    public GameObject RankingMenu;
	void Start () {
	    for(int i=0; i<5; i++)
        {
            Ranking_Text.text =
                "Ranking\n\n" +
                "1. " + PlayerPrefs.GetInt("0") + "\n\n" +
                "2. " + PlayerPrefs.GetInt("1") + "\n\n" +
                "3. " + PlayerPrefs.GetInt("2") + "\n\n" +
                "4. " + PlayerPrefs.GetInt("3") + "\n\n" +
                "5. " + PlayerPrefs.GetInt("4");
        }	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Manager.life == 0)
        {
            Insert_Rank(Manager.score);
        }	
	}

    void Insert_Rank(int Score)
    {
        for(int i=0; i<5; i++)
        {
            if(Score > PlayerPrefs.GetInt(i.ToString()))
            {
                for(int j = i+1; j<5; j++)
                {
                    PlayerPrefs.SetInt(j.ToString(), PlayerPrefs.GetInt((j - 1).ToString()));
                }
                PlayerPrefs.SetInt(i.ToString(), Score);
                break;
            }
        }
    }

}
