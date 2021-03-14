using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                Destroy(this.gameObject);
                break;
        }
    }
}
