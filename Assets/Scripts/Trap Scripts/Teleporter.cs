//------------------------------------------------------------------------------
//
// File Name:	Teleporter.cs
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

public class Teleporter : MonoBehaviour
{
    public GameObject exitPoint;
    public GameObject triggerObject;
    
    private Trigger trigger;

    void Start()
    {
        trigger = triggerObject.GetComponent<Trigger>();
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        SpriteColor.color = Color.gray;
    }

    void Update()
    {
        if (!trigger.IsActive)
            return;

        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        SpriteColor.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2") && trigger.IsActive)
            collision.gameObject.transform.position = exitPoint.transform.position;
    }
    
}
