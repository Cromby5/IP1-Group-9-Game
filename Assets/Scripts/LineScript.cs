using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//https://www.youtube.com/watch?v=FC3wmwlVKcs

public class LineScript : MonoBehaviour
{
    public LineTest LineTemplate = null;

    private Vector3 mousePos;
    private LineRenderer line;

    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line

    // List to keep track of all Lines spawned by this script.
    List<LineTest> LineList = new List<LineTest>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                CreateLine(LineTemplate);
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Locks the first clicked point of the line so it doesnt move from that point on z axis
            mousePos.z = 0;

            //Sets Start Position to where mouse cursor is
            line.SetPosition(0, mousePos);
            startPos = mousePos;
            line.SetPosition(1, mousePos);
        }
        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            line.SetPosition(1, mousePos);
            endPos = mousePos;
            AddColliderToLine();
            
            line = null;
        }
        else if (Input.GetMouseButton(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
        }
    }


    //Change to hidden game object
    void CreateLine(LineTest template)
    {
        LineTest LineT = Instantiate(template);
        line = LineT.GetComponent<LineRenderer>();

        LineT.gameObject.SetActive(true);
        LineList.Add(LineT);
        //line = new GameObject("LineT").AddComponent<LineRenderer>();
        //line.material = material;
        // line.positionCount = 2;
        //line.startWidth = 0.15f;
        // line.endWidth = 0.15f;
        //line.useWorldSpace = false;
        // line.numCapVertices = 50;

    }
    public void DestroyLine(LineTest LineToDespawn)
    {
        LineList.Remove(LineToDespawn);
        Destroy(LineToDespawn.gameObject);

    }

    private void AddColliderToLine()
    {
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