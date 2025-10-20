using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUI;

    // Start is called before the first frame update
    void Start()
    {
        myUI.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(myUI.alpha<1)
        {
            myUI.alpha += Time.deltaTime;
        }
    }
}
