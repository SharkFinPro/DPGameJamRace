using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D button;
    public Collider2D player1;
    public Collider2D player2;
    public float timeToRestoreDoor = 0;

    void Update()
    {
        if (button.IsTouching(player1) && Input.GetKey(KeyCode.LeftShift) || button.IsTouching(player2) && Input.GetKey(KeyCode.RightShift))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
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
                }

            }
        }
    }
}

