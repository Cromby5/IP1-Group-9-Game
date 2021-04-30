using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeScript : MonoBehaviour
{
    public Health HealthUpdate = null;
    GameObject InjectL = null;
    public Crosshair Cross;
    public Animator animator;
    public AudioSource AudioSuccess;
    public AudioSource AudioFail;

    private void OnEnable()
    {
        //Sets crosshair to the syringe
        Cross.CrossHairSyringe();
    }
    void Update()
    {
        //If left mouse clicked
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("OnClick");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            switch (hit.collider.gameObject.name)
            {
                case "InjectL":
                    Debug.Log("Inject");
                    AudioSuccess.Play();
                    InjectL = GameObject.Find(hit.collider.gameObject.name);
                    Destroy(InjectL);
                    break;
                default:
                    AudioFail.Play();
                    Debug.Log(hit.collider.gameObject.name);
                    HealthUpdate.RemoveHealth();
                break;
            } 
            
        }
    }
 
}
