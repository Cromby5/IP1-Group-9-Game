using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject Box;
    public GameObject Doctor;
    public GameObject Intro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("HideBox");
    }

    IEnumerator HideBox()
    {
        yield return new WaitForSeconds(3f);
        Box.SetActive(false);
        Doctor.SetActive(false);
        Intro.SetActive(false);
    }
}
