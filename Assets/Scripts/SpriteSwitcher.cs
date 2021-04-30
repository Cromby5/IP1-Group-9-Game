using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite Active;
    public Sprite Normal;
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Start switching the sprite
        SwitchSprite();
    }
    void SwitchSprite()
    {
        //Checking if the other object specified is active and if yes sets the active sprite
        if (other.activeInHierarchy)
        {
            GetComponent<SpriteRenderer>().sprite = Active;
        }
        else
        {
            //Set the normal sprite
            GetComponent<SpriteRenderer>().sprite = Normal;
        }
    }
}
