using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    // Use this for initialization
    public void OnStartClick()
    {
        SceneManager.LoadScene("Play");
    }
    public void OnEndClick()
    {
        Application.Quit();
    }
}
