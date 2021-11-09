using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D button;
    public Collider2D player1;
    public Collider2D player2;
    public float timeToRestoreDoor = 0;
    public float transformDistance = 10.0f;

    public AudioSource soundEffectPlayer;
    public AudioClip teleportSound;

    private void Start()
    {
        button.tag = "open";
    }

    void Update()
    {
        if (button.IsTouching(player1) && Input.GetKey(KeyCode.LeftShift) && button.tag == "open")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            button.tag = "closed";
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(transform.position.x, transform.position.y + transformDistance);
            soundEffectPlayer.clip = teleportSound;
            soundEffectPlayer.Play(0);
            timeToRestoreDoor = 5;
        }
        if (button.IsTouching(player2) && Input.GetKey(KeyCode.RightShift) && button.tag == "open")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            button.tag = "closed";
            GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector2(transform.position.x, transform.position.y + transformDistance);
            soundEffectPlayer.clip = teleportSound;
            soundEffectPlayer.Play(0);
            timeToRestoreDoor = 5;
        }
        else
        {
            if (timeToRestoreDoor > 0)
            {
                timeToRestoreDoor -= Time.deltaTime;
                if (timeToRestoreDoor <= 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    button.tag = "open";
                }

            }
        }
    }
}

