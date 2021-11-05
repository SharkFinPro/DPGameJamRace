using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public GameObject menuOverlay;
    public GameObject endOverlay;

    private string gameState = "menu";

    void Start()
    {
        endOverlay.SetActive(false);
        player1.freeze();
        player2.freeze();
    }

    void Update()
    {
        if (gameState == "menu")
        {
            if (Input.GetKeyDown("space"))
            {
                player1.unFreeze();
                player2.unFreeze();
                menuOverlay.SetActive(false);
                gameState = "play";
            }

            if (Input.GetKeyDown("escape"))
            {
                Application.Quit();
            }
        }
        else if (gameState == "play")
        {
            //
        }
        else if (gameState == "end")
        {
            if (Input.GetKeyDown("return"))
            {
                gameState = "menu";
                endOverlay.SetActive(false);
                menuOverlay.SetActive(true);
            }
        }
    }

    public void endScene()
    {
        player1.freeze();
        player2.freeze();
        gameState = "end";
        endOverlay.SetActive(true);
    }
}
