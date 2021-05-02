using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Game");
    }
    IEnumerator Game()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(2);
        StopCoroutine("Game");
    }
}
