using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_button: MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        Console.ReadKey(false);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Start_Game()
    {
        SceneManager.LoadScene("Map_Choose");
    }
    public void go_about()
    {
        SceneManager.LoadScene("About");
    }

    public void go_Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard_scene");
    }
    public void go_Challenge()
    {
        SceneManager.LoadScene("Challenges");
    }

}
