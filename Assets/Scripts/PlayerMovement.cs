using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* Public Variables */
    public float groundSpeed;
    public float maxGroundSpeed;
    public float groundFriction;

    public float airSpeed;
    public float maxAirSpeed;
    public float airFriction;

    public float jumpHeight;
    public int jumps;

    public LayerMask floorLayerMask;

    public GameManager gameManager;

    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;
    public CapsuleCollider2D capsuleCollider;

    public string upKey;
    public string leftKey;
    public string rightKey;

    /* Private Variables */
    private bool frozen = false;
    private float xVelocity;

    private bool jumping = true;
    private int jumped = 0;

    /* Game Updates */
    void Update()
    {
        /* Player Movement */
        if (frozen)
            return;

        if (Input.GetKeyDown(upKey) && !jumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            if (++jumped >= jumps)
                jumping = true;
        }

        
        // Ground movement
        if (capsuleCollider.IsTouchingLayers(floorLayerMask))
        {
            if (Input.GetKey(rightKey))
                rigidBody.velocity += new Vector2(groundSpeed * Time.deltaTime * 1000, 0f);

            if (Input.GetKey(leftKey))
                rigidBody.velocity -= new Vector2(groundSpeed * Time.deltaTime * 1000, 0f);

            rigidBody.velocity /= new Vector2(1 + (groundFriction * Time.deltaTime * 10), 1f);

            xVelocity = Mathf.Clamp(rigidBody.velocity.x, -maxGroundSpeed, maxGroundSpeed);
            rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
            return;
        }


        // Air movement
        if (Input.GetKey(rightKey))
            rigidBody.AddForce(new Vector2(airSpeed * Time.deltaTime * 1000, 0f));

        if (Input.GetKey(leftKey))
            rigidBody.AddForce(new Vector2(-airSpeed * Time.deltaTime * 1000, 0f));

        rigidBody.velocity /= new Vector2(1 + (airFriction * Time.deltaTime * 10), 1f);

        xVelocity = Mathf.Clamp(rigidBody.velocity.x, -maxAirSpeed, maxAirSpeed);
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "win")
        {
            gameManager.endScene();
            return;
        }

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
