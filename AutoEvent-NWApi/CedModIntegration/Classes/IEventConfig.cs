// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         IEventConfig.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:47 PM
//    Created Date:     08/31/2023 6:47 PM
// -----------------------------------------

namespace AutoEvent.CedModIntegration.Classes;


public interface IEventConfig
{
    public bool IsEnabled { get; set; }
}