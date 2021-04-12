using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : MonoBehaviour
{

    public static bool HardEnable = true;

    public void EnableHard()
    {
        if (HardEnable == false)
        {
            HardEnable = true;
            Debug.Log("Enabled");
        }
        else if (HardEnable == true)
        {
            HardEnable = false;
            Debug.Log("Disabled");
        }


    }
    void DisableHard()
    {
        HardEnable = false;
    }
        
}
