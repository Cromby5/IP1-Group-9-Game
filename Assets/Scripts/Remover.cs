using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
   public void Kill()
    {
        Destroy(GameObject.FindWithTag("Cut"));
    }
}
