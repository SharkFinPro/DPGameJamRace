using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool OnPlayer1Side;
    public bool isOn = false;
    private bool isActive = false;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer color = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
           
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
