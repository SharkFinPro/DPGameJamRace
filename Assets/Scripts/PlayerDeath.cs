using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Vector3 RespawnPoint;
    public float DeathDepth = -10;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        RespawnPoint = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < DeathDepth)
        {
            Player.transform.position = RespawnPoint;
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
            Player.transform.position = RespawnPoint;            
        }
    }
}
