using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour
{
    public WinCheck Win;
    //bool LeechCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        Win.InfectList.Add(this);
        StartCoroutine("HideInfect");

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Flash");
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "Leech(Clone)":
                // LeechCollide = true;
                StartCoroutine(Destroy(other));
                break;
        }
    }

    /* 
     private void OnCollisionStay2D(Collision2D collision)
     {
         if (LeechCollide == true)
         {
             if (timer == 0)
             { }
         }
     }
     */
    IEnumerator HideInfect()
    {
        yield return new WaitForSeconds(3f);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -4;
        StopCoroutine("HideInfect");
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(2f);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;
        yield return new WaitForSeconds(1f);
        sprite.sortingOrder = -4;
        StopCoroutine("Flash");
    }

    IEnumerator Destroy(Collision2D other)
    {
        yield return new WaitForSeconds(3f);
        
        if (other.gameObject.name == "Leech(Clone)")
        {
            Destroy(this.gameObject);
        }
        StopCoroutine("Destroy");

    }
   
    private void OnDestroy()
    {
        Win.InfectList.Remove(this);
    }
}
