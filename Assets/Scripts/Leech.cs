using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{
    bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            follow = false;
        }
        if (follow == true)
        {
            FollowMouse();
        }
           
      
    }
    void FollowMouse()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

    }
}
