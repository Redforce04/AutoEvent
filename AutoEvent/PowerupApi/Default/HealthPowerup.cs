// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         HealthPowerup.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 1:58 PM
//    Created Date:     10/31/2023 1:58 PM
// -----------------------------------------

using System.Collections.Generic;
using MEC;
using PluginAPI.Core;
using UnityEngine;

namespace Powerups.Default;

public class HealthPowerup : Powerup
{
    protected HealthPowerup(){ }
    public HealthPowerup(HealOptions healthRegenerationMethod, float powerupDuration)
    {
        HealMethod = healthRegenerationMethod;
        PowerupDuration = powerupDuration;
    }

    protected internal override void OnRegistering()
    {
        if (HealMethod is ICoroutine)
        {
            CoroutineHandle = Timing.RunCoroutine(HealCoroutine(), "Heal Powerup Coroutine");
        }
    }

    protected internal override void OnUnregistering()
    {
        if (CoroutineHandle.IsRunning)
        {
            Timing.KillCoroutines(CoroutineHandle);
        }
    }

    internal CoroutineHandle CoroutineHandle;
    
    public override string Name { get; protected set; } = "Heal";
    public override string Description { get; protected set; } = "Heals you.";
    protected override string SchematicName { get; set; } = "Health";
    protected override Vector3 SchematicScale { get; set; } = new Vector3(1,1,1);
    public override float PowerupDuration { get; protected set; } = 10;
    protected override Vector3 ColliderScale { get; set; }= new Vector3(1,1,1);
    public virtual HealOptions HealMethod { get; protected set; } = null!;

    private IEnumerator<float> HealCoroutine()
    {
        yield return Timing.WaitForSeconds(1f);
        if (HealMethod is not ICoroutine coroutine)
            yield break;
        while (true)
        {
            coroutine.ProcessHealUpdate();
            yield return Timing.WaitForSeconds(1f);
        }
    }
    
    protected override void OnApplyPowerup(Player ply)
    {
        HealMethod.AddPlayer(ply);
    }

    protected override void OnRemovePowerup(Player ply)
    {
        HealMethod.RemovePlayer(ply);
    }
}

public interface ICoroutine
{
    public void ProcessHealUpdate();
}
public abstract class HealOptions
{ 
    public abstract void AddPlayer(Player ply);

    public virtual void RemovePlayer(Player ply)
    {
        
    }
}

internal class HealSettings : HealOptions
{
    public HealSettings(float healAmount = 0f, bool healFully = false)
    {
        HealAmount = healAmount;
        HealFully = healFully;
    }
    public bool HealFully { get; set; } = false;
    public float HealAmount { get; set; } = 0f;

    public override void AddPlayer(Player ply)
    {
        ply.Health = HealFully ? ply.MaxHealth : Mathf.Clamp(ply.Health + HealAmount, 0, ply.MaxHealth);
    }
}
public class RegenerateHealthSettings : HealOptions, ICoroutine
{
    public RegenerateHealthSettings(float healthPerSecond, float regenerationMax, bool regenerateMultipleTimes = true, RegenerationAmountMode regenerationReferencePlayerHealth = RegenerationAmountMode.PlayerRelativeHealth)
    {
        HealthPerSecond = healthPerSecond;
        RegenerationMaxAmount = regenerationMax;
        RegenerateMultipleTimes = regenerateMultipleTimes;
        RegenerationMaxAmountMode = regenerationReferencePlayerHealth;
    }
    private Dictionary<Player, PlayerInfo> _initialPlayerHealth = new Dictionary<Player, PlayerInfo>();
    public void ProcessHealUpdate()
    {
        List<Player> values = new List<Player>();
        foreach(var ply in _initialPlayerHealth.Keys)
            values.Add(ply);
        for (var i = 0; i < _initialPlayerHealth.Count; i++)
        {
            var playerInfo = _initialPlayerHealth[values[i]];
            playerInfo.SecondAppliedFor += 1f;
            if (playerInfo.HitHealthLimit)
            {
                continue;
            }

            float healthToGive = Mathf.Clamp(HealthToGivePlayer(playerInfo.Player, playerInfo.SecondAppliedFor), (-1 *playerInfo.Player.MaxHealth), playerInfo.Player.MaxHealth);
            playerInfo.Player.Health += healthToGive;
            playerInfo.HealthGiven += healthToGive;
            if (RegenerateMultipleTimes)
                goto update;
            
            if (RegenerationMaxAmountMode == RegenerationAmountMode.GivenHealth)
            {
                if(playerInfo.HealthGiven >= RegenerationMaxAmount)
                    playerInfo.HitHealthLimit = true;
                goto update;
            }

            if ((RegenerationMaxAmountMode == RegenerationAmountMode.PlayerTotalHealth ? playerInfo.Player.Health : playerInfo.Player.Health - playerInfo.InitialHealth) >= RegenerationMaxAmount)
                playerInfo.HitHealthLimit = true;

            update:
            _initialPlayerHealth[values[i]] = playerInfo;
        }
    }

    public override void AddPlayer(Player ply)
    {
        if(!_initialPlayerHealth.ContainsKey(ply)) 
            this._initialPlayerHealth.Add(ply, new PlayerInfo(ply));
    }

    public override void RemovePlayer(Player ply)
    {
        if (_initialPlayerHealth.ContainsKey(ply))
            this._initialPlayerHealth.Remove(ply);
    }

    /// <summary>
    /// Gets the health to give the player. Can be overriden for custom implementation.
    /// </summary>
    public virtual float HealthToGivePlayer(Player ply, float durationAppliedForInSeconds)
    {
        return HealthPerSecond;
    }
    
    /// <summary>
    /// The health to give to a player per second. Default Implementation.
    /// </summary>
    private float HealthPerSecond { get; set; }
    
    /// <summary>
    /// How much health the regeneration will give from the start health.
    /// </summary>
    public float RegenerationMaxAmount { get; set; }
    
    /// <summary>
    /// Should the player continue to regenerate.
    /// </summary>
    public bool RegenerateMultipleTimes { get; set; }
    
    /// <summary>
    /// How the maximum health is calculated.
    /// </summary>
    public RegenerationAmountMode RegenerationMaxAmountMode { get; set; }

    public enum RegenerationAmountMode
    {
        PlayerTotalHealth,
        PlayerRelativeHealth,
        GivenHealth,
    }
    private class PlayerInfo
    {
        protected internal PlayerInfo(Player ply)
        {
            Player = ply;
            InitialHealth = ply.Health;
            HealthGiven = 0;
            HitHealthLimit = false;
        }
        protected internal Player Player { get; set; }
        protected internal float InitialHealth { get; set; }
        protected internal float HealthGiven { get; set; }
        protected internal bool HitHealthLimit { get; set; }
        protected internal float SecondAppliedFor { get; set; }
    }
}