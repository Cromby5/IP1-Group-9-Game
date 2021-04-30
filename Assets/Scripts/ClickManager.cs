using UnityEngine;
using System.Collections;

//https://kylewbanks.com/blog/unity-2d-detecting-gameobject-clicks-using-raycasts

public class ClickManager : MonoBehaviour
{
    //Tools To Enable/Disable
    public LineScript LineS = null; //Object for Drawing/Creating Lines for cutting
    public SyringeScript Syringe = null; //Object for Syringe 
    public StethoscopeScript Stethoscope = null; //Object for Sthethoscope for listening to body sounds
    public TweezerScript Tweezer = null; //Object for Tweezers for grabbing certain objects
    public StitchScript Stitch = null; //Object for Drawing/Creating Lines for stitching

    bool toolselected = false; //To check if a tool is selected

    //For Enabling/Disabling objects through hard mode variable
    public Health Health = null; //Object for determining/showing health
    public Score Score = null; //Object for Storing/Changing score
    public Timer Timer = null; //Object for Storing/Showing time remaining
    public HealthBar Healthbar = null; //Visual HealthBar
    public GameObject Watch = null; //Timer Background
    //Crosshair object
    public Crosshair Cross;

    void Start()
    {
        //Enable these if hard difficulty is selected. Pass through value between scenes via Hard class which can be set in the main menu before starting the game
        if (Hard.HardEnable == true)
        {
            //Set all to be active
            Health.gameObject.SetActive(true);
            Score.gameObject.SetActive(true);
            Timer.gameObject.SetActive(true);
            Healthbar.gameObject.SetActive(true);
            Watch.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        //If left mouse down and no tool currently selected
        if (Input.GetMouseButtonDown(0) && toolselected == false)
        {
            //Mouse position transformed into world space and gets the coordinates of position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Creating a 2D mouseposition to interact with 2D objects
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            //Raycasts at the point the mouse is currently at and stores the collided object in hit
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //Using the collided objects name to determine what to do
            switch (hit.collider.gameObject.name)
            {
                case "PHScalpel":
                    Debug.Log("Scalpel Selected");
                    //Will enable the Linescript
                    LineS.gameObject.SetActive(true);
                    //Sets toolselected to true disabling the player from selecting 2 tools at once
                    toolselected = true;
                    break;
                case "PHSyringe":
                    Debug.Log("Syringe Selected");
                    Syringe.gameObject.SetActive(true);
                    //Sets toolselected to true disabling the player from selecting 2 tools at once
                    toolselected = true;
                    break;
                case "PHStethoscope":
                    Debug.Log("Stethoscope Selected");
                    Stethoscope.gameObject.SetActive(true);
                    //Sets toolselected to true disabling the player from selecting 2 tools at once
                    toolselected = true;
                    break;
                case "Tweezers":
                    Debug.Log("Tweezers Selected");
                    Tweezer.gameObject.SetActive(true);
                    //Sets toolselected to true disabling the player from selecting 2 tools at once
                    toolselected = true;
                    break;
                case "PHStitch":
                    Debug.Log("Stitch Selected");
                    Stitch.gameObject.SetActive(true);
                    //Sets toolselected to true disabling the player from selecting 2 tools at once
                    toolselected = true;
                    break;
                default:
                    Debug.Log(hit.collider.gameObject.name);
                    break;
            }
        }
        //When you press right mouse button with a tool selected
        if (Input.GetMouseButtonDown(1) && toolselected == true)
        {
            //Deactivates any active tools
            Debug.Log("Deselected Tool");
            LineS.gameObject.SetActive(false);
            Syringe.gameObject.SetActive(false);
            Stethoscope.gameObject.SetActive(false);
            Tweezer.gameObject.SetActive(false);
            Stitch.gameObject.SetActive(false);
            //Sets tool selected to false to allow another tool to be picked up
            toolselected = false;
            //Resets the crosshair to the default to show you can select again
            Cross.ResetCrossHair();
        }
    }

}