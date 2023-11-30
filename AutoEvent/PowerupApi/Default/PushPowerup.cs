// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         PushPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:59 PM
//    Created Date:     10/31/2023 1:59 PM
// -----------------------------------------

using PluginAPI.Core;
using Powerups.Components;
using UnityEngine;

namespace Powerups.Default;

public class PushPowerup : Powerup
{
    public PushPowerup(float force, float distance, float powerupDuration)
    {
        Force = force;
        Distance = distance;
        PowerupDuration = powerupDuration;
    }
    public override string Name { get; protected set; } = "Push";
    public override string Description { get; protected set; } = "Pushes people out of the way.";
    
    protected override string SchematicName { get; set; } = "Push";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = 10;
    public float Force;
    public float Distance;
    protected override void OnApplyPowerup(Player ply)
    {
        ply.GameObject.AddComponent<PushComponent>().Init(Force, Distance);
    }

    protected override void OnRemovePowerup(Player ply)
    {
        if (ply.GameObject.TryGetComponent<PushComponent>(out var component))
        {
            GameObject.Destroy(component);
        }   
    }
}