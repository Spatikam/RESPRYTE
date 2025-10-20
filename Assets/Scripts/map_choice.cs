using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class map_choice : MonoBehaviour
{
    public static int choice;
    // Start is called before the first frame update
    public void map1()
    {
        choice = 0;
        SceneManager.LoadScene("Game_play");
    }
    public void map2()
    {
        choice = 1;
        SceneManager.LoadScene("Game_play");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
