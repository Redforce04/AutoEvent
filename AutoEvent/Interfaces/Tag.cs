// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         Tag.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/29/2023 11:00 PM
//    Created Date:     10/29/2023 11:00 PM
// -----------------------------------------

namespace AutoEvent.Interfaces;

public struct Tag
{
    public Tag(string name, TagColor color)
    {
        Name = name;
        Color = color;
    }
    public string Name { get; set; }
    public TagColor Color { get; set; }
}

public enum TagColor
{
    purple,
    green,
    aqua
}