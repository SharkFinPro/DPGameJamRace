using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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

    public string upKey;
    public string leftKey;
    public string rightKey;

    public float RespawnTimer = 3;
    public float DeathDepth = -10;
    public ParticleSystem deathParticles;

    /* Private Variables */
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D groundCollider;
    private SpriteRenderer spriteRenderer;

    private bool frozen = false;
    private float xVelocity;

    private bool jumping = true;
    private int jumped = 0;

    private Vector3 respawnPoint;
    private Color playerColor;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerColor = spriteRenderer.color;
        respawnPoint = rigidBody.position;
    }

    /* Game Updates */
    void Update()
    {
        // death
        if (rigidBody.position.y < DeathDepth)
        {
            SetPlayerInactive();
            rigidBody.position = respawnPoint;
            Instantiate(deathParticles, rigidBody.position, Quaternion.identity);
            Invoke("SetPlayerActive", RespawnTimer);
        }

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
        if (groundCollider.IsTouchingLayers(floorLayerMask))
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
        else if (collision.tag == "respawn")
        {
            respawnPoint = collision.transform.position;
        }

        if (groundCollider.IsTouchingLayers(floorLayerMask))
        {
            jumping = false;
            jumped = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "death")
        {
            SetPlayerInactive();
            rigidBody.position = respawnPoint;
            Instantiate(deathParticles, rigidBody.position, Quaternion.identity);
            Invoke("SetPlayerActive", RespawnTimer);
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

    void SetPlayerInactive()
    {
        freeze();
        spriteRenderer.color = Color.clear;
        rigidBody.velocity = new Vector2(0, 0);
        rigidBody.isKinematic = true;
    }

    void SetPlayerActive()
    {
        unFreeze();
        rigidBody.position = respawnPoint;
        spriteRenderer.color = playerColor;
        rigidBody.velocity = new Vector2(0, 0);
        rigidBody.isKinematic = false;
    }
}
