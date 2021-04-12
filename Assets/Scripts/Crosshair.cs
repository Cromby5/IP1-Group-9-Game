using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Sprite Scalpel;
    public Sprite Syringe;
    public Sprite Stethoscope;

    private void Start()
    {
        //Hide Cursor for crosshair to be our guide
        Cursor.visible = false;

       // GameObject.Find
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
        
    }

    public void changeCrossHair()
    {
       
        GetComponent<SpriteRenderer>().sprite = Scalpel;
        GetComponent<SpriteRenderer>().sprite = Syringe;
        GetComponent<SpriteRenderer>().sprite = Stethoscope;
    }
}
