using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public GameObject overlay;

    void Start()
    {
        player1.freeze();
        player2.freeze();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            player1.unFreeze();
            player2.unFreeze();
            overlay.SetActive(false);
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
