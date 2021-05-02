using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text Failure_Display = null; //Text saying you failed
    public GameObject FailPic; // Doctor picture
    public GameObject Box; //Text Box
    IEnumerator RestartLevel()
    {
        //Failure text 
        Failure_Display.gameObject.SetActive(true);
        FailPic.SetActive(true);
        Box.SetActive(true);
        //Wait for x seconds
        yield return new WaitForSeconds(3f);
        //Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Stop This Coroutine
        StopCoroutine("RestartLevel");
    }

}
