// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         CedModEvent.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 7:03 PM
//    Created Date:     08/31/2023 7:03 PM
// -----------------------------------------
using AutoEvent;
using AutoEvent.Interfaces;

namespace AutoEvent.CedModIntegration.Classes;

public class CedModEvent : Event
{
    public CedModEvent()
    {
        
    }
    public object CMEvent { get; set; }
    public override string Name { get; set; }
    public override string Description { get; set; }
    public override string Author { get; set; }
    public override string MapName { get; set; }
    public override string CommandName { get; set; }
}