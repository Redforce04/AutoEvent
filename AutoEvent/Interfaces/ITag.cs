// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         ITag.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/29/2023 11:00 PM
//    Created Date:     10/29/2023 11:00 PM
// -----------------------------------------

using System.Collections.Generic;

namespace AutoEvent.Interfaces;

public interface ITag
{
    public List<Tag> Tags { get; set; }
}