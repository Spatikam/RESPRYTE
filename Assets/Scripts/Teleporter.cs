using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination1;
    public Transform destination2;
    public static float timer=0;
    public static float timer1 = 0;
    public static int tele_active = 0;
    [SerializeField] GameObject tele1;
    [SerializeField] GameObject tele2;
    private Collider2D col;
    public static int teleported = 0;

    // Start is called before the first frame update
    void Start()
    {
        tele1.SetActive(true); 
        tele2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 16)
        {
            tele1.SetActive(true);
            tele2.SetActive(true);
            teleported = 0;
        }
        else
        {
            tele1.SetActive(false);
            tele2.SetActive(false);
        }
        if (tele_active == 1)
        {
            timer1 += Time.deltaTime;
            if(timer1 >= 2 && teleported==0)
            {
                if (Vector3.Distance(col.transform.position, destination1.position) > 3 && teleported == 0)
                {
                    col.transform.position = destination1.position;
                    teleported = 1;
                }
                if (Vector3.Distance(col.transform.position, destination2.position) > 3 && teleported == 0)
                {
                    col.transform.position = destination2.position;
                    teleported = 1;
                }
            }
        }
        if (timer1 > 4)
        {
            tele_active = 0;
            timer1 = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer>16)
        {
            tele_active = 1;
            timer = 0;
            col = collision;
        }
    }
}
