using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Rules rules;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRules()
    {
        rules.gameObject.SetActive(true);



    }
}
