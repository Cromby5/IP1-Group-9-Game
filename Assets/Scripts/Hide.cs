using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    //GameObjects to show/hide
    public GameObject Box;
    public GameObject Doctor;
    public GameObject Intro;

    // Start is called before the first frame update
    void Start()
    {
        //Show at start of level
        Box.SetActive(true);
        Doctor.SetActive(true);
        Intro.SetActive(true);
        //Start Hide
        StartCoroutine("HideBox");
    }

    IEnumerator HideBox()
    {
        //Hide after x seconds
        yield return new WaitForSeconds(3f);
        //Hide the intro text, box and doctor
        Box.SetActive(false);
        Doctor.SetActive(false);
        Intro.SetActive(false);
        //Stop this Coroutine
        StopCoroutine("HideBox");
    }
}
