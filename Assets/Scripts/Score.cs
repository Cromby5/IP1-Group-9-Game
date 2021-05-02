using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreStore; //To store score between stages
    int LocalScore = 100000; //Score to count down from
    public Text Score_Display; //Score Display
    public Text Win_Display; //Win Text
    bool Final = false;

    void Update()
    {
        if (Win_Display.isActiveAndEnabled && Final == false)
        {
            //Sets final score of stage
            SetFinal();
        }
        else if (Win_Display.isActiveAndEnabled)
        {
            //Blank
        }
        else
        {
            //Lower Score by 1
            LocalScore -= 1;
            //Display Score
            Score_Display.text = LocalScore.ToString();
        }
    }

    void SetFinal()
    {
        //Sets final score
        ScoreStore += LocalScore;
        Final = true;
    }
}
