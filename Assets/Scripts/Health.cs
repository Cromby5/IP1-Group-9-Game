using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text Health_Display = null;

    public int MaxLife = 100;
    public int Life;
    public Restart Restart = null;

    public HealthBar healthbar;

    void Start()
    {
        Life = MaxLife;
        healthbar.SetMaxHealth(MaxLife);
    }
    void Update()
    {
        Health_Display.text = Life.ToString();
    }

    public void RemoveHealth()
    {
        if (Life > 0 && Health_Display.isActiveAndEnabled)
        {
            Life -= 10;
            healthbar.SetHealth(Life);
        }
        if (Life == 0 && Health_Display.isActiveAndEnabled)
        {
            //Change to be same as in timer 
            Restart.StartCoroutine("RestartLevel");
        }

    }
}
