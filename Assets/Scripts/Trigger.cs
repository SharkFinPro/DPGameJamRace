using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool OnPlayer1Side;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnPlayer1Side == false)
        {
            if (collision.gameObject.tag == "Player2")
            {
                
            }
            if (collision.gameObject.tag == "Player")
            {
                
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
