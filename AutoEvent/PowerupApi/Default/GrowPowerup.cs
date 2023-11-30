// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         ResizeBigPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:59 PM
//    Created Date:     10/31/2023 1:59 PM
// -----------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using PluginAPI.Core;
using Powerups.Extensions;
using UnityEngine;

namespace Powerups.Default;

public class GrowPowerup : Powerup
{
    public GrowPowerup(float scaleMultiplier, float powerupDuration)
    {
        ResizeAmount = new Vector3(scaleMultiplier,scaleMultiplier,scaleMultiplier);
        PowerupDuration = powerupDuration;
    }
    public GrowPowerup(Vector3 scaleMultiplier, float powerupDuration)
    {
        ResizeAmount = scaleMultiplier;
        PowerupDuration = powerupDuration;
    }
    public override string Name { get; protected set; } = "Grow";
    public override string Description { get; protected set; } = "Makes you grow.";
    protected override string SchematicName { get; set; } = "ResizeBig";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = 10;
    private Dictionary<Player, Vector3> _playerScales { get; set; } = new Dictionary<Player, Vector3>();
    public ReadOnlyDictionary<Player, Vector3> PlayerScales => new(_playerScales);
    public Vector3 ResizeAmount { get; } 
    protected override void OnApplyPowerup(Player ply)
    {
        Vector3 curScale = ply.GameObject.transform.localScale;
        if (!_playerScales.ContainsKey(ply))
        {
            _playerScales.Add(ply, curScale);
        }
        ply.SetPlayerScale(new Vector3(curScale.x * ResizeAmount.x, curScale.y * ResizeAmount.y, curScale.z * ResizeAmount.z));
    }

    protected override void OnRemovePowerup(Player ply)
    {
        if (_playerScales.ContainsKey(ply))
        {
            ply.SetPlayerScale(_playerScales[ply]);
            _playerScales.Remove(ply);
        }
    }
}