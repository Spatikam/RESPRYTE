using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Char_mov : MonoBehaviour
{
    public Joystick joy1;
    public Joystick joy2;
    public float playerspeed;
    public Rigidbody2D rb;
    bool mov_direction=true;
    private Animator animator;
    private GameObject joyStick;

    public GameObject power;
    public float spawn_rate = 1;
    private float timer = 0;
    public static int spirit_killed = 0;
    private float timer1 = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        joyStick = GameObject.FindGameObjectWithTag("Aim_joy") as GameObject;
        joy2 = joyStick.GetComponent<Joystick>();
        animator.SetFloat("is_Firing", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (joy1.Direction.y != 0)
        {
            rb.velocity = new Vector2(joy1.Direction.x*playerspeed, joy1.Direction.y*playerspeed);
        }
        else
        {
            rb.velocity= Vector2.zero;
        }
        if(joy2.Direction.x < 0 && mov_direction)
        {
            flip();
        }
        if (joy2.Direction.x > 0 && !mov_direction)
        {
            flip();
        }
        
        if (Teleporter.tele_active== 1)
        {
            if (Teleporter.timer1 <= 2) animator.SetFloat("is_Firing", 0.6f);
            else animator.SetFloat("is_Firing", 1);
        }
        else if (joy2.Direction.y != 0)
        {
            animator.SetFloat("is_Firing", 0.3f);
            if (timer < spawn_rate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                Instantiate(power, transform.position, transform.rotation);
                timer = 0;
            }
        }
        else
        {
            animator.SetFloat("is_Firing", 0);
        }

        if (timer1 < 300)
        {
            timer1 = timer1 + Time.deltaTime;
        }

        if (PlayerPrefs.GetInt("Challenge1", 0) == 0 && timer1 >= 20)
        {
            PlayerPrefs.SetInt("Challenge1", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 10);
        }
        if (PlayerPrefs.GetInt("Challenge2", 0) == 0 && timer1 >= 60)
        {
            PlayerPrefs.SetInt("Challenge2", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 50);
        }
        if (PlayerPrefs.GetInt("Challenge3", 0) == 0 && timer1 > 299)
        {
            PlayerPrefs.SetInt("Challenge3", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 100);
        }

        if (PlayerPrefs.GetInt("Challenge4", 0) == 0 && spirit_killed == 5)
        {
            PlayerPrefs.SetInt("Challenge4", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 10);
        }
        if (PlayerPrefs.GetInt("Challenge5", 0) == 0 && spirit_killed == 20)
        {
            PlayerPrefs.SetInt("Challenge5", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 50);
        }
        if (PlayerPrefs.GetInt("Challenge6", 0) == 0 && spirit_killed == 50)
        {
            PlayerPrefs.SetInt("Challenge6", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 100);
        }
        if (PlayerPrefs.GetInt("Challenge7", 0) == 0 && spirit_killed == 100)
        {
            PlayerPrefs.SetInt("Challenge7", 1);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + 150);
        }
    }

    void flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
        mov_direction = !mov_direction;
    }
}
