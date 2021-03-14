using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text Timer_Display = null;
    public Text Failure_Display = null;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = -0.5f;
            StartCoroutine("RestartLevel");
        }
        DisplayTime(timeRemaining);

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer_Display.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator RestartLevel()
    {
        //Failure text 
        Failure_Display.gameObject.SetActive(true);
        //Wait for x seconds
        yield return new WaitForSeconds(3f);
        //Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Stop This Coroutine
        StopCoroutine("RestartLevel");
    }
}
