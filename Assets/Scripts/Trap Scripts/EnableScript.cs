//------------------------------------------------------------------------------
//
// File Name:	EnableScript.cs
// Author(s):	Alex Martin (alexander.martin@digipen.edu)
//              Tyler Dean (tyler.dean@digipen.edu)
// Project:	November Game Jam - Vertical Race Game
// Course:	WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
    public GameObject buttonObj;    
    public bool fadeIn = true;
    public float fadeTime = 0;
    public bool isActivated;

    private Button buttonscript;
    private Color oldColor;
    private GameObject gameToBeEnabled;

    void Start()
    {
        buttonscript = buttonObj.GetComponent<Button>();
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        oldColor = SpriteColor.color;
        Color clearColor = oldColor;
        clearColor.a = 0f;

        gameToBeEnabled = this.gameObject;
        if (fadeIn)
            SpriteColor.color = clearColor;

        BoxCollider2D boxcollider = gameToBeEnabled.GetComponent<BoxCollider2D>();
        boxcollider.enabled = false;
    }

    void Update()
    {
        isActivated = buttonscript.isOn;
        if (buttonscript.isOn)
        { 
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();            
            if (fadeIn)
            {
                SpriteColor.color = Color.Lerp(SpriteColor.color, oldColor, fadeTime * Time.deltaTime);
            }
            else
                SpriteColor.color = oldColor;

            BoxCollider2D boxcollider = gameToBeEnabled.GetComponent<BoxCollider2D>();
            boxcollider.enabled = true;
        }
    }
}
