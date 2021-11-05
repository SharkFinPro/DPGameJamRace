using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;

    public float groundSpeed;
    public float maxGroundSpeed;
    public float groundFriction;

    public float airSpeed;
    public float maxAirSpeed;
    public float airFriction;

    private bool frozen = false;

    private float xVelocity;

    public float jumpHeight;
    private bool jumping = true;
    public int jumps;
    private int jumped = 0;

    public string upKey;
    public string leftKey;
    public string rightKey;

    public CapsuleCollider2D capsuleCollider;

    public LayerMask floorLayerMask;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Player Movement */
        if (frozen)
        {
            return;
        }  

        if (Input.GetKeyDown(upKey) && !jumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            jumped++;
            if (jumped >= jumps)
            {
                jumping = true;
            }
        }

        
        // Ground movement
        if (boxCollider.IsTouchingLayers(floorLayerMask))
        {
            if (Input.GetKey(rightKey))
            {
                rigidBody.velocity += new Vector2(groundSpeed * Time.deltaTime * 1000, 0f);
            }

            if (Input.GetKey(leftKey))
            {
                rigidBody.velocity -= new Vector2(groundSpeed * Time.deltaTime * 1000, 0f);
            }

            rigidBody.velocity /= new Vector2(1 + (groundFriction * Time.deltaTime * 10), 1f);

            xVelocity = Mathf.Clamp(rigidBody.velocity.x, -maxGroundSpeed, maxGroundSpeed);
            rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
            return;
        }


        // Air movement
        if (Input.GetKey(rightKey))
        {
            rigidBody.AddForce(new Vector2(airSpeed * Time.deltaTime * 1000, 0f));
        }

        if (Input.GetKey(leftKey))
        {
            rigidBody.AddForce(new Vector2(-airSpeed * Time.deltaTime * 1000, 0f));
        }

        rigidBody.velocity /= new Vector2(1 + (airFriction * Time.deltaTime * 10), 1f);

        xVelocity = Mathf.Clamp(rigidBody.velocity.x, -maxAirSpeed, maxAirSpeed);
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (capsuleCollider.IsTouchingLayers(floorLayerMask))
        {
            jumping = false;
            jumped = 0;
        }
    }

    public void freeze()
    {
        frozen = true;
        rigidBody.velocity = new Vector2(0f, 0f);
    }

    public void unFreeze()
    {
        frozen = false;
    }
}
