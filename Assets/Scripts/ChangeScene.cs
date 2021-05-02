using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public AudioSource Menu; //Menu click sound
    public void ChangeToScene (int sceneToChangeTo)
    {
        //Play menu click sound
        Menu.Play();
        //Load the scene we passed in
        SceneManager.LoadScene(sceneToChangeTo);
    }
    public void RestartCurrent()
    {
        //Play menu click sound
        Menu.Play();
        //Restarts current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}