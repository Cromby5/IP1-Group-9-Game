using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{
    public WinCheck Win;

    bool follow = true;

    // Start is called before the first frame update
    void Start()
    {
        Win.LeechList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            FollowMouse();
        }

        if (Input.GetMouseButtonDown(0) && follow == true)
        {
            follow = false;
        }


    }
    void FollowMouse()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

    }
    void SetFollow()
    {
        follow = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "LineT(Clone)":
                Destroy(gameObject);
                break;

        }
    }

    private void OnDestroy()
    {
        Win.LeechList.Remove(this);
    }

}
