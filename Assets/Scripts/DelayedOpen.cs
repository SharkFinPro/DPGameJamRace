using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tyler wrote this
public class DelayedOpen : MonoBehaviour
{
    public GameObject door;
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
            SpriteColor.color = Color.clear;
            BoxCollider2D doorcol = this.gameObject.GetComponent<BoxCollider2D>();
            doorcol.isTrigger = true;
        }
    } 
}
