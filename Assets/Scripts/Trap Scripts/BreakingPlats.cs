using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlats : MonoBehaviour
{
    public int delay;
    public float fadeTime;
    public float respawnTime;
    Rigidbody2D rb;
    EnableScript enabler;
    public GameObject enablerObj;
    bool fadeOut = false;
    Vector3 homePos;
    Color oldColor;
    Color tempClear;
    Quaternion rotationStorage;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        oldColor = SpriteColor.color;
        rb = this.GetComponent<Rigidbody2D>();
        enabler = enablerObj.GetComponent<EnableScript>();
        rb.isKinematic = true;
        homePos = this.gameObject.transform.position;
        Color currentColor = SpriteColor.color;
        tempClear = currentColor;
        tempClear.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeOut == true)
        {
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
            Color currentColor = SpriteColor.color;            
            SpriteColor.color = Color.Lerp(currentColor, tempClear, fadeTime * Time.deltaTime);
        }      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {        
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "Player2")
        {
            if (enabler.isActivated == true)
            {
                rb.isKinematic = false;
            }
        }
        else if (collision.collider.gameObject.layer == 6)
        {
            //fadeOut = true;        
            Invoke("DestroyObj", fadeTime);
        }
    }
    void DestroyObj()
    {
        //fadeOut = false;
        BoxCollider2D tempCol = this.gameObject.GetComponent<BoxCollider2D>();
        tempCol.enabled = false;
        rb.isKinematic = true;
        Invoke("RespawnObj", respawnTime);
    }

    void RespawnObj()
    {
        fadeOut = false;
        this.gameObject.transform.position = homePos;
        rb.velocity = new Vector2(0, 0);
        this.transform.rotation = rotationStorage;
        BoxCollider2D tempCol = this.gameObject.GetComponent<BoxCollider2D>();
        tempCol.enabled = true;        
    }
}
