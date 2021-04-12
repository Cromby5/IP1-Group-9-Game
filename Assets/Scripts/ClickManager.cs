using UnityEngine;
using System.Collections;

//https://kylewbanks.com/blog/unity-2d-detecting-gameobject-clicks-using-raycasts

public class ClickManager : MonoBehaviour
{
    //Tools
    public LineScript LineS = null;
    public SyringeScript Syringe = null;
    public StethoscopeScript Stethoscope = null;
    public TweezerScript Tweezer = null;
    public StitchScript Stitch = null;

    bool toolselected = false;

    public Health Health = null;
    public Timer Timer = null;
    public HealthBar Healthbar = null;
    public GameObject Watch = null;

    void Start()
    {
        //Enable these if hard difficulty is selected. Pass through value between scences
        if (Hard.HardEnable == true)
        {
            Health.gameObject.SetActive(true);
            Timer.gameObject.SetActive(true);
            Healthbar.gameObject.SetActive(true);
            Watch.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        //If mouse down AND NO TOOL CURRENTLY SELECTED
        if (Input.GetMouseButtonDown(0) && toolselected == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //1st basic test of raycast stuff
            switch (hit.collider.gameObject.name)
            {
                case "PHScalpel":
                    Debug.Log("Scalpel Selected");
                    LineS.gameObject.SetActive(true);
                    toolselected = true;
                    break;
                case "PHSyringe":
                    Debug.Log("Syringe Selected");
                    Syringe.gameObject.SetActive(true);
                    toolselected = true;
                    break;
                case "PHStethoscope":
                    Debug.Log("Stethoscope Selected");
                    Stethoscope.gameObject.SetActive(true);
                    toolselected = true;
                    break;
                case "Tweezers":
                    Debug.Log("Tweezers Selected");
                    Tweezer.gameObject.SetActive(true);
                    toolselected = true;
                    break;
                case "PHStitch":
                    Debug.Log("Stitch Selected");
                    Stitch.gameObject.SetActive(true);
                    toolselected = true;
                    break;
                default:
                    Debug.Log(hit.collider.gameObject.name);
                    break;
            }
        }
        if (Input.GetMouseButtonDown(1) && toolselected == true)
        {
            //Deactivate tool test
            Debug.Log("Deselected Tool");
            LineS.gameObject.SetActive(false);
            Syringe.gameObject.SetActive(false);
            Stethoscope.gameObject.SetActive(false);
            Tweezer.gameObject.SetActive(false);
            Stitch.gameObject.SetActive(false);
            toolselected = false;
        }
    }

}