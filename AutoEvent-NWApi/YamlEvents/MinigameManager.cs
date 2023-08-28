using System;
using System.Collections.Generic;
using AutoEvent.YamlEvents.Interfaces;
using RemoteAdmin;

namespace AutoEvent.YamlEvents
{
    public class MinigameManager
    {
        
        /// <summary>
        /// Handles events for YamlEvents, and executes the proper set of commands for the MiniGame.
        /// </summary>
        /// <param name="eventType">The type of event being fired. (Player Hurt, etc...)</param>
        /// <param name="args">The valid set of replaceable arguments for the event.</param>
        /// <returns></returns>
        public static bool HandleEvent(string eventType, Tuple<String, String>[] args)
        {
            if (AutoEvent.ActiveEvent is YamlEvent yamlEvent)
            {
            
                if (yamlEvent.Minigame.Events.ContainsKey(eventType))
                {
                    foreach (var command in yamlEvent.Minigame.Events[eventType].Commands)
                    {
                        string processedCommand = PreProcessCommand(command, args);
                        var assm = typeof(CommandProcessor).Assembly;
                        assm.GetType("CommandProcessor").GetMethod("ProcessQuery")
                            .Invoke(null, new[] { processedCommand, null });
                    }

                    return true;
                }
            }

            return false;
        }

        private static string PreProcessCommand(string command, Tuple<String, String>[] args)
        {
            string processedCommand = command.Clone().ToString();
            foreach (var argument in args)
            {
                processedCommand.Replace("{{" + argument.Item1 + "}}", argument.Item2);
            }

            return processedCommand;
        }
    }
}