using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class LineTest : MonoBehaviour
{
    public LineScript Drawer = null; //How these Lines will be drawn
    public Health HealthUpdate = null; //Updating Health when something happens
    public AudioSource Cut; //Cut sound
    public AudioSource Miss; //Miss cut sound

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
                Miss.Play();
                //Destroys the line created
                Drawer.DestroyLine(this);
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
            //For cut line
            case "CutL":
                Debug.Log("hello");
                //Play sound
                Cut.Play();
                //Destroys the line created
                Drawer.DestroyLine(this);
                //Health stays same so no update
                break;
           //For wound
           case "Wound":
                Debug.Log("hello Wound");
                Miss.Play();
                //Destroys the line created
                Drawer.DestroyLine(this);
                break;
            case "StitchL":


                break;
            case "Background":
                //Destroys the line created
                Drawer.DestroyLine(this);
                break;
            case "Leech(Clone)":
                //Destroys the line created
                Miss.Play();
                Drawer.DestroyLine(this);
                break;
           //Every other collider
            default:
                Debug.Log("default");
                Miss.Play();
                //Destroys the line created
                Drawer.DestroyLine(this);
                //Health removed
                HealthUpdate.RemoveHealth();
                break;
        }
    }
}