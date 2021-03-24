using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StethoscopeScript : MonoBehaviour
{
    public SthethoCount Sthetho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        switch (hit.collider.gameObject.name)
        {
            case "Heart":
                Debug.Log("Heart Touched");
                Sthetho.RemoveS();
                Destroy(GameObject.FindWithTag("Heart"));
                break;
            default:
                Debug.Log(hit.collider.gameObject.name);
                break;
        }
    }
}
