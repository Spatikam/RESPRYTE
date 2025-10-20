using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour
{
    private Vector2 Screen_bounds;
    // Start is called before the first frame update
    void Start()
    {
        Screen_bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, Screen_bounds.x, Screen_bounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, Screen_bounds.y, Screen_bounds.y * -1);
        transform.position = viewPos;
    }
}
