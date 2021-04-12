using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweezerScript : MonoBehaviour
{
    public Leech LeechTemp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //1st basic test of raycast stuff
            switch (hit.collider.gameObject.name)
            {
                case "Leeches_Jar":
                    Leech LeechClone = Instantiate(LeechTemp);
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
