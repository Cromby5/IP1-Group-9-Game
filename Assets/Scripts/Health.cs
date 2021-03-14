using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text Health_Display = null;
    public int Life = 100;
    void Update()
    {
        Health_Display.text = Life.ToString();
    }

    public void RemoveHealth()
    {
        Life -= 5;
        if (Life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }
}
