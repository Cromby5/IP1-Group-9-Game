using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hard : MonoBehaviour
{
    public static bool HardEnable = true; //Storing if hard is enabled or not and allowing it to go between scenes
    public AudioSource Menu; //Menu Sound
    public TextMeshProUGUI textDisplay;

    public void EnableHard()
    {
        if (HardEnable == false)
        {
            //Play Menu Sound
            Menu.Play();
            //Text
            textDisplay.text = "Hard";
            //Enable Hard mode
            HardEnable = true;
            Debug.Log("Enabled");
        }
        else if (HardEnable == true)
        {
            //Play Menu Sound
            Menu.Play();
            //Text
            textDisplay.text = "Easy";
            //Disable Hard mode
            HardEnable = false;
            Debug.Log("Disabled");
        }
    }
        
}
