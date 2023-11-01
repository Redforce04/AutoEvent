// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         ShieldPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:59 PM
//    Created Date:     10/31/2023 1:59 PM
// -----------------------------------------

using CustomPlayerEffects;
using InventorySystem.Items.MarshmallowMan;
using PluginAPI.Core;
using UnityEngine;

namespace Powerups.Default;

public class ShieldPowerup : Powerup
{
    public ShieldPowerup(float damageReductionAmount, float powerupDuration)
    {
        DamageReductionAmount = damageReductionAmount;
        PowerupDuration = powerupDuration;
    }
    public override string Name { get; protected set; } = "Protection";
    public override string Description { get; protected set; } = "Shields the player from damage.";
    protected override string SchematicName { get; set; } = "Shield";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public float DamageReductionAmount { get; protected set; } 
    public override float PowerupDuration { get; protected set; } = 10;
    protected override void OnApplyPowerup(Player ply)
    {
        DamageReduction fx;
        if (!ply.EffectsManager.TryGetEffect<DamageReduction>(out fx) || fx is null)
        {
            fx = ply.EffectsManager.EnableEffect<DamageReduction>()!;
        }

        fx.Intensity = (byte)(2 * DamageReductionAmount);
    }

    protected override void OnRemovePowerup(Player ply)
    {
        if (ply.EffectsManager.TryGetEffect<DamageReduction>(out var reduction))
        {
            reduction.DisableEffect();
        }
    }
}