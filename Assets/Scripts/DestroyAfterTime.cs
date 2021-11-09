//------------------------------------------------------------------------------
//
// File Name:	DestroyAfterTime.cs
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

public class DestroyAfterTime : MonoBehaviour
{
    public int lifetime;

    void Update()
    {
        Invoke("destroyObj", lifetime);
    }

    void destroyObj()
    {
        Destroy(this.gameObject);
    }
}
