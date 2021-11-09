//------------------------------------------------------------------------------
//
// File Name:	FallingBlocks.cs
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

public class FallingBlocks : MonoBehaviour
{    
    public float fadeTime;
    public GameObject enablerObj;

    private Rigidbody2D rigidBody;
    private EnableScript enabler;

    private bool fadeOut = false;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        enabler = enablerObj.GetComponent<EnableScript>();
        rigidBody.isKinematic = true;
    }

    void Update()
    {
        if (fadeOut == true)
        {
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
            Color currentColor = SpriteColor.color;
            SpriteColor.color = Color.Lerp(currentColor, Color.clear, fadeTime * Time.deltaTime);
        }
        if (enabler.isActivated == true)
            rigidBody.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if (collision.collider.gameObject.layer == 6)
        {
            fadeOut = true;
            Invoke("DestroyObj", fadeTime);
        }
    }

    void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
