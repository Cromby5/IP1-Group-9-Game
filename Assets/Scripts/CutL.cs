using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutL : MonoBehaviour
{
   public WinCheck Win;

    public float speed = 0.2f;
    //Default DirectionX and Y are set 
    protected float directionX = 1.0f;

    void Start()
    {
        Win.CutList.Add(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
                Destroy(this.gameObject);
                break;
        }
    }

    bool ColliderContainsPoint(Transform ColliderTransform, Vector3 Point, bool Enabled)
    {
        Vector3 localPos = ColliderTransform.InverseTransformPoint(Point);
        if (Enabled && Mathf.Abs(localPos.x) < 0.5f && Mathf.Abs(localPos.y) < 0.5f && Mathf.Abs(localPos.z) < 0.5f)
            return true;
        else
            return false;
    }
    private void OnDestroy()
    {
        Win.CutList.Remove(this);
    }
    IEnumerator Flip()
    {
        //This is because collison broke idk
        yield return new WaitForSeconds(0.3f);
        directionX = -directionX;
        StopCoroutine("Flip");

    }
}
