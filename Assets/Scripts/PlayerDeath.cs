using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Vector3 RespawnPoint;
    public float RespawnTimer;
    public float DeathDepth = -10;
    GameObject Player;
    Color playerColor;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        playerColor = SpriteColor.color;
        Player = this.gameObject;
        RespawnPoint = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < DeathDepth)
        {
            SetPlayerInactive();
            Player.transform.position = RespawnPoint;
            Invoke("SetPlayerActive", RespawnTimer);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "respawn")
        {
            RespawnPoint = collision.gameObject.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "death")
        {
            SetPlayerInactive();
            Player.transform.position = RespawnPoint;
            Invoke("SetPlayerActive", RespawnTimer);
        }
    }

    void SetPlayerInactive()
    {
        PlayerMovement playerMove = this.gameObject.GetComponent<PlayerMovement>();
        playerMove.enabled = false;
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        SpriteColor.color = Color.clear;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
    }
    void SetPlayerActive()
    {
        PlayerMovement playerMove = this.gameObject.GetComponent<PlayerMovement>();
        playerMove.enabled = true;
        Player.transform.position = RespawnPoint;
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        SpriteColor.color = playerColor;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = false;
    }
}
