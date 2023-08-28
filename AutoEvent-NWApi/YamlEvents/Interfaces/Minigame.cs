using System;
using System.Collections.Generic;

namespace AutoEvent.YamlEvents.Interfaces
{
    public class Minigame
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string MapName { get; set; }
        public string MusicName { get; set; }
        public Dictionary<string, MinigameEvent> Events { get; set; }
    }
}