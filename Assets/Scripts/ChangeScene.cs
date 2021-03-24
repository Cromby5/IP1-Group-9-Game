using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    public void ChangeToScene (int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
    public void RestartCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}