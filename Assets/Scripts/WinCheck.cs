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

    //public List<    > InjectList = new List<     >();
    public Text WinDisplay;
    public Image textbox;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (CutList.Count ==  0 && InjectList.Count == 0 && SthethoList.Count == 0)
        {
            StartCoroutine("NextLevel");
          
        }
    }
    IEnumerator NextLevel()
    {
        WinDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        //Next Level
        SceneManager.LoadScene("Level 1");
        StopCoroutine("NextLevel");
    }
}
