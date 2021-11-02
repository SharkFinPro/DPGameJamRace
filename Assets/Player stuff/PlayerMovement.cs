using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public float speed;
    public float maxSpeed;

    public float jumpHeight;
    private bool jumping = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("up") && !jumping)
        {
            rb.AddForce(new Vector2(0f, jumpHeight));
            jumping = true;
        }

        if (Input.GetKey("right"))
        {
            rb.AddForce(new Vector2(speed, 0f));
        }

        if (Input.GetKey("left"))
        {
            rb.AddForce(new Vector2(-speed, 0f));
        }

        float x = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(x, rb.velocity.y);

        LayerMask mask = LayerMask.GetMask("Platforms");
        if (bc.IsTouchingLayers(mask))
        {
            jumping = false;
        }
    }
}
