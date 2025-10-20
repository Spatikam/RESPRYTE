using System;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class hh : MonoBehaviour
{
    public static float health = 20;
    public Image healthbar;
    public float health_2 = 20;
    public float maxHealth = 20;


    void Start(){
        health_2=maxHealth; 
        hh.health=health_2;
    }

    void Update(){
        health = health_2;
        healthbar.fillAmount=Mathf.Clamp(health_2/maxHealth,0,1);
    }
}
