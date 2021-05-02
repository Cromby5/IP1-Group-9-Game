using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StethoscopeScript : MonoBehaviour
{
     GameObject Sthetho;
     public AudioSource Heart;
    public AudioSource Fail;
    public Crosshair Cross;

    private void OnEnable()
    {
        //Change Crosshair to SthethoScope
        Cross.CrossHairStethoscope();
    }

    void Update()
    {
        //If left mouse clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            switch (hit.collider.gameObject.name)
            {
                case "Heart":
                    Debug.Log("Heart Touched");
                    //Find the gameobject 
                    Sthetho = GameObject.Find(hit.collider.gameObject.name);
                    //Start the Delay Coroutine with the object found
                    StartCoroutine(Delay(Sthetho));
                    break;
                default:
                    Fail.Play();
                    Debug.Log(hit.collider.gameObject.name);
                    break;
            }
        }
    }
    IEnumerator Delay(GameObject Template)
    {
        //HeartBeat Sound
        Heart.Play();
        //Wait x seconds while sound plays
        yield return new WaitForSeconds(5f);
        //Destroy the template
        Destroy(Template);
        //Stop this 
        StopCoroutine("Delay");
    }
}
