// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         GoldenGunPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:59 PM
//    Created Date:     10/31/2023 1:59 PM
// -----------------------------------------

using System.Collections.Generic;
using System.Linq;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using UnityEngine;

namespace Powerups.Default;

public class GoldenGunPowerup : Powerup
{
    public GoldenGunPowerup(ItemType itemType, IDamageHandler? handler = null)
    {
        WeaponType = itemType;
    }

    protected internal override void OnRegistering()
    {
        EventManager.RegisterEvents(this);
    }

    protected internal override void OnUnregistering()
    {
        EventManager.UnregisterEvents(this);
    }

    private IDamageHandler DamageHandler { get; set; }
    private ItemType WeaponType { get; set; }
    public override string Name { get; protected set; } = "Golden Gun";
    public override string Description { get; protected set; } = "Gives you a golden gun that one-shots other players.";
    protected override string SchematicName { get; set; } = "GoldenGun";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = -1;
    private List<ushort> _trackedItems { get; set; } = new List<ushort>();

    [PluginEvent(ServerEventType.PlayerDamage)]
    private void OnPlayerDamage(PlayerDamageEvent ev)
    {
        if (ev.DamageHandler is not FirearmDamageHandler handler)
            return;
        
        if (!_trackedItems.Contains(ev.Player.CurrentItem.ItemSerial))
            return;
        
        DamageHandler.ProcessDamage(ev);
        this.RemovePowerup(ev.Player);
    }
    protected override void OnApplyPowerup(Player ply)
    {
        var item = ply.AddItem(WeaponType);
        _trackedItems.Add(item.ItemSerial);
    }

    protected override void OnRemovePowerup(Player ply)
    {
        var item = ply.Items.FirstOrDefault(x => _trackedItems.Contains(x.ItemSerial));
        ply.RemoveItem(item);
    }

    private class OneShotKill : IDamageHandler
    {
        public void ProcessDamage(PlayerDamageEvent ev)
        {
            ev.Target.Kill("The golden gun strikes again!");
        }
    }
    public interface IDamageHandler
    {
        public void ProcessDamage(PlayerDamageEvent ev);
    }
}