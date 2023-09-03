// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         CedModEventLoader.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:03 PM
//    Created Date:     08/31/2023 6:03 PM
// -----------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using AutoEvent.CedModIntegration.Classes;
using AutoEvent.Interfaces;
using PluginAPI.Core;
using ReflectionTools;
using IEvent = AutoEvent.CedModIntegration.Classes.IEvent;

namespace AutoEvent.CedModIntegration;

public class CedModEventLoader
{
    public CedModEventLoader Singleton; 
    private const bool Debug = false;
    public CedModEventLoader()
    {
        if (Singleton is not null)
        {
            return;
        }
        Singleton = this;
        if (!ReflectionTools.IsCedModInstalled)
        {
            return;
        }
        _initTypes();
        _pullEvents();
        _pushEvents();
    }

    private void _initTypes()
    {
        if (Debug)
        {
            Log.Debug($"Is CedMod Installed: {ReflectionTools.IsCedModInstalled}");
            Log.Debug($"Is CM Assembly Null: {ReflectionTools.GetCedModAssembly is null}");
            Log.Debug($"Is CM Events List Null: {ReflectionTools.GetCedModEventsList is null}");
            Log.Debug($"Is CM IEvent Null: {ReflectionTools.GetIEvent is null}");
            Log.Debug($"Is CM EventConfig Null: {ReflectionTools.GetIEventConfig is null}");
            Log.Debug($"Is CM Event Manger Null: {ReflectionTools.GetCedModEventManager is null}");
            
        }
        
    } 

    private void _pullEvents()
    {
        if (ReflectionTools.GetCedModEventsList == null)
        {
            return;
        }
        
        foreach (object pulledEvent in ReflectionTools.GetCedModEventsList)
        {
            try
            {

                Type type = pulledEvent.GetType();
                CedModEvent cmBaseEvent = new CedModEvent();
                cmBaseEvent.Name = ((string)type.GetProperty("EventName")?.GetValue(pulledEvent))?.Replace(" ", "_");
                if (Event.Events.Any(x => x.Name == cmBaseEvent.Name))
                {
                    continue;
                }

                cmBaseEvent.CMEvent = pulledEvent;
                cmBaseEvent.Description = (string)type.GetProperty("EventDescription")?.GetValue(pulledEvent);
                cmBaseEvent.CommandName =
                    ((string)type.GetProperty("EventName")?.GetValue(pulledEvent))?.Replace(" ", "_");
                cmBaseEvent.Author = (string)type.GetProperty("EvenAuthor")?.GetValue(pulledEvent);
                Event.Events.Add(cmBaseEvent);
                Log.Info($"Registered CedMod Event {cmBaseEvent.Name} by {cmBaseEvent.Author}");
            }
            catch (Exception e)
            {
                Log.Warning($"Caught an exception while trying to register an event from CedMod.\n {e}");
            }
        }
    }

    private void _pushEvents()
    {
        int i = 0;
        foreach (Event @event in Event.Events)
        {
            try
            {

                if (@event is CedModEvent)
                {
                    if(Debug)
                        Log.Debug($"Skipping Event: {@event.Name} (CedMod Event - already registered).");
                    continue;
                }
                if(Debug)
                    Log.Debug($"Making event: {@event.Name}");
                Type cmPushEvent = Reflections.MakeCustomType<CMBaseEvent>();
                if (cmPushEvent == null)
                {
                    if(Debug)
                        Log.Debug($"An error has occured and event is null.");
                    continue;
                }

                //string name, string author, string description, string prefix, IEventConfig config
                var constructorInfo = cmPushEvent.GetConstructors().FirstOrDefault(x => x.GetParameters().Length > 1);
                var res = constructorInfo.Invoke(new object[]
                    { @event.Name, @event.Author, @event.Description, @event.Name, new EventConfiguration() });
                /*((IEvent)cmPushEvent).EventName = @event.Name;
                ((IEvent)cmPushEvent).EventPrefix = @event.Name;
                ((IEvent)cmPushEvent).EventDescription = @event.Description;
                ((IEvent)cmPushEvent).EvenAuthor = @event.Author;*/
                if (ReflectionTools.GetCedModEventsList is null)
                {
                    if(Debug)
                        Log.Debug($"Warning: Cedmod events list is null. Returning.");
                    return;
                }

                ReflectionTools.GetCedModEventsList.Add(res);
                i++;
            }
            catch (Exception e)
            {
                Log.Warning($"Caught an event while trying to register an event to CedMod. \n{e}");
            }
        }
        Log.Info($"Registered {i} events to CedMod");
        
    }
}