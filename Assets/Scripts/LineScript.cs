using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//https://www.youtube.com/watch?v=FC3wmwlVKcs

public class LineScript : MonoBehaviour
{
    public LineTest LineTemplate = null; //Template of line to be used

    private Vector3 mousePos; //Storing Mouse Position
    private LineRenderer line; //Line Renderer component

    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line

    public Crosshair Cross; //Crosshair
    // List to keep track of all Lines spawned by this script.
    List<LineTest> LineList = new List<LineTest>();

    private void OnEnable()
    {
        //Change crosshair to stitch/scalpel
        Cross.CrossHairStitch();
    }

    void Update()
    {

        //If Left mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            //If no line is being drawn currently
            if (line == null)
            {
                //CreateLine Method called
                CreateLine(LineTemplate);
            }
            //To allow the Line to be tied to the mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Locks the first clicked point of the line so it doesnt move from that point on z axis
            mousePos.z = 0;

            //Sets Start Position to where mouse cursor is
            line.SetPosition(0, mousePos);
            //The starting position of the line is set to the mouse position
            startPos = mousePos;
            //The lines first point is set to the mouse position
            line.SetPosition(1, mousePos);
        }
        else if (Input.GetMouseButtonUp(0) && line)
        {
            //To allow the Line to be tied to the mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Locks the first clicked point of the line so it doesnt move from that point on z axis
            mousePos.z = 0;
            //Sets the Position of the line again
            line.SetPosition(1, mousePos);
            //Sets the end position to the mouse position
            endPos = mousePos;
            //Starts method
            AddColliderToLine();
            //Sets line to null to show no line is currently being drawn
            line = null;
        }
        //If the left mouse is still down and you are drawing a line
        else if (Input.GetMouseButton(0) && line)
        {
            //To allow the Line to be tied to the mouse
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Locks the first clicked point of the line so it doesnt move from that point on z axis
            mousePos.z = 0;
            //Updates the position
            line.SetPosition(1, mousePos);
        }
    }


    //Change to hidden game object
    void CreateLine(LineTest template)
    {
        //Creates a new clone of the line template
        LineTest LineT = Instantiate(template);
        //Grabs the line render component from the line template
        line = LineT.GetComponent<LineRenderer>();
        //Activates the Line object
        LineT.gameObject.SetActive(true);
        //Adds it into a list to keep track of it
        LineList.Add(LineT);

    }
    public void DestroyLine(LineTest LineToDespawn)
    {
        //Remove the line to despawn from the list
        LineList.Remove(LineToDespawn);
        //Destroy the line to despawn
        Destroy(LineToDespawn.gameObject);

    }

    private void AddColliderToLine()
    {
        //Creates a new box collider to be used as a child to the line
        BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D>();
        col.transform.parent = line.transform; // Collider is added as child object of line
        float lineLength = Vector3.Distance(startPos, endPos); // length of line
        col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }

}