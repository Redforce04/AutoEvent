// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         Event.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:56 PM
//    Created Date:     08/31/2023 6:56 PM
// -----------------------------------------

using System;
using ReflectionTools;
using ReflectionTools.Attributes;

namespace AutoEvent.CedModIntegration.Classes;

[IsInterface(typeof(CMBaseEvent), nameof(GetEventType))]
[IsInterface(typeof(IEvent))]
public class CMBaseEvent : IEvent
{
    public CMBaseEvent()
    {
        
    }
    //[ReplaceTypeWithValue]
    
    [ArgUsesDifferentType(nameof(config), typeof(IEventConfig), typeof(CMBaseEvent), nameof(GetEventConfig))]
    [CallMethod(typeof(CMBaseEvent),nameof(ConstructorInitialize))]
    public CMBaseEvent(string name, string author, string description, string prefix, IEventConfig config)
    {
        
    }

    public static bool ConstructorInitialize(object __instance, string name, string author, string description, string prefix, object config)
    {
        var traverse = HarmonyLib.Traverse.Create(__instance);
        traverse.Property("EventName").SetValue(name);
        traverse.Property("EvenAuthor").SetValue(author);
        traverse.Property("EventDescription").SetValue(description);
        traverse.Property("EventPrefix").SetValue(prefix);
        traverse.Property("Config").SetValue(config);
        
            /*
             * var foo = Traverse.Create<Foo>().Method("MakeFoo").GetValue<Foo>();
             * Traverse.Create(foo).Property("MyBar").Field("secret").SetValue("world");
             * Console.WriteLine(foo.GetSecret()); // outputs WORLD
             */
            return false;
    }
    public static Type GetEventConfig()
    {
        Reflections.MakeCustomType<EventConfiguration>();
        return null;
    }
    public string EventName { get; }
    public string EvenAuthor { get; }
    public string EventDescription { get; set; }
    public string EventPrefix { get; }
    public IEventConfig Config { get; }
    [CallMethod(typeof(CMBaseEvent), nameof(PrepareEventExecutor)),]
    public void PrepareEvent()
    {
    }

    public static bool PrepareEventExecutor(object __instance)
    {
        IEvent ev = (IEvent)__instance;  
        Console.WriteLine($"{ev.EventName} is being executed.");
        return false;
    }

    [CallMethod(typeof(CMBaseEvent), nameof(StopEventExecutor)),]
    public void StopEvent()
    {
    }

    public static bool StopEventExecutor(object __instance)
    {
        IEvent ev = (IEvent)__instance;  
        Console.WriteLine($"{ev.EventName} is being stopped.");
        return false;
    }
    public static Type GetEventType()
    {
        if (!ReflectionTools.IsCedModInstalled)
            return typeof(IEvent);
        return ReflectionTools.GetIEventConfig;
    }
}