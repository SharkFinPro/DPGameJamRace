//------------------------------------------------------------------------------
//
// File Name:	GameManager.cs
// Author(s):	Alex Martin (alexander.martin@digipen.edu)
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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerManager player1;
    public PlayerManager player2;

    public GameObject menuOverlay;
    public GameObject endOverlay;

    public AudioSource musicPlayer;
    public AudioClip menuTheme;
    public AudioClip gameTheme;

    private string gameState = "menu";

    void Start()
    {
        menuScene();

        musicPlayer.clip = menuTheme;
        musicPlayer.Play(0);
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

        musicPlayer.Stop();
        musicPlayer.clip = gameTheme;
        musicPlayer.Play(0);
    }

    private void menuScene()
    {
        player2.freeze();
        player1.freeze();
        endOverlay.SetActive(false);
        menuOverlay.SetActive(true);
        gameState = "menu";
    }
}
