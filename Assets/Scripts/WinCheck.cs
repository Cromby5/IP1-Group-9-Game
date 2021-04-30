using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour
{
    //All the lists used to check if an issue exists in the level
    public List<CutL> CutList = new List<CutL>(); //List of things to cut
    public List<InjectL> InjectList = new List<InjectL>(); //List of things to inject
    public List<SthethoCount> SthethoList = new List<SthethoCount>(); //List of things to sthetoscope
    public List<Infect> InfectList = new List<Infect>(); //List of infections in the level
    public List<Leech> LeechList = new List<Leech>(); //List of leeches placed
    public List<Wound> WoundList = new List<Wound>(); //List of wounds to stitch up

    //Objects that show on a win of the level
    public Text WinDisplay; //Text saying you have been successful
    public GameObject WinPic; //Picture of our doctor
    public GameObject Box; //Text Box 
    //Storing the build index of the level to go to the next one
    int index;

    void Update()
    {
        
        //If No important things/problems left 
        if (CutList.Count ==     0 && 
            InjectList.Count ==  0 && 
            SthethoList.Count == 0 && 
            InfectList.Count ==  0 && 
            LeechList.Count ==   0 &&
            WoundList.Count ==   0
            )
        {
            //Start going to the next level
            StartCoroutine("NextLevel");
          
        }
    }
    IEnumerator NextLevel()
    {
        //Display Win Text,Text Box and Picture
        WinDisplay.gameObject.SetActive(true);
        Box.gameObject.SetActive(true);
        WinPic.gameObject.SetActive(true);
        //Wait for x seconds
        yield return new WaitForSeconds(5f);
        //Next Level by taking current index + 1
        index = SceneManager.GetActiveScene().buildIndex + 1;
        //Load Scene
        SceneManager.LoadScene(index);
        //Stop this
        StopCoroutine("NextLevel");
    }
}
