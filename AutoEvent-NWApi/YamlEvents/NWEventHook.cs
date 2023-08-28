// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         NWEventHook.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/28/2023 4:56 PM
//    Created Date:     08/28/2023 4:56 PM
// -----------------------------------------

using System;
using AdminToys;
using CommandSystem;
using CustomPlayerEffects;
using Footprinting;
using Interactables.Interobjects;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.Radio;
using InventorySystem.Items.Usables;
using LiteNetLib;
using MapGeneration.Distributors;
using PlayerRoles;
using PlayerRoles.Voice;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using UnityEngine;

namespace AutoEvent.YamlEvents;

public class NWEventHook
{
	// Exiled Events
	/*
	void OnPlayerJoin()
	{
		MinigameManager.HandleEvent("PlayerJoined", new[] { new Tuple<string, string>("player", player.UserId) });

	}
	
	void OnPlayerLeave()
	{
		MinigameManager.HandleEvent("PlayerLeft", new[] { new Tuple<string, string>("player", player.UserId) });

	}

	void OnPlayerDying()
	{
		if (attacker == null)
		{
			MinigameManager.HandleEvent("PlayerDying",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
		else
		{
			MinigameManager.HandleEvent("PlayerDying",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("attacker", attacker.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
	}
	

	void OnPlayerDied()
	{
		if (attacker == null)
		{
			MinigameManager.HandleEvent("PlayerDeath",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
		else
		{
			MinigameManager.HandleEvent("PlayerDeath",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("attacker", attacker.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
	}*/

	[PluginEvent(ServerEventType.PlayerJoined)]
	void OnPlayerJoin(Player player)
	{
		MinigameManager.HandleEvent("PlayerJoined", new[] { new Tuple<string, string>("player", player.UserId) });
	}

	[PluginEvent(ServerEventType.PlayerLeft)]
	void OnPlayerLeave(Player player)
	{
		MinigameManager.HandleEvent("PlayerLeft", new[] { new Tuple<string, string>("player", player.UserId) });
	}

	[PluginEvent(ServerEventType.PlayerDying)]
	bool OnPlayerDying(Player player, Player attacker, DamageHandlerBase damageHandler)
	{
		if (attacker == null)
		{
			MinigameManager.HandleEvent("PlayerDying",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
		else
		{
			MinigameManager.HandleEvent("PlayerDying",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("attacker", attacker.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}

		return true;
	}

	[PluginEvent(ServerEventType.PlayerDeath)]
	void OnPlayerDied(Player player, Player attacker, DamageHandlerBase damageHandler)
	{
		if (attacker == null)
		{
			MinigameManager.HandleEvent("PlayerDeath",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
		else
		{
			MinigameManager.HandleEvent("PlayerDeath",
				new[]
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("attacker", attacker.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
		}
	}
}