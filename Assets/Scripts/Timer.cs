using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10; //Time to count down from (changeable per level in inspector)
    public Text Timer_Display = null; //Display
    public Restart Restart = null; // Restart script

    void Update()
    {
        if (timeRemaining > 0)
        {
            //Set the timeRemaining minus the time passed
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Restart.StartCoroutine("RestartLevel");
        }
        //Show current Time Remaining
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        //Allows for acurate display of minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Format for the display of the time (00:00)
        Timer_Display.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
