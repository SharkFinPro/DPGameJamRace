//------------------------------------------------------------------------------
//
// File Name:	PlayerManager.cs
// Author(s):	Alex Martin (alexander.martin@digipen.edu)
//              Tyler Dean (tyler.dean@digipen.edu)
//              Melanie Baloban (melanie.baloban@digipen.edu)
// Project:	November Game Jam - Vertical Race Game
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* Public Variables */
    public int PlayerNumber;
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

    public AudioSource soundEffectPlayer;
    public AudioClip deathSound;
    public AudioClip winSound;

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
        // Death
        if (rigidBody.position.y < DeathDepth)
        {
            SetPlayerInactive();
            
            soundEffectPlayer.Stop();
            soundEffectPlayer.clip = deathSound;
            soundEffectPlayer.Play(0);

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
            gameManager.endScene(PlayerNumber);
            soundEffectPlayer.clip = winSound;
            soundEffectPlayer.Play(0);
         
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
            soundEffectPlayer.clip = deathSound;
            soundEffectPlayer.Play(0);

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
