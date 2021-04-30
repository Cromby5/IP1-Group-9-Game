using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour
{
    //Win Script for list
    public WinCheck Win;
    //Health Script for updating health
    public Health Health;
    
   
    void Start()
    {
        //Add this object to the infect list
        Win.InfectList.Add(this);
        StartCoroutine("HideInfect");
    }

    void Update()
    {
        //Start the flashing Coroutine
        StartCoroutine("Flash");
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "Leech(Clone)":
                StartCoroutine(Destroy(other));
                break;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "Leech(Clone)":
                StopCoroutine("Destroy");
                break;
        }
    }

    //Inital hide
    IEnumerator HideInfect()
    {
        yield return new WaitForSeconds(3f);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -4;
        StopCoroutine("HideInfect");
    }
    //Flashing
    IEnumerator Flash()
    {
        yield return new WaitForSeconds(5f);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -2;
        yield return new WaitForSeconds(1f);
        sprite.sortingOrder = -4;
        StopCoroutine("Flash");
    }

    IEnumerator Destroy(Collision2D other)
    {
        yield return new WaitForSeconds(4f);
        
        if (other.gameObject.name == "Leech(Clone)")
        {
            Destroy(this.gameObject);
            Health.LeechAddHealth();
        }
        StopCoroutine("Destroy");

    }
   
    private void OnDestroy()
    {
        //Remove this object from list
        Win.InfectList.Remove(this);
    }
}
