﻿// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         Effects.cs
//    Author:           Redforce04#4091
//    Revision Date:    09/17/2023 2:03 PM
//    Created Date:     09/17/2023 2:03 PM
// -----------------------------------------

namespace AutoEvent.API.Enums;

/// <summary>
/// List of Effects that can be used.
/// </summary>
public enum StatusEffect
{
    /// <summary>
    /// The player isn't able to open their inventory or reload a weapon.
    /// </summary>
    AmnesiaItems,

    /// <summary>The player isn't able to see properly.</summary>
    AmnesiaVision,

    /// <summary>Drains the player's stamina and then health.</summary>
    Asphyxiated,

    /// <summary>Damages the player over time.</summary>
    Bleeding,

    /// <summary>Blurs the player's screen.</summary>
    Blinded,

    /// <summary>
    /// Increases damage the player receives. Does not apply any standalone damage.
    /// </summary>
    Burned,

    /// <summary>Blurs the player's screen while rotating.</summary>
    Concussed,

    /// <summary>Effect given to player after being hurt by SCP-106.</summary>
    Corroding,

    /// <summary>Deafens the player.</summary>
    Deafened,

    /// <summary>Removes 10% of the player's health per second.</summary>
    Decontaminating,

    /// <summary>Slows down the player's movement.</summary>
    Disabled,

    /// <summary>Prevents the player from moving.</summary>
    Ensnared,

    /// <summary>
    /// Halves the player's maximum stamina and stamina regeneration rate.
    /// </summary>
    Exhausted,

    /// <summary>Flashes the player.</summary>
    Flashed,

    /// <summary>Drains the player's health while sprinting.</summary>
    Hemorrhage,

    /// <summary>
    /// Reduces the player's FOV, gives infinite stamina and gives the effect of underwater sound.
    /// </summary>
    Invigorated,

    /// <summary>Reduces damage taken by body shots.</summary>
    BodyshotReduction,

    /// <summary>
    /// Damages the player every 5 seconds, starting low and increasing over time.
    /// </summary>
    Poisoned,

    /// <summary>
    /// Increases the speed of the player while also draining health.
    /// </summary>
    Scp207,

    /// <summary>Makes the player invisible.</summary>
    Invisible,

    /// <summary>
    /// Slows down the player's movement with the SCP-106 sinkhole effect.
    /// </summary>
    SinkHole,

    /// <summary>Reduces overall damage taken.</summary>
    DamageReduction,

    /// <summary>Increases movement speed.</summary>
    MovementBoost,

    /// <summary>Severely reduces damage taken.</summary>
    RainbowTaste,

    /// <summary>
    /// Drops the player's current item and deals damage while effect is active.
    /// </summary>
    SeveredHands,

    /// <summary>
    /// Prevents the player from sprinting and reduces movement speed by 20%.
    /// </summary>
    Stained,

    /// <summary>Causes the player to slowly regenerate health.</summary>
    Vitality,

    /// <summary>
    /// Cause the player to slowly take damage by Hyporthermia.
    /// </summary>
    Hypothermia,

    /// <summary>Cause the player more effective for fight.</summary>
    Scp1853,

    /// <summary>Effect given to player after being hurt by SCP-049.</summary>
    CardiacArrest,

    /// <summary>
    /// Cause the lighting in the facility to dim heavily for the player.
    /// </summary>
    InsufficientLighting,

    /// <summary>Disable ambient sound.</summary>
    SoundtrackMute,

    /// <summary>Protect player from enemy if the config is Enable.</summary>
    SpawnProtected,

    /// <summary>
    /// Make Scp106 able to see you when he are in the ground (stalking).
    /// </summary>
    Traumatized,

    /// <summary>
    /// Same effect as Scp207, but Healing instead of Hurting.
    /// </summary>
    AntiScp207,

    /// <summary>
    /// The effect that SCP-079 gives the Scanned player with the Breach Scanner.
    /// </summary>
    Scanned,

    /// <summary>
    /// Teleports the player to the pocket dimension and drains health until the player escapes or is killed.
    /// </summary>
    PocketCorroding,
    
    /// <summary>
    /// The effect permit player to go trough door like Scp-106.
    /// </summary>
    Ghostly,
    
    /// <summary>
    /// Effect given to player when being strangled by SCP-3114.
    /// </summary>
    Strangled,
    OrangeCandy,
    Spicy,
    SugarCrave,
    SugarHigh,
    SugarRush,
    TraumatizedByEvil,
    Metal,
    Prismatic,
    SlowMetabolism,
}