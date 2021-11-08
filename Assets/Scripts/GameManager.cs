using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public GameObject menuOverlay;
    public GameObject endOverlay;

    private string gameState = "menu";

    void Start()
    {
        menuScene();
    }

    void Update()
    {
        if (gameState == "menu")
        {
            if (Input.GetKeyDown("space"))
                playScene();

            if (Input.GetKeyDown("escape"))
                Application.Quit();
        }
        else if (gameState == "end")
        {
            if (Input.GetKeyDown("return"))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    public void endScene()
    {
        player1.freeze();
        player2.freeze();
        endOverlay.SetActive(true);
        gameState = "end";
    }

    private void playScene()
    {
        player1.unFreeze();
        player2.unFreeze();
        menuOverlay.SetActive(false);
        gameState = "play";
    }

    private void menuScene()
    {
        player1.freeze();
        player2.freeze();
        endOverlay.SetActive(false);
        menuOverlay.SetActive(true);
        gameState = "menu";
    }
}
