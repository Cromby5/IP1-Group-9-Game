using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SthethoCount : MonoBehaviour
{
    public WinCheck Win;

    // Start is called before the first frame update
    void Start()
    {
        Win.SthethoList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Win.SthethoList.Remove(this);
    }
}
