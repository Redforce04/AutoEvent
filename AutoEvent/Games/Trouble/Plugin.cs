﻿using System;
using AutoEvent.Events.Handlers;
using PluginAPI.Events;
using System.Linq;
using AutoEvent.Interfaces;
using UnityEngine;
using Event = AutoEvent.Interfaces.Event;
using Player = PluginAPI.Core.Player;
using System;
using System.Collections.Generic;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.PlayableScps.Scp3114;
using PlayerRoles.Ragdolls;

namespace AutoEvent.Games.Trouble
{
    public class Plugin : Event, IEventSound, IEventMap, IInternalEvent, ITag
    {
        public List<Tag> Tags { get; set; } = new List<Tag>()
        {
            new Tag("Halloween", TagColor.purple)
        };
        public override string Name { get; set; } = "Trouble in Terrorist Town";
        public override string Description { get; set; } = "An impostor appeared in terrorist town.";
        public override string Author { get; set; } = "KoT0XleB";
        public override string CommandName { get; set; } = "trouble";
        public override Version Version { get; set; } = new Version(1, 0, 1);
        public MapInfo MapInfo { get; set; } = new MapInfo()
        { MapName = "AmongUs", Position = new Vector3(115.5f, 1030f, -43.5f), MapRotation = Quaternion.identity };
        public SoundInfo SoundInfo { get; set; } = new SoundInfo()
        { SoundName = "Skeleton.ogg", Volume = 5, Loop = true };
        protected override float PostRoundDelay { get; set; } = 10f;
        private EventHandler EventHandler { get; set; }
        private TroubleTranslate Translation { get; set; } = AutoEvent.Singleton.Translation.TroubleTranslate;

        protected override void RegisterEvents()
        {
            EventHandler = new EventHandler(this);
            EventManager.RegisterEvents(EventHandler);

            Servers.TeamRespawn += EventHandler.OnTeamRespawn;
            Servers.SpawnRagdoll += EventHandler.OnSpawnRagdoll;
            Servers.PlaceBullet += EventHandler.OnPlaceBullet;
            Servers.PlaceBlood += EventHandler.OnPlaceBlood;
            Players.DropItem += EventHandler.OnDropItem;
            Players.DropAmmo += EventHandler.OnDropAmmo;
            Players.PlayerDamage += EventHandler.OnPlayerDamage;
        }

        protected override void UnregisterEvents()
        {
            EventManager.UnregisterEvents(EventHandler);

            Servers.TeamRespawn -= EventHandler.OnTeamRespawn;
            Servers.SpawnRagdoll -= EventHandler.OnSpawnRagdoll;
            Servers.PlaceBullet -= EventHandler.OnPlaceBullet;
            Servers.PlaceBlood -= EventHandler.OnPlaceBlood;
            Players.DropItem -= EventHandler.OnDropItem;
            Players.DropAmmo -= EventHandler.OnDropAmmo;
            Players.PlayerDamage -= EventHandler.OnPlayerDamage;
            EventHandler = null;
        }

        protected override void OnStart()
        {
            foreach (Player player in Player.GetPlayers())
            {
                //player.GiveLoadout(Config.PlayerLoadouts);
                player.Position = RandomPosition.GetSpawnPosition(MapInfo.Map);
            }
        }

        protected override IEnumerator<float> BroadcastStartCountdown()
        {
            for (float time = 15; time > 0; time--)
            {
                Extensions.Broadcast($"<color=red>The trailer will appear in <color=yellow>{time}</color> seconds.</color>", 1);
                yield return Timing.WaitForSeconds(1f);
            }
        }

        protected override void CountdownFinished()
        {
            for (int i = 0; i < (Player.GetPlayers().Count / 10) + 1; i++)
            {
                Player traitor = Player.GetPlayers().RandomItem();
                Extensions.SetRole(traitor, PlayerRoles.RoleTypeId.Scp3114, PlayerRoles.RoleSpawnFlags.AssignInventory);
            }
            Player traitor = Player.GetPlayers().RandomItem();
            Extensions.SetRole(traitor, PlayerRoles.RoleTypeId.Scp3114, PlayerRoles.RoleSpawnFlags.AssignInventory);
            //if (traitor.RoleBase is PlayerRoles.PlayableScps.Scp3114.Scp3114Role scpRole)
            //    scpRole._identity;
        }

        protected override bool IsRoundDone()
        {
            if (Player.GetPlayers().Count(r => r.IsHuman) >= Player.GetPlayers().Count(r => r.IsSCP) 
                && EventTime.TotalMinutes < 3) return false;
            else return true;
        }

        protected override void ProcessFrame()
        {
            Extensions.Broadcast($"<color=red>{Name}\n" +
                $"{Player.GetPlayers().Count(r => r.IsSCP)} traitors | " +
                $"<color=#00FFFF>{Player.GetPlayers().Count(r => r.IsHuman)} guys</color></color>", 1);
        }

        protected override void OnFinished()
        {
            var time = $"{EventTime.Minutes:00}:{EventTime.Seconds:00}";
            if (Player.GetPlayers().Count(r => r.IsHuman) > Player.GetPlayers().Count(r => r.IsSCP))
            {
                Extensions.Broadcast($"<color=yellow><color=#D71868><b><i>Humans</i></b></color> Win!</color>\n" +
                    $"<color=yellow>Elapsed Duration: <color=red>{time}</color></color>", 10);
            }
            else if (Player.GetPlayers().Count(r => r.IsHuman) < Player.GetPlayers().Count(r => r.IsSCP))
            {
                Extensions.Broadcast($"<color=red>Traitors Win!</color>\n<color=yellow>Elapsed Duration: <color=red>{time}</color></color>", 10);
            }
            else
            {
                Extensions.Broadcast($"<color=red>Draw!</color>\n<color=yellow>Elapsed Duration: <color=red>{time}</color></color>", 10);
            }
        }
    }
}