// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         YamlEventLoader.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/28/2023 3:51 PM
//    Created Date:     08/28/2023 3:51 PM
// -----------------------------------------

using System.IO;
using AutoEvent.Interfaces;
using AutoEvent.YamlEvents.Interfaces;
using JetBrains.Annotations;
using PluginAPI.Core;
using PluginAPI.Helpers;

namespace AutoEvent.YamlEvents;

/// <summary>
/// The class that loads yaml events.
/// </summary>
public class YamlEventLoader
{
    /// <summary>
    /// The singleton instance of the yaml event loader class.
    /// </summary>
    public static YamlEventLoader Singleton;

    /// <summary>
    /// Constructs an instance of the yaml event loader class. Should only be called once.
    /// </summary>
    public YamlEventLoader()
    {
        Singleton = this;
    }

    /// <summary>
    /// Loads and registers yaml events.
    /// </summary>
    public void LoadYamlEvents()
    {
        foreach (string yamlEventPath in Directory.GetFiles(Path.Combine(Paths.GlobalPlugins.Plugins, "Events"), "*.yml"))
        {
            string yaml = File.ReadAllText(yamlEventPath);
            if (IsValidYamlEvent(yaml))
            {
                continue;
            }

            Minigame? miniGame = GetMinigame(yaml);
            if (miniGame is null)
            {
                continue;
            }
            
            Event @event = YamlEvent.GetYamlEventFromMinigame(miniGame);
            Log.Info($"[SimpleEvents] Loaded SimpleEvent {@event.Name} by {@event.Author}.");
            Event.Events.Add(@event);
        }
    }

    /// <summary>
    /// Determines if a yaml event is a valid event.
    /// </summary>
    /// <param name="yml">The yaml data.</param>
    /// <returns>True if yaml is valid.</returns>
    private bool IsValidYamlEvent(string yml)
    {
        return false;
    }

    
    /// <summary>
    /// Deserializes yaml into a minigame event.
    /// </summary>
    /// <param name="yaml">The yaml data.</param>
    /// <returns><seealso cref="Minigame"/> if valid yaml. Null if yaml is valid.</returns>
    [CanBeNull]
    private Minigame GetMinigame(string yaml)
    {
        return null;
    }
}

