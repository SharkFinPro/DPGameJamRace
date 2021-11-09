//------------------------------------------------------------------------------
//
// File Name:	SplitCams.cs
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

public class SplitCams : MonoBehaviour
{
    public float CamMoveSpeed = 10;
    public float CamDistance = -10f;
    public float CamOffset = 1;
    
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Player1;
    public GameObject Player2;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 NextCamera1Pos = new Vector3(Camera1.transform.position.x, Player1.transform.position.y + CamOffset, CamDistance);
        Vector3 NextCamera2Pos = new Vector3(Camera2.transform.position.x, Player2.transform.position.y + CamOffset, CamDistance);
        Camera1.transform.position = Vector3.Lerp(Camera1.transform.position, NextCamera1Pos, Time.deltaTime * CamMoveSpeed);
        Camera2.transform.position = Vector3.Lerp(Camera2.transform.position, NextCamera2Pos, Time.deltaTime * CamMoveSpeed);
    }
}

