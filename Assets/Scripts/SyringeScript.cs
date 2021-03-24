using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeScript : MonoBehaviour
{
    public Health HealthUpdate = null;
    public InjectL InjectL;

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
                case "InjectL":
                    Debug.Log("Inject");
                    InjectL.Remove();
                    Destroy(hit.collider.gameObject);
                    break;
                default:
                    Debug.Log(hit.collider.gameObject.name);
                    HealthUpdate.RemoveHealth();
                break;
            } 
            
        }

    }
}
