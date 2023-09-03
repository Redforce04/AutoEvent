// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         IEvent.cs
//    Author:           Redforce04#4091
//    Revision Date:    08/31/2023 6:56 PM
//    Created Date:     08/31/2023 6:56 PM
// -----------------------------------------

namespace AutoEvent.CedModIntegration.Classes;

public interface IEvent
{
    string EventName { get; }
    string EvenAuthor { get; }
    string EventDescription { get; set; }
    string EventPrefix { get; }
    IEventConfig Config { get; }

    void PrepareEvent();
    void StopEvent();
}
