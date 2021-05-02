using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text Health_Display = null; //Text Display of health for exact values

    public int MaxLife = 100; //Maximum life possible
    public int Life; // Current life
    public Restart Restart = null; // Restart script

    public HealthBar healthbar; //Healthbar script

    void Start()
    {
        //Set the Starting life to the max life you can have
        Life = MaxLife;
        //Update the healthbar with the max life you can have
        healthbar.SetMaxHealth(MaxLife);
    }
    void Update()
    {
        //Raw text view
        Health_Display.text = Life.ToString();
    }

    public void RemoveHealth()
    {
        //If Life is more than 0 and is active (Hard mode on)
        if (Life > 0 && Health_Display.isActiveAndEnabled)
        {
            // -10 health
            Life -= 10;
            //Healthbar update
            healthbar.SetHealth(Life);
        }
        if (Life <= 0 && Health_Display.isActiveAndEnabled)
        {
            //Change to be same as in timer 
            Restart.StartCoroutine("RestartLevel");
        }

    }
    public void LeechRemoveHealth()
    {
        //This will take 2 health off everytime it is left on for roughly every second
        Life -= 2;
        //Healthbar update
        healthbar.SetHealth(Life);
        if (Life == 0 && Health_Display.isActiveAndEnabled)
        {
            //Change to be same as in timer 
            Restart.StartCoroutine("RestartLevel");
        }
    }
    public void ArmCut()
    {
        //0 health
        Life = 0;
        //Healthbar update
        healthbar.SetHealth(Life);
        //For hard mode
        if (Life == 0 && Health_Display.isActiveAndEnabled)
        {
            Restart.StartCoroutine("RestartLevel");
        }
    }
    public void LeechAddHealth()
    {
        Life += 10;
        //Healthbar update
        healthbar.SetHealth(Life);
    }
}
