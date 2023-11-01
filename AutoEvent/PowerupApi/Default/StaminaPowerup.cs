// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         StaminaPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:59 PM
//    Created Date:     10/31/2023 1:59 PM
// -----------------------------------------

using CustomPlayerEffects;
using PluginAPI.Core;
using Powerups.Extensions;
using UnityEngine;

namespace Powerups.Default;

public class StaminaPowerup : Powerup
{
    public override string Name { get; protected set; } = "Stamina";
    public override string Description { get; protected set; } = "Gives you infinite stamina.";
    protected override string SchematicName { get; set; } = "Stamina";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    protected override void OnApplyPowerup(Player ply)
    {
        ply.EffectsManager.EnableEffect<Invigorated>();
        ply.ApplyFakeEffect<Invigorated>(0);
    }

    protected override void OnRemovePowerup(Player ply)
    {
        ply.EffectsManager.DisableEffect<Invigorated>();
        ply.ApplyFakeEffect<Invigorated>(0);
    }
}