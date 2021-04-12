using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectL : MonoBehaviour
{
    public WinCheck Win;

    public float speed = 0.2f;

    //Default DirectionX and Y are set 
    protected float directionX = 1.0f;
    protected float directionY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Win.InjectList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        transform.localPosition = position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "Upper Arm":
            case "Torso":
                directionX = -directionX;
                break;
        }
    }
    void OnDestroy()
    {
        Win.InjectList.Remove(this);
    }
}

  