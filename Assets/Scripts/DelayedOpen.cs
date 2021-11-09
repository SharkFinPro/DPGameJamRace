//------------------------------------------------------------------------------
//
// File Name:	DelayedOpen.cs
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

public class DelayedOpen : MonoBehaviour
{
    public GameObject door;
    public GameObject triggerObject;
    Trigger trigger;

    void Start()
    {
        trigger = triggerObject.GetComponent<Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger.IsActive)
            return;

        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        SpriteColor.color = Color.clear;
        BoxCollider2D doorcol = this.gameObject.GetComponent<BoxCollider2D>();
        doorcol.isTrigger = true;
    } 
}
