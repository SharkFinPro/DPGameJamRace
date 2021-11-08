using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tyler wrote this
public class Teleporter : MonoBehaviour
{
    public GameObject exitPoint;
    public GameObject trigger;
    Trigger ts;    
    // Start is called before the first frame update
    void Start()
    {       
        ts = trigger.GetComponent<Trigger>();   
    }

    // Update is called once per frame
    void Update()
    {         
        if (ts.IsActive == true)
        {
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
            SpriteColor.color = Color.cyan;           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            if (ts.IsActive == true)
            {
                collision.gameObject.transform.position = exitPoint.transform.position;
            }
        }
    }
    
}
