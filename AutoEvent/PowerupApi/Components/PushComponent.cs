// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         PushComponent.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 2:25 PM
//    Created Date:     10/31/2023 2:25 PM
// -----------------------------------------

using System;
using System.Collections.Generic;
using Exiled.API.Extensions;
using Exiled.API.Features;
using InventorySystem.Items.SwitchableLightSources.Flashlight;
using InventorySystem.Items.SwitchableLightSources.Lantern;
using MEC;
using UnityEngine;

namespace Powerups.Components;

public class PushComponent : MonoBehaviour
{
    public float PushForce;
    public float PushDistance;
    public void Init(float force, float distance = 2f)
    {
        PushForce = force;
        PushDistance = distance;
        Player ply;
    }

    private void FixedUpdate()
    {
        //Physics.Raycast(gameObject.transform.forward, out var hitInfo, PushDistance);
        
        //gameObject

    }
    
    private IEnumerator<float> PushPlayer(Exiled.API.Features.Player Instigator, Exiled.API.Features.Player Victim)
    {/*
        Vector3 pushed = Instigator.CameraTransform.forward * PushForce;
        Vector3 endPos = Victim.Position + new Vector3(pushed.x, 0, pushed.z);
        int layerAsLayerMask = 0;
        for (int x = 1; x < 8; x++)
            layerAsLayerMask |= (1 << x);
        for (int i = 1; i < Plugin.Instance.Config.Iterations; i++)
        {

            float movementAmount = Plugin.Instance.Config.PushForce / Plugin.Instance.Config.Iterations;


            Vector3 newPos = Vector3.MoveTowards(Victim.Position, endPos, movementAmount);

            if (Physics.Linecast(Victim.Position, newPos, layerAsLayerMask))
                yield break;

            Victim.Position = newPos;


            yield return Timing.WaitForOneFrame;
        }*/
        yield break;
    }
    
}