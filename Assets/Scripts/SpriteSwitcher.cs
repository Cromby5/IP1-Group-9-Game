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
        SwitchSprite();
    }
    void SwitchSprite()
    {
        if (other.activeInHierarchy)
        {
            GetComponent<SpriteRenderer>().sprite = Active;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Normal;
        }
    }
}
