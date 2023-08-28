// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         YamlEvent.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/28/2023 4:00 PM
//    Created Date:     08/28/2023 4:00 PM
// -----------------------------------------

using AutoEvent.Interfaces;
using JetBrains.Annotations;

namespace AutoEvent.YamlEvents.Interfaces;

public class YamlEvent : Event
{
    public override string Name { get; set; }
    public override string Description { get; set; }
    public override string Author { get; set; }
    public override string MapName { get; set; }
    public string Music { get; set; } = "";
    public override string CommandName { get; set; }
    public Minigame Minigame { get; set; }
    public bool IsActive() => AutoEvent.ActiveEvent.Name == Name;
    public override void OnStart()
    {
        if (Music != "")
        {
            Extensions.PlayAudio(Music, 10, false, Name);
        }
        
        base.OnStart();
    }
    
    public override void OnStop()
    {
        base.OnStop();
    }

    public static YamlEvent GetYamlEventFromMinigame(Minigame @event)
    {
        return new YamlEvent()
        {
            Name = @event.Name,
            Author = @event.Author,
            Description = @event.Description,
            CommandName = @event.Name,
            Music = @event.MusicName,
            Minigame = @event
        };
    }
    
}