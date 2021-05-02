using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    //Animation
    private Animator anim;
    //List for our stitch lines tied to the wound
    public List<StitchL> StitchList = new List<StitchL>();
    //Sprite states
    public Sprite quarter;
    public Sprite half;
    public Sprite Three;
    public Sprite full;
    //Win Script
    public WinCheck Win;

    void Start()
    {
        //List stuff
        Win.WoundList.Add(this);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "LineS(Clone)":
               // Debug.Log("HiCut");
               // anim.Play("Stage1");
              //  GetComponent<SpriteRenderer>().sprite = half;
                break;
        }
    }

    public void SpriteCheck()
    {
        if (StitchList.Count == 6)
        {
            Debug.Log("Quarter");
            GetComponent<SpriteRenderer>().sprite = quarter;
        }
        else if (StitchList.Count == 4)
        {
            Debug.Log("Half");
            GetComponent<SpriteRenderer>().sprite = half;
        }
        else if (StitchList.Count == 2)
        {
            Debug.Log("Three");
            GetComponent<SpriteRenderer>().sprite = Three;
        }
        else if (StitchList.Count == 0)
        {
            Debug.Log("Stiched Up");
            GetComponent<SpriteRenderer>().sprite = full;
            Win.WoundList.Remove(this);
        }

    }
   
}
