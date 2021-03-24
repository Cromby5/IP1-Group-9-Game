using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutL : MonoBehaviour
{
   public WinCheck Win;

    void Start()
    {
        Win.CutList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "LineT(Clone)":
                Debug.Log("ByeCut");
                //ColliderContainsPoint();
                //Collider check??
                Win.CutList.Remove(this);

                Destroy(GameObject.FindWithTag("Cut"));
                //Destroy();
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
}
