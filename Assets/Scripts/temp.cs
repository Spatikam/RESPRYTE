using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    private string player_name;
    
    public void Read_Name(string s)
    {
        player_name = s;
        Debug.Log(player_name);
    }
}
