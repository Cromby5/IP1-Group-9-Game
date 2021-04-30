using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SthethoCount : MonoBehaviour
{
    //Win Script
    public WinCheck Win;

   
    void Start()
    {
        //Add this object to the list
        Win.SthethoList.Add(this);
    }

    void OnDestroy()
    {
        //Remove this object from the list
        Win.SthethoList.Remove(this);
    }
}
