// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         Strength.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:58 PM
//    Created Date:     10/31/2023 1:58 PM
// -----------------------------------------

using System.Collections.Generic;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using UnityEngine;

namespace Powerups.Default;

public class StrengthPowerup : Powerup
{
    public StrengthPowerup(float grenadeDamageBoost, float firearmDamageBoost, float meleeDamageBoost, float powerupDuration)
    {
        _grenadeDamageBoost = grenadeDamageBoost;
        _firearmDamageBoost = firearmDamageBoost;
        _meleeDamageBoost = meleeDamageBoost;
        PowerupDuration = powerupDuration;
    }
    public override string Name { get; protected set; } = "Strength";
    public override string Description { get; protected set; } = "Makes your weapons and projectiles do more damage.";
    protected override string SchematicName { get; set; } = "Strength";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = 10;
    private float _grenadeDamageBoost;
    private float _firearmDamageBoost;
    private float _meleeDamageBoost;

    [PluginEvent(ServerEventType.PlayerDamage)]
    private void OnPlayerDamage(PlayerDamageEvent ev)
    {
        if(ev.Player is null || !this.PlayerHasEffect(ev.Player))
            return;
        if (ev.DamageHandler is FirearmDamageHandler firearmDamageHandler )
        {
            firearmDamageHandler.Damage *= _firearmDamageBoost;
        }

        if (ev.DamageHandler is ExplosionDamageHandler explosionDamageHandler)
        {
            explosionDamageHandler.Damage *= _grenadeDamageBoost;
        }

        if (ev.DamageHandler is JailbirdDamageHandler jailbirdDamageHandler)
        {
            jailbirdDamageHandler.Damage *= _meleeDamageBoost;
        }
    }
}