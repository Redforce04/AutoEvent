/*using Footprinting;
using Interactables.Interobjects;
using PlayerRoles.Voice;
using UnityEngine;

namespace Dionysus
{
    using CommandSystem;
    using AdminToys;
    using CustomPlayerEffects;
    using InventorySystem.Items;
    using InventorySystem.Items.Firearms;
    using InventorySystem.Items.Radio;
    using InventorySystem.Items.Usables;
    using LiteNetLib;
    using MapGeneration.Distributors;
    using PlayerRoles;
    using PlayerStatsSystem;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PluginAPI.Events;
    using System;
    using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;
    
    public class Dionysus
    {
        public static Dionysus Singleton { get; set; }
        public static MinigameManager Manager { get; set; }

        [PluginPriority(LoadPriority.High)]
        [PluginEntryPoint("Dionysus", "1.0.0", "Event Maker", "zombie")]
        void LoadPlugin()
        {
            Singleton = this;
            Manager = MinigameManager.Instance;
            
            Log.Info("Loaded plugin, register events...");
            EventManager.RegisterEvents(this);
            Log.Info($"Registered events");

            var handler = PluginHandler.Get(this);
            
            Log.Info(handler.PluginName);
            Log.Info(handler.PluginFilePath);
            Log.Info(handler.PluginDirectoryPath);
            
            
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
		void OnPlayerJoin(Player player)
		{
			MinigameManager.Handle("PlayerJoined", new [] { new Tuple<string, string>("player", player.UserId)});
		}

		[PluginEvent(ServerEventType.PlayerLeft)]
		void OnPlayerLeave(Player player)
		{
			MinigameManager.Handle("PlayerLeft", new[] { new Tuple<string, string>("player", player.UserId) });
		}

		[PluginEvent(ServerEventType.PlayerDying)]
		bool OnPlayerDying(Player player, Player attacker, DamageHandlerBase damageHandler)
		{
			if (attacker == null)
			{
				MinigameManager.Handle("PlayerDying",
					new[]
					{
						new Tuple<string, string>("player", player.UserId),
						new Tuple<string, string>("reason", damageHandler.ToString())
					});
			}
			else
			{
				MinigameManager.Handle("PlayerDying",
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
				MinigameManager.Handle("PlayerDeath",
					new []
				{
					new Tuple<string, string>("player", player.UserId),
					new Tuple<string, string>("reason", damageHandler.ToString())
				});
			}
			else
			{
				MinigameManager.Handle("PlayerDeath",
					new []
					{
						new Tuple<string, string>("player", player.UserId),
						new Tuple<string, string>("attacker", attacker.UserId),
						new Tuple<string, string>("reason", damageHandler.ToString())
					});
			}
		}

		[PluginEvent(ServerEventType.LczDecontaminationStart)]
		void OnLczDecontaminationStarts()
		{
			Log.Info("Started LCZ decontamination.");
		}

		[PluginEvent(ServerEventType.LczDecontaminationAnnouncement)]
		void OnAnnounceLczDecontamination(int id)
		{
			Log.Info($"LCZ Annoucement &6{id}&r.");
		}

		[PluginEvent(ServerEventType.MapGenerated)]
		void OnMapGenerated()
		{
			Log.Info("Map generated.");
		}

		[PluginEvent(ServerEventType.GrenadeExploded)]
		void OnGrenadeExploded(Footprint owner, Vector3 position, ItemPickupBase item)
		{
			Log.Info($"Grenade &6{item.NetworkInfo.ItemId}&r thrown by &6{item.PreviousOwner.Nickname}&r exploded at &6{item.NetworkInfo.RelativePosition.ToString()}&r");
		}

		[PluginEvent(ServerEventType.ItemSpawned)]
		void OnItemSpawned(ItemType item, Vector3 position)
		{
			Log.Info($"Item &6{item}&r spawned on map");
		}

		[PluginEvent(ServerEventType.GeneratorActivated)]
		void OnGeneratorActivated(Scp079Generator gen)
		{
			Log.Info("Generator activated");
		}

		[PluginEvent(ServerEventType.PlaceBlood)]
		void OnPlaceBlood(Player player, Vector3 position)
		{
			Log.Info($"Player &6{player.Nickname}&r blood placed on map position &6{position}&r");
		}

		[PluginEvent(ServerEventType.PlaceBulletHole)]
		void OnPlaceBulletHole(Vector3 position)
		{
			Log.Info($"Bullet hole has been placed on map. Position &6{position}&r.");
		}

		[PluginEvent(ServerEventType.PlayerActivateGenerator)]
		void OnPlayerActivateGenerator(Player plr, Scp079Generator gen)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) activated generator with remaining time &6{gen.RemainingTime}&r");
		}

		[PluginEvent(ServerEventType.PlayerAimWeapon)]
		void OnPlayerAimsWeapon(Player plr, Firearm gun, bool isAiming)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) is {(isAiming ? "aiming" : "not aiming")} gun &6{gun.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerBanned)]
		void OnPlayerBanned(Player plr, ICommandSender issuer, string reason, long duration)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) got banned by &6{issuer.LogName}&r with reason &6{reason}&r for duration &6{duration}&r seconds");
		}

		[PluginEvent(ServerEventType.PlayerCancelUsingItem)]
		void OnPlayerCancelsUsingItem(Player plr, UsableItem item)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) cancelled using item &6{item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerChangeItem)]
		void OnPlayerChangesItem(Player plr, ushort oldItem, ushort newItem)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) change current item &6{oldItem}&r to &6{newItem}&r");
		}

		[PluginEvent(ServerEventType.PlayerChangeRadioRange)]
		void OnPlayerChangesRadioRange(Player plr, RadioItem item, byte range)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed radio range to &6{range}&r");
		}

		[PluginEvent(ServerEventType.PlayerRadioToggle)]
		void OnPlayerRadioToggle(Player plr, RadioItem item, bool newState)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) toggled the radio state to &6{newState}&r");
		}

		[PluginEvent(ServerEventType.PlayerUsingRadio)]
		void OnPlayerUsingRadio(Player player, RadioItem radio, float drain)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) is using a radio and its draining &6{drain}&r of the battery");
		}

		[PluginEvent(ServerEventType.CassieAnnouncesScpTermination)]
		void OnCassieAnnouncScpTermination(Player scp, DamageHandlerBase damage, string announcement)
		{
			Log.Info($"Cassie announce a SCP termination of player &6{scp.Nickname}&r (&6{scp.UserId}&r), CASSIE announcement is &6{announcement}&r");
		}

		[PluginEvent(ServerEventType.PlayerGetGroup)]
		void OnPlayerChangeGroup(string userID, UserGroup group)
		{
			Log.Info($"User group of {userID} is &6{((group == null || group.BadgeText == null) ? "(null)" : group.BadgeText)}&r");
		}

		[PluginEvent(ServerEventType.PlayerUsingIntercom)]
		void OnPlayerUsingIntercom(Player player, IntercomState state)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) is using Intercom");
		}

		[PluginEvent(ServerEventType.PlayerChangeSpectator)]
		void OnPlayerChangesSpectatedPlayer(Player plr, Player oldTarget, Player newTarget)
		{
			if (oldTarget == null && newTarget != null)
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) is now spectating &6{newTarget.Nickname}&r (&6{newTarget.UserId}&r)");

			}
			else if (oldTarget != null && newTarget != null)
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed spectated player &6{oldTarget.Nickname}&r (&6{oldTarget.UserId}&r) &6{newTarget.Nickname}&r (&6{newTarget.UserId}&r)");
			}
		}

		[PluginEvent(ServerEventType.PlayerCloseGenerator)]
		void OnPlayerClosesGenerator(Player plr, Scp079Generator gen)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) closed generator");
		}

		[PluginEvent(ServerEventType.PlayerDamagedShootingTarget)]
		void OnPlayerDamagedShootingTarget(Player plr, ShootingTarget target, DamageHandlerBase dmgHandler, float amount)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) hit shooting target with damage amount &6{amount}&r");
		}

		[PluginEvent(ServerEventType.PlayerDamagedWindow)]
		void OnPlayerDamagedWindow(Player plr, BreakableWindow window, DamageHandlerBase dmgHandler, float amount)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) damaged window with damage amount &6{amount}&r");
		}

		[PluginEvent(ServerEventType.PlayerDeactivatedGenerator)]
		void OnPlayerDeactivatedGenerator(Player plr, Scp079Generator gen)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) deactivated a generator.");
		}

		[PluginEvent(ServerEventType.PlayerDropAmmo)]
		void OnPlayerDroppedAmmo(Player plr, ItemType ammoType, int amount)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dropped &6{amount}&r ammo of type &6{ammoType}&r.");
		}

		[PluginEvent(ServerEventType.PlayerDropItem)]
		void OnPlayerDroppedItem(Player plr, ItemBase item)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dropped item &6{item.ItemTypeId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerDryfireWeapon)]
		void OnPlayerDryfireWeapon(Player plr, Firearm item)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dryfired weapon &6{item.ItemTypeId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerEscape)]
		void OnPlayerEscaped(Player plr, RoleTypeId role)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) escaped as &6{plr.Role}&r and new role is &6{role}&r.");
		}

		[PluginEvent(ServerEventType.PlayerHandcuff)]
		void OnPlayerHandcuffed(Player plr, Player target)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) handcuffed &6{target.Nickname}&r (&6{target.UserId}&r).");
		}

		[PluginEvent(ServerEventType.PlayerRemoveHandcuffs)]
		void OnPlayerUncuffed(Player plr, Player target)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) uncuffed &6{target.Nickname}&r (&6{target.UserId}&r).");
		}

		[PluginEvent(ServerEventType.PlayerDamage)]
		void OnPlayerDamage(Player player, Player attacker, DamageHandlerBase damageHandler)
		{
			if (attacker == null)
				Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) got damaged, cause {damageHandler}.");
			else
				Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) received damage from &6{attacker.Nickname}&r (&6{attacker.UserId}&r), cause {damageHandler}.");
		}

		[PluginEvent(ServerEventType.PlayerKicked)]
		void OnPlayerKicked(Player plr, ICommandSender issuer, string reason)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) kicked from server by &6{issuer.LogName}&r with reason &6{reason}&r.");
		}

		[PluginEvent(ServerEventType.PlayerOpenGenerator)]
		void OnPlayerOpenedGenerator(Player plr, Scp079Generator gen)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) opened generator.");
		}


		[PluginEvent(ServerEventType.PlayerPickupAmmo)]
		void OnPlayerPickupAmmo(Player plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup ammo {pickup.Info.ItemId}.");
		}

		[PluginEvent(ServerEventType.PlayerPickupArmor)]
		void OnPlayerPickupArmor(Player plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup armor {pickup.Info.ItemId}.");
		}

		[PluginEvent(ServerEventType.PlayerPickupScp330)]
		void OnPlayerPickupScp330(Player plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup scp330 {pickup.Info.ItemId}.");
		}

		[PluginEvent(ServerEventType.PlayerPreauth)]
		void OnPreauth(string userid, string ipAddress, long expiration, CentralAuthPreauthFlags flags, string country, byte[] signature, ConnectionRequest req, Int32 index)
		{
			Log.Info($"Player &6{userid}&r (&6{ipAddress}&r) preauthenticated from country &6{country}&r with central flags &6{flags}&r");
		}

		[PluginEvent(ServerEventType.PlayerReceiveEffect)]
		void OnReceiveEffect(Player plr, StatusEffectBase effect, byte intensity, float duration)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) received effect &6{effect}&r with an intensity of &6{intensity}&r.");
		}

		[PluginEvent(ServerEventType.PlayerReloadWeapon)]
		void OnReloadWeapon(Player plr, Firearm gun)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reloaded weapon &6{gun.ItemTypeId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerChangeRole)]
		void OnChangeRole(Player plr, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
		{
			if (oldRole == null)
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed role to &6{newRole}&r with reason &6{reason}&r");
			}
			else
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed role from &6{oldRole.RoleName}&r to &6{newRole}&r with reason &6{reason}&r");
			}
		}

		[PluginEvent(ServerEventType.PlayerSearchPickup)]
		void OnSearchPickup(Player plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) started searching pickup &6{pickup.NetworkInfo.ItemId}&r");
		}

		[PluginEvent(ServerEventType.PlayerSearchedPickup)]
		void OnSearchedPickup(Player plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) searched pickup &6{pickup.NetworkInfo.ItemId}&r");
		}


		[PluginEvent(ServerEventType.PlayerShotWeapon)]
		void OnShotWeapon(Player plr, Firearm gun)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) shot &6{gun.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerSpawn)]
		void OnSpawn(Player plr, RoleTypeId role)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) spawned as &6{role}&r");
		}

		[PluginEvent(ServerEventType.PlayerThrowItem)]
		void OnThrowItem(Player plr, ItemBase item, Rigidbody rb)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) thrown item &6{item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerToggleFlashlight)]
		void OnToggleFlashlight(Player plr, ItemBase item, bool isToggled)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) toggled {(isToggled ? "on" : "off")} flashlight on &6{item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUnloadWeapon)]
		void OnUnloadWeapon(Player plr, Firearm gun)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) unloads &6{gun.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUnlockGenerator)]
		void OnUnlockGenerator(Player plr, Scp079Generator generator)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) unlocked generator");
		}

		[PluginEvent(ServerEventType.PlayerUsedItem)]
		void OnPlayerUsedItem(Player plr, ItemBase item)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) used item &6{item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUseHotkey)]
		void OnPlaeyrUsedHotkey(Player plr, ActionName action)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) used hotkey &6{action}&r");
		}

		[PluginEvent(ServerEventType.PlayerUseItem)]
		void OnPlayerStartedUsingItem(Player plr, UsableItem item)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) started using item &6{item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerCheaterReport)]
		void OnCheaterReport(Player plr, Player target, string reason)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reported player &6{target.Nickname}&r (&6{target.UserId}&r) for cheating with reason &6{reason}&r");
		}

		[PluginEvent(ServerEventType.PlayerReport)]
		void OnReport(Player plr, Player target, string reason)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reported player &6{target.Nickname}&r (&6{target.UserId}&r) for breaking server rules with reason &6{reason}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractShootingTarget)]
		void OnInteractWithShootingTarget(Player plr, ShootingTarget target)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with shooting target in the position {target.transform.position}");
		}

		[PluginEvent(ServerEventType.PlayerInteractLocker)]
		void OnInteractWithLocker(Player plr, Locker locker, LockerChamber chamber, bool canAccess)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) {(canAccess ? "interacted" : "failed to interact")} with locker and chamber is in the position {chamber.transform.position}.");
		}

		[PluginEvent(ServerEventType.PlayerInteractElevator)]
		void OnInteractWithElevator(Player plr, ElevatorChamber elevator)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with elevator in position &6{elevator.transform.position}&r with the destination in &6{elevator.CurrentDestination.transform.position}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractScp330)]
		void OnInteractWithScp330(Player plr)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with SCP330.");
		}

		[PluginEvent(ServerEventType.RagdollSpawn)]
		void OnRagdollSpawn(Player plr, IRagdollRole ragdoll, DamageHandlerBase damageHandler)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) spawned ragdoll &6{ragdoll.Ragdoll}&r, reason &6{damageHandler}&r");
		}

		[PluginEvent(ServerEventType.RoundEnd)]
		void OnRoundEnded(RoundSummary.LeadingTeam leadingTeam)
		{
			Log.Info($"Round ended. {leadingTeam.ToString()} won!");
		}

		[PluginEvent(ServerEventType.RoundRestart)]
		void OnRestart()
		{
			Log.Info($"Round restarting");
		}

		[PluginEvent(ServerEventType.RoundStart)]
		void OnRoundStart()
		{
			Log.Info($"Round started");
		}

		[PluginEvent(ServerEventType.WaitingForPlayers)]
		void WaitingForPlayers()
		{
			Log.Info($"Waiting for players...");
		}
    }
}*/