using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class LineTest : MonoBehaviour
{
    public LineScript Drawer = null;
    public Health HealthUpdate = null;

    void Update()
    {

    }

    //Change to hidden game object
    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            //In case there is multiple lines
            case "LineT(Clone)":
            case "LineS(Clone)":
                Debug.Log("helloLine");
                Drawer.DestroyLine(this);
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
            //For cut line
            case "CutL":
                Debug.Log("hello");
                Drawer.DestroyLine(this);
                //Health stays same so no update
                break;
           //For wound
           case "Wound":
                Debug.Log("hello Wound");
                Drawer.DestroyLine(this);
                break;
            case "Leech(Clone)":
               
                Drawer.DestroyLine(this);
                break;
           //Every other collider
            default:
                Debug.Log("default");
                Drawer.DestroyLine(this);
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
        }
    }
}