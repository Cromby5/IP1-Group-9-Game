using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectL : MonoBehaviour
{
    //Win Script
    public WinCheck Win;

    //Speed
    public float speed = 0.2f;

    //Default DirectionX and Y are set 
    protected float directionX = 1.0f;
    protected float directionY = 0.5f;

    void Start()
    {
        //Add the object to the list
        Win.InjectList.Add(this);
    }

    private void FixedUpdate()
    {
        //Movement
        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        transform.localPosition = position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            //Hits a body part
            case "Upper Arm":
            case "Torso":
                //Flip x direction
                directionX = -directionX;
                break;
        }
    }
    void OnDestroy()
    {
        //Remove the object from the list
        Win.InjectList.Remove(this);
    }
}

  