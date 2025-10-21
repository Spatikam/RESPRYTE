using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Score_handle : MonoBehaviour
{
    public static int score;
    public static int highscore;
    private float time=0;
    public TMP_Text MyscoreText;
    public TMP_Text HighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        MyscoreText.text = "Score: "+score;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        MyscoreText.text = "Score: " + score;
        HighscoreText.text = "High Score: " + highscore; 
        if (time < 1)
        {
            time += Time.deltaTime;
        }else
        {
            time = 0;
            score += 1;
        }
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }
}
