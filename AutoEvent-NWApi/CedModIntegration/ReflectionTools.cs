// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         ReflectionTools.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:48 PM
//    Created Date:     08/31/2023 6:48 PM
// -----------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace AutoEvent.CedModIntegration;

public class ReflectionTools
{
    [CanBeNull] internal static Assembly GetCedModAssembly => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "CedModV3");
    [CanBeNull] internal static Type GetIEvent => GetCedModAssembly?.GetTypes().FirstOrDefault(x => x.Name == "IEvent");
    [CanBeNull] internal static Type GetIEventConfig => GetCedModAssembly?.GetTypes().FirstOrDefault(x => x.Name == "IEventConfig");
    [CanBeNull] internal static Type GetCedModEventManager => GetCedModAssembly?.GetTypes().FirstOrDefault(x => x.Name == "EventManager");
    [CanBeNull] internal static IList GetCedModEventsList => (IList)GetCedModEventManager?.GetField("AvailableEvents").GetValue(null);
    internal static bool IsCedModInstalled => AppDomain.CurrentDomain.GetAssemblies().Any(x => x.GetName().Name == "CedModV3");
}  