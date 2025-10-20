using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject game_over;
    public TMP_Text finalscoreText;
    public AudioSource audioSource;
    [SerializeField] GameObject howto;
    private int how;
    [SerializeField] GameObject map1_m;
    [SerializeField] GameObject map1_c;
    [SerializeField] GameObject map2_m;
    [SerializeField] GameObject map2_c;

    private void Start()
    {
        Time.timeScale = 1;
        how = PlayerPrefs.GetInt("How_to", 0);
        if (how == 1)
        {
            howto.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            howto.SetActive(true);
            Time.timeScale = 0;
        }
        if (map_choice.choice == 0)
        {
            map1_m.SetActive(true);
            map1_c.SetActive(true);
            map2_m.SetActive(false);
            map2_c.SetActive(false);
        }
        if (map_choice.choice == 1)
        {
            map1_m.SetActive(false);
            map1_c.SetActive(false);
            map2_m.SetActive(true);
            map2_c.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (hh.health <= 0)
        {
            gameOver();
        }
    }
    public void go_Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void pause()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0;
        audioSource.Pause();
    }
    public void resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1;
        audioSource.Play();
    }

    public void gameOver()
    {
        finalscoreText.text = "Score: " + Score_handle.score;
        game_over.SetActive(true);
        Time.timeScale = 0;
    }

    public void restart()
    {
        SceneManager.LoadScene("Game_play");
        Time.timeScale = 1;
        Debug.Log("fail");
    }

    public void move_on()
    {
        PlayerPrefs.SetInt("How_to", 1);
        howto.SetActive(false);
        Time.timeScale = 1;
    }

}
