using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour
{

    public List<CutL> CutList = new List<CutL>();
    public List<InjectL> InjectList = new List<InjectL>();
    public List<SthethoCount> SthethoList = new List<SthethoCount>();
    public List<Infect> InfectList = new List<Infect>();
    public List<Leech> LeechList = new List<Leech>();

    public Text WinDisplay;
    public GameObject WinPic;
    int index;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //No important things left
        if (CutList.Count ==  0 && InjectList.Count == 0 && SthethoList.Count == 0 && InfectList.Count == 0 && LeechList.Count == 0)
        {
            StartCoroutine("NextLevel");
          
        }
    }
    IEnumerator NextLevel()
    {
        //Display Win Text and Picture
        WinDisplay.gameObject.SetActive(true);
        WinPic.gameObject.SetActive(true);
        //Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        //Next Level
        index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
        //Stop this
        StopCoroutine("NextLevel");
    }
}
