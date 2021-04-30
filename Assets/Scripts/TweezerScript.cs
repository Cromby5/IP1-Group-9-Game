using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweezerScript : MonoBehaviour
{
    public Leech LeechTemp; //Leech template to use
    public Crosshair Cross; // Crosshair 


    private void OnEnable()
    {
        //Tweezer crosshair
        Cross.CrossHairTweezer();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            switch (hit.collider.gameObject.name)
            {
                case "Leeches_Jar":
                    //Make a new leech using the template
                    Leech LeechClone = Instantiate(LeechTemp);
                    //Activate the new clone object
                    LeechClone.gameObject.SetActive(true);
                    break;
                case "Leech(Clone)":
                    Debug.Log("Hi Le");
                    //LeechClone = GameObject.Find(hit.collider.gameObject.name);
                    //LeechClone.SetFollowMouse();
                    break;
                default:
                    Debug.Log(hit.collider.gameObject.name);
                    break;
            }

        }
    }


}
