using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Challenge_Controller : MonoBehaviour
{
    public static int c1;
    public static int c2;
    public static int c3;
    public static int c4;
    public static int c5;
    public static int c6;
    public static int c7;
    public static int p;
    public TMP_Text PointsText;

    public Image i1;
    public Image i2;
    public Image i3;
    public Image i4;
    public Image i5;
    public Image i6;
    public Image i7;

    // Start is called before the first frame update
    void Start()
    {
        c1 = PlayerPrefs.GetInt("Challenge1", 0);
        c2 = PlayerPrefs.GetInt("Challenge2", 0);
        c3 = PlayerPrefs.GetInt("Challenge3", 0);
        c4 = PlayerPrefs.GetInt("Challenge4", 0);
        c5 = PlayerPrefs.GetInt("Challenge5", 0);
        c6 = PlayerPrefs.GetInt("Challenge6", 0);
        c7 = PlayerPrefs.GetInt("Challenge7", 0);
        p = PlayerPrefs.GetInt("Points", 0);

        PointsText.text = "Points: " + p;

        if (c1 == 1) i1.color = new Color(0, 255, 0);
        if (c2 == 1) i2.color = new Color(0, 255, 0);
        if (c3 == 1) i3.color = new Color(0, 255, 0);
        if (c4 == 1) i4.color = new Color(0, 255, 0);
        if (c5 == 1) i5.color = new Color(0, 255, 0);
        if (c6 == 1) i6.color = new Color(0, 255, 0);
        if (c7 == 1) i7.color = new Color(0, 255, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
