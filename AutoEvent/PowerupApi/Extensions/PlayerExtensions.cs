// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          PowerupApi
//    FileName:         PlayerExtensions.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/31/2023 2:09 PM
//    Created Date:     10/31/2023 2:09 PM
// -----------------------------------------

using System;
using System.Reflection;
using Discord;
using Mirror;
using PluginAPI.Core;
using UnityEngine;

namespace Powerups.Extensions;

public static class PlayerExtensions
{
    static PlayerExtensions()
    {
    }
    private static MethodInfo sendSpawnMessage;

    public static MethodInfo SendSpawnMessage => sendSpawnMessage ?? (sendSpawnMessage =
        typeof(NetworkServer).GetMethod("SendSpawnMessage", BindingFlags.Static | BindingFlags.NonPublic));
    public static void SetPlayerScale(this Player target, Vector3 scale)
    {
        if (target.GameObject.transform.localScale == scale) return;

        try
        {
            NetworkIdentity identity = target.ReferenceHub.networkIdentity;
            target.GameObject.transform.localScale = scale;
            foreach (Player player in Player.GetPlayers())
            {
                SendSpawnMessage?.Invoke(null, new object[2] { identity, player.Connection });
            }
        }
        catch (Exception ex)
        {
            Log.Warning($"Scale error has occured.");
            Log.Debug($"Exception: \n{ex}");

        }
    }

}