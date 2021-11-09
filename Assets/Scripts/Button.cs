//------------------------------------------------------------------------------
//
// File Name:	Button.cs
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

public class Button : MonoBehaviour
{  
    public bool isOn = false;   
    public GameObject triggerObject;
    
    private Trigger trigger;
    private SpriteRenderer SpriteColor;

    void Start()
    {
        trigger = triggerObject.GetComponent<Trigger>();
        SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (trigger.IsActive == false)
            SpriteColor.material.color = Color.white;
        else if (trigger.IsActive == true && isOn == false)
            SpriteColor.material.color = Color.gray;
        else if (trigger.IsActive == true && isOn == true)
            SpriteColor.material.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            if (trigger.IsActive)
                isOn = true;
        }
    }
}
