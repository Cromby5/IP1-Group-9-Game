using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour
{
    //Win Script for list
    public WinCheck Win;
    //Health Script for updating health
    public Health Health;
    bool Stay = false;
   
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
                Debug.Log("Suck Start");
                Stay = true;
                StartCoroutine("Destroy");
                break;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            case "Leech(Clone)":
                Debug.Log("Suck Stop");
                Stay = false;
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

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
        
        if (Stay == true)
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
