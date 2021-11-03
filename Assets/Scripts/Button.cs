using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool OnPlayer1Side;
    public bool isOn = false;
    public bool isActive = false;
    public GameObject trigger;
    SpriteRenderer SpriteColor;
    // Start is called before the first frame update
    void Start()
    {
        SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            SpriteColor.material.color = Color.gray;
        }
        else if (isActive == true && isOn == false)
        {
            SpriteColor.material.color = Color.red;
        }
        else if (isActive == true && isOn == true)
        {
            SpriteColor.material.color = Color.green;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnPlayer1Side == false)
        {
            if (collision.gameObject.tag == "Player2" && isActive == true)
            {
                isOn = true;
            }
            if (collision.gameObject.tag == "Player")
            {                
                isActive = true;
            }
        }
        if (OnPlayer1Side == true)
        {
            if (collision.gameObject.tag == "Player" && isActive == true)
            {
                isOn = true;
            }
            if (collision.gameObject.tag == "Player2")
            {
                isActive = true;
            }
        }
    }
}
