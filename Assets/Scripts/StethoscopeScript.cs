using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StethoscopeScript : MonoBehaviour
{
     GameObject Sthetho;
     public AudioSource Heart;
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

            switch (hit.collider.gameObject.name)
            {
                case "Heart":
                    Debug.Log("Heart Touched");
                    Sthetho = GameObject.Find(hit.collider.gameObject.name);
                    StartCoroutine(Delay(Sthetho));
                    break;
                default:
                    Debug.Log(hit.collider.gameObject.name);
                    break;
            }
        }
    }
    IEnumerator Delay(GameObject Template)
    {
        Heart.Play();
        yield return new WaitForSeconds(5f);
        Destroy(Template);

        StopCoroutine("Delay");
    }
}
