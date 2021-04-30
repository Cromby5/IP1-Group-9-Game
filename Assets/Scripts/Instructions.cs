using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Rules rules;
    public AudioSource Menu;

    public void ShowRules()
    {
        //Play menu sound 
        Menu.Play();
        //Activate rule display
        rules.gameObject.SetActive(true);

    }
    public void HideRules()
    {
        //Play menu sound
        Menu.Play();
        //Display rule display
        rules.gameObject.SetActive(false);

    }
}
