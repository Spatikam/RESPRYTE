using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class mov_mechanism : MonoBehaviour
{
    public Joystick joy;
    public Rigidbody2D wb;
    public float power_speed=10; 
    private GameObject joyStickaim;

    // Start is called before the first frame update
    void Start()
    {
        joyStickaim = GameObject.FindGameObjectWithTag("Aim_joy") as GameObject;
        joy = joyStickaim.GetComponent<Joystick>();
        wb.velocity = new Vector2(joy.Direction.x * power_speed, joy.Direction.y * power_speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("Player")))
        {
            Destroy(gameObject);
        }
    }
}
