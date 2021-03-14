using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class LineTest : MonoBehaviour
{
    public LineScript Drawer = null;
    public Remover RemoveObj = null;
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
            case "LineT(Clone)":
                Debug.Log("helloLine");
                Drawer.DestroyLine(this);
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
            case "CutL":
                Debug.Log("hello");
                Drawer.DestroyLine(this);
                RemoveObj.Kill();
                //Health stays same so no update
                break;

            default:
                Drawer.DestroyLine(this);
                Debug.Log("default");
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
        }
    }
}