using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text Failure_Display = null;

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
