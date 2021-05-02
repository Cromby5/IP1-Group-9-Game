using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{
    //Win script for list
    public WinCheck Win;
    //For Health updates
    public Health HealthUpdate = null;
    //Will follow the cursor by default
    bool follow = true;
    bool damage = false;
    public AudioSource Suck;

    void Start()
    {
        //Add to the list that will be used to check if any are left
        Win.LeechList.Add(this);
    }

    void Update()
    {
        if (follow == true)
        {
            FollowMouse();
        }

        if (Input.GetMouseButtonDown(0) && follow == true)
        {
            follow = false;
            StartCoroutine("LeechRemoveHealth");
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
    void OnCollisionStay2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Leg":
                damage = true;
                break;
        }
        switch (other.gameObject.tag)
        {
            case "Infect":
                damage = true;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Leg":
                damage = false;
                break;
        }
        switch (other.gameObject.tag)
        {
            case "Infect":
                damage = false;
                break;
        }
    }
    private void OnDestroy()
    {
        Win.LeechList.Remove(this);
    }

    IEnumerator LeechRemoveHealth()
    {
        while (follow == false && damage == true)
        {
            yield return new WaitForSeconds(1f);
            HealthUpdate.LeechRemoveHealth();
            Suck.Play();
        }
    }
}
