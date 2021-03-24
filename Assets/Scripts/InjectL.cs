using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectL : MonoBehaviour
{
    public WinCheck Win;

    // Start is called before the first frame update
    void Start()
    {
        Win.InjectList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    public void Remove()
    {
        Win.InjectList.Remove(this);
    }
}

  