using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon_spawner : MonoBehaviour
{
    public GameObject Monster;
    public float spawn_rate = 5;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawn_rate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(Monster, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
