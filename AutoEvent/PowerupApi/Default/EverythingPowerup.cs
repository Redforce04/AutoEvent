// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         EverythingPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 2:00 PM
//    Created Date:     10/31/2023 2:00 PM
// -----------------------------------------

using PluginAPI.Core;
using UnityEngine;

namespace Powerups.Default;

public class EverythingPowerup : Powerup
{
    public override string Name { get; protected set; } = "Everything";
    public override string Description { get; protected set; } = "Who knows what powers this unleashes?";
    protected override string SchematicName { get; set; } = "Strength";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = -1;

    protected override void OnApplyPowerup(Player ply)
    {
        
    }

    protected override void OnRemovePowerup(Player ply)
    {
        
    }
}