// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         IEventConfiguration.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:03 PM
//    Created Date:     08/31/2023 6:03 PM
// -----------------------------------------

using System;
using ReflectionTools.Attributes;

namespace AutoEvent.CedModIntegration.Classes;

[IsInterface(typeof(EventConfiguration), nameof(GetInterfaceType))]
[IsInterface(typeof(IEventConfig))]
public class EventConfiguration : IEventConfig
{
    [Virtual]
    public bool IsEnabled { get; set; }

    public static Type GetInterfaceType()
    {
        if (!ReflectionTools.IsCedModInstalled)
            return typeof(IEventConfig);
        return ReflectionTools.GetIEventConfig;
    }
}