using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StitchL : MonoBehaviour
{
    public Wound Wounds; //Allows the wound to be set in inspector

    void Start()
    {
        //Adds this line to the wound list
        Wounds.StitchList.Add(this);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "LineS(Clone)":
                Debug.Log("ByeCut");
                Destroy(this.gameObject);
                break;
        }
    }

    private void OnDestroy()
    {
        //Removes this Line from the wound list
        Wounds.StitchList.Remove(this);
        //Check what sprite we should be on depending on how many lines left
        Wounds.SpriteCheck();
    }
}
