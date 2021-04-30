using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    //Sprites to replace crosshair with tools
    public Sprite Scalpel;
    public Sprite Syringe;
    public Sprite Stethoscope;
    public Sprite Tweezer;
    //Default Crosshair
    public Sprite Default;
    public AudioSource Audio;

    private void Start()
    {
        //Hide Cursor for crosshair to be our guide
        Cursor.visible = false;
        GetComponent<SpriteRenderer>().sprite = Default;
    }

    void Update()
    {
        //Updating the mouse positon
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
       
    }

    public void CrossHairSyringe()
    {
        Audio.Play();
        GetComponent<Animator>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = Syringe;
    }
    public void CrossHairStethoscope()
    {
        Audio.Play();
        GetComponent<SpriteRenderer>().sprite = Stethoscope;
        
    }
    public void CrossHairStitch()
    {
        Audio.Play();
        GetComponent<SpriteRenderer>().sprite = Scalpel;
    }
    public void CrossHairTweezer()
    {
        Audio.Play();
        GetComponent<SpriteRenderer>().sprite = Tweezer;
    }
    public void ResetCrossHair()
    {
        Audio.Play();
        GetComponent<SpriteRenderer>().sprite = Default;
        GetComponent<Animator>().enabled = false;
    }
}
