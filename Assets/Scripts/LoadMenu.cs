using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Menu");
    }

 
    IEnumerator Menu()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
        StopCoroutine("Menu");
    }
}
