using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider;

    public float speed;
    public float maxSpeed;
    public float groundFriction;

    public float jumpHeight;
    private bool jumping = true;
    public int jumps;
    private int jumped = 0;

    public string upKey;
    public string leftKey;
    public string rightKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask floorLayerMask = LayerMask.GetMask("Platforms");
        bool touchingFloor = boxCollider.IsTouchingLayers(floorLayerMask);

        if (Input.GetKeyDown(upKey) && !jumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            jumped++;
            if (jumped >= jumps - 1)
            {
                jumping = true;
            }
        }

        if (Input.GetKey(rightKey))
        {
            if (touchingFloor)
            {
                rigidBody.velocity += new Vector2(speed / 10, 0f);
            }
            else
            {
                rigidBody.AddForce(new Vector2(speed, 0f));
            }
        }

        if (Input.GetKey(leftKey))
        {
            if (touchingFloor)
            {
                rigidBody.velocity -= new Vector2(speed / 10, 0f);
            }
            else
            {
                rigidBody.AddForce(new Vector2(-speed, 0f));
            }
        }

        float xVelocity = Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed);
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);

        
        if (touchingFloor)
        {
            jumping = false;
            jumped = 0;
            rigidBody.velocity /= new Vector2(groundFriction, 1f);
        }
    }
}
