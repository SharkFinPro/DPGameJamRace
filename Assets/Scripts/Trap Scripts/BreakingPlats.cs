using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlats : MonoBehaviour
{
    public int delay;
    public float fadeTime;
    Rigidbody2D rb;
    EnableScript enabler;
    public GameObject enablerObj;
    private bool fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enabler = enablerObj.GetComponent<EnableScript>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeOut == true)
        {
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
            Color currentColor = SpriteColor.color;
            SpriteColor.color = Color.Lerp(currentColor, Color.clear, fadeTime * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
            fadeOut = true;        
            Invoke("DestroyObj", fadeTime);
        }
    }
    void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
