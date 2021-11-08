using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlats : MonoBehaviour
{
    public float delay;
    public float fadeTime;
    public float respawnTime;
    public GameObject enablerObj;
    bool fadeOut = false;
    Vector3 homePos;
    Quaternion rotationStorage;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private EnableScript enabler;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();

        enabler = enablerObj.GetComponent<EnableScript>();

        rigidBody.isKinematic = true;
        homePos = transform.position;
    }

    void Update()
    {
        if(fadeOut == true)
        {
            Color tempColor = spriteRenderer.color;
            tempColor.a -= (1f / fadeTime) * Time.deltaTime;
            spriteRenderer.color = tempColor;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {        
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "Player2")
        {
            if (enabler.isActivated == true)
            {
<<<<<<< Updated upstream
                Invoke("Fall", delay);
=======
                rigidBody.isKinematic = false;
>>>>>>> Stashed changes
            }
        }
        else if (collision.collider.gameObject.layer == 6)
        {
            fadeOut = true;        
            Invoke("DestroyObj", fadeTime);
        }
    }

<<<<<<< Updated upstream
    void Fall()
    {
        rb.isKinematic = false;
    }
=======
>>>>>>> Stashed changes
    void DestroyObj()
    {
        fadeOut = false;
        boxCollider.enabled = false;
        rigidBody.isKinematic = true;
        Invoke("RespawnObj", respawnTime);
    }

    void RespawnObj()
    {
        fadeOut = false;
        transform.position = homePos;
        rigidBody.velocity = new Vector2(0, 0);
        this.transform.rotation = rotationStorage;
        boxCollider.enabled = true;

        Color tempColor = spriteRenderer.color;
        tempColor.a = 1f;
        spriteRenderer.color = tempColor;
    }
}
