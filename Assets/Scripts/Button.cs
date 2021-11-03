using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{  
    public bool isOn = false;   
    public GameObject trigger;
    Trigger ts;
    SpriteRenderer SpriteColor;
    // Start is called before the first frame update
    void Start()
    {
        ts = trigger.GetComponent<Trigger>();
        SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ts.IsActive == false)
        {
            SpriteColor.material.color = Color.gray;
        }
        else if (ts.IsActive == true && isOn == false)
        {
            SpriteColor.material.color = Color.red;
        }
        else if (ts.IsActive == true && isOn == true)
        {
            SpriteColor.material.color = Color.green;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            isOn = true;
        }
    }
}
