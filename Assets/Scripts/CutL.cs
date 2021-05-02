using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutL : MonoBehaviour
{
   public WinCheck Win; //For adding this to the list in win
   public Health Health; // For if you do something in wrong order
    //Create and set speed
    public float speed = 0.2f;
    //Default DirectionX and Y are set 
    protected float directionX = 1.0f;
   
    void Start()
    {
        //Add to list
        Win.CutList.Add(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        transform.localPosition = position;
        StartCoroutine("Flip");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "LineT(Clone)":
                Debug.Log("ByeCut");
                Destroy(GameObject.FindWithTag("Cut"));
                if (Win.InjectList.Count == 0)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Fail");
                    Destroy(this.gameObject);
                    Health.ArmCut();
                }
                break;
        }
    }

    private void OnDestroy()
    {
        //Remove from list
        Win.CutList.Remove(this);
    }
    IEnumerator Flip()
    {
        //This is because collison broke idk so we will do a fixed time before the flip
        //Wait for x seconds before flip
        yield return new WaitForSeconds(0.3f);
        //Flip Direction
        directionX = -directionX;
        //Stop
        StopCoroutine("Flip");

    }

    //Not working experimental method
    bool ColliderContainsPoint(Transform ColliderTransform, Vector3 Point, bool Enabled)
    {
        Vector3 localPos = ColliderTransform.InverseTransformPoint(Point);
        if (Enabled && Mathf.Abs(localPos.x) < 0.5f && Mathf.Abs(localPos.y) < 0.5f && Mathf.Abs(localPos.z) < 0.5f)
            return true;
        else
            return false;
    }
    //
}
