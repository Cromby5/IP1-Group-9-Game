using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text textdisplay;

    void Start()
    {
        textdisplay.text = Score.ScoreStore.ToString();
    }


}
