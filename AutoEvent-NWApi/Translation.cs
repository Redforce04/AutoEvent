using System.ComponentModel;

namespace AutoEvent
{
    public class Translation// : ITranslation
    {
        [Description("Zombie Infection Game Mode")]
        public static string ZombieName { get; set; } = "Zombie Infection";
        public static string ZombieDescription { get; set; } = "Zombie mode, the purpose of which is to infect all players.";
        public static string ZombieBeforeStart { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=#ABF000>There are <color=red>{time}</color> seconds left before the game starts.</color>";
        public static string ZombieCycle { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>Humans left: <color=green>{count}</color></color>\n<color=yellow>Event time <color=red>{time}</color></color>";
        public static string ZombieExtraTime { get; set; } = "Extra time: {extratime}\n<color=yellow>The <b><i>Last</i></b> person left!</color>\n<color=yellow>Event time <color=red>{time}</color></color>";
        public static string ZombieWin { get; set; } = "<color=red>Zombie Win!</color>\n<color=yellow>Event time <color=red>{time}</color></color>";
        public static string ZombieLose { get; set; } = "<color=yellow><color=#D71868><b><i>Humans</i></b></color> Win!</color>\n<color=yellow>Event time <color=red>{time}</color></color>";
        [Description("Atomic Escape Game Mode")]
        public static string EscapeName { get; set; } = "Atomic Escape";
        public static string EscapeDescription { get; set; } = "Escape from the facility behind SCP-173 at supersonic speed!";
        public static string EscapeBeforeStart { get; set; } = "{name}\nHave time to escape from the facility before it explodes!\n<color=red>Before the escape: {time} seconds</color>";
        public static string EscapeCycle { get; set; } = "{name}\nBefore the explosion: <color=red>{time}</color> seconds";
        public static string EscapeEnd { get; set; } = "{name}\n<color=red> SCP Win </color>";
        [Description("Simon's Prison Game Mode")]
        public static string JailName { get; set; } = "Simon's Prison";
        public static string JailDescription { get; set; } = "Jail mode from CS 1.6, in which you need to hold events [VERY HARD].";
        public static string JailBeforeStart { get; set; } = "<color=yellow><color=red><b><i>{name}</i></b></color>\n<i>Open the doors to the players by shooting the button</i>\nBefore the start: <color=red>{time}</color> seconds</color>";
        public static string JailCycle { get; set; } = "<size=20><color=red>{name}</color>\n<color=yellow>Prisoners: {dclasscount}</color> || <color=#14AAF5>Jailers: {mtfcount}</color>\n<color=red>{time}</color></size>";
        public static string JailPrisonersWin { get; set; } = "<color=red><b><i>Prisoners Win</i></b></color>\n<color=red>{time}</color>";
        public static string JailJailersWin { get; set; } = "<color=#14AAF5><b><i>Jailers Win</i></b></color>\n<color=red>{time}</color>";
        [Description("Cock Fights Game Mode")]
        public static string VersusName { get; set; } = "Cock Fights";
        public static string VersusDescription { get; set; } = "Duel of players on the 35hp map from cs 1.6";
        public static string VersusPlayersNull { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\nGo inside the arena to fight each other!\n<color=red>{remain}</color> seconds left";
        public static string VersusClassDNull { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\nThe player left alive <color=yellow>{scientist}</color>\nGo inside in <color=orange>{remain}</color> seconds";
        public static string VersusScientistNull { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\nThe player left alive <color=orange>{classd}</color>\nGo inside in <color=yellow>{remain}</color> seconds";
        public static string VersusPlayersDuel { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow><color=yellow>{scientist}</color> <color=red>VS</color> <color=orange>{classd}</color></color>";
        public static string VersusClassDWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=red>CLASS D</color></color>";
        public static string VersusScientistWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=red>SCIENTISTS</color></color>";
        [Description("Knives of Death Game Mode")]
        public static string KnivesName { get; set; } = "Knives of Death";
        public static string KnivesDescription { get; set; } = "Knife players against each other on a 35hp map from cs 1.6";
        public static string KnivesCycle { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow><color=blue>{mtfcount} MTF</color> <color=red>VS</color> <color=green>{chaoscount} CHAOS</color></color>";
        public static string KnivesChaosWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=green>CHAOS</color></color>";
        public static string KnivesMtfWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=#42AAFF>MTF</color></color>";
        [Description("Deathmatch Game Mode")]
        public static string DeathmatchName { get; set; } = "Territory of Death";
        public static string DeathmatchDescription { get; set; } = "Cool Deathmatch on the Shipment map from MW19";
        public static string DeathmatchCycle { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<b><color=yellow><color=#42AAFF> {mtftext}> </color> <color=red>|</color> <color=green> <{chaostext}</color></color></b>";
        public static string DeathmatchChaosWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=green>CHAOS</color></color>";
        public static string DeathmatchMtfWin { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>WINNERS: <color=#42AAFF>MTF</color></color>";
        [Description("GunGame Game Mode")]
        public static string GunGameName { get; set; } = "Quick Hands";
        public static string GunGameDescription { get; set; } = "Cool GunGame on the Shipment map from MW19.";
        public static string GunGameCycle { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<b><color=yellow><color=#D71868>{level}</color> LVL <color=#D71868>||</color> Need <color=#D71868>{kills}</color> kills</color>\n<color=#D71868>Leader: <color=yellow>{leadnick}</color> LVL <color=yellow>{leadlevel}</color></color></b>";
        public static string GunGameWinner { get; set; } = "<color=#D71868><b><i>{name}</i></b></color>\n<color=yellow>The Winner of the game: <color=green>{winner}</color></color>";

        [Description("Battle Game Mode")] 
        public static string BattleName { get; set; } = "Battle";
        public static string BattleDescription { get; set; } = "MTF fight against CI";
        public static string BattleTimeLeft { get; set; } = "<size=100><color=red>Starts in {time} </color></size>";
        public static string BattleCiWin { get; set; } = "<color=#299438>Winner: Chaos Insurgency </color>\n<color=red>Event time: {time} </color>";
        public static string BattleMtfWin { get; set; } = "<color=#14AAF5>Winner: Foundation forces</color>\n<color=red>Event time: {time} </color>";
        public static string BattleCounter { get; set; } = "<color=#14AAF5> MTF: {FoundationForces} </color> vs <color=#299438> CI: {ChaosForces} </color> \n Elapsed time: {time}";

        [Description("Football Game Mode")] 
        public static string FootballName { get; set; } = "Football";
        public static string FootballDescription { get; set; } = "Score 3 goals to win";
        public static string FootballRedTeam { get; set; } = "<color=red>You play as Red Team\n</color>";
        public static string FootballBlueTeam { get; set; } = "<color=#14AAF5>You play as Blue Team\n</color>";
        public static string FootballTimeLeft { get; set; } = "<color=#14AAF5>{BluePnt}</color> : <color=red>{RedPnt}</color>\nTime left: {eventTime}";
        public static string FootballRedWins { get; set; } = "<color=red>Red Team Wins</color>";
        public static string FootballBlueWins { get; set; } = "<color=#14AAF5>Blue Team Wins</color>";
        public static string FootballDraw { get; set; } = "Draw\n<color=#14AAF5>{BluePnt}</color> vs <color=red>{RedPnt}</color>";

        [Description("Dead Jump Game Mode (Glass)")]
        public static string GlassName { get; set; } = "Dead Jump";
        public static string GlassDescription { get; set; } = "Jump on fragile platforms";
        public static string GlassStart { get; set; } = "<size=50>Dead Jump\nJump on fragile platforms</size>\n<size=20>Alive players: {plyAlive} \nTime left: {eventTime}</size>";
        public static string GlassDied { get; set; } = "You fallen into lava";
        public static string GlassWinSurvived { get; set; } = "<color=yellow>Human wins! Survived {countAlive} players</color>";

        public static string GlassWinner { get; set; } = "<color=red>Dead Jump</color>\n<color=yellow>Winner: {winner}</color>";
        public static string GlassFail { get; set; } = "<color=red>Dead Jump</color>\n<color=yellow>All players died</color>";

        [Description("Puzzle Game Mode")] 
        public static string PuzzleName { get; set; } = "Puzzle";
        public static string PuzzleDescription { get; set; } = "Get up the fastest on the right color.";
        public static string PuzzleStart { get; set; } = "<color=red>Starts in: </color>%time%";
        public static string PuzzleStage { get; set; } = "<color=red>Stage: </color>%stageNum%<color=red> / </color>%stageFinal%\n<color=yellow>Remaining players:</color> %plyCount%";
        public static string PuzzleAllDied { get; set; } = "<color=red>All players died</color>\nMini-game ended";
        public static string PuzzleSeveralSurvivors { get; set; } = "<color=red>Several people survived</color>\nMini-game ended";
        public static string PuzzleWinner { get; set; } = "<color=red>Winner: %plyWinner%</color>\nMini-game ended";
        public static string PuzzleDied { get; set; } = "<color=red>Burned in Lava</color>";

        [Description("Zombie Survival Game Mode (Zombie 2)")]
        public static string SurvivalName { get; set; } = "Zombie Survival";
        public static string SurvivalDescription { get; set; } = "Humans surviving from zombies";
        public static string SurvivalBeforeInfection { get; set; } = "<b>%name%</b>\n<color=yellow>There are </color> %time% <color=yellow>second before infection begins</color>";
        public static string SurvivalAfterInfection { get; set; } = "<b>%name%</b>\n<color=#14AAF5>Humans:</color> %humanCount%\n<color=#299438>Time to the end:</color> %time%";
        public static string SurvivalZombieWin { get; set; } = "<color=red>Zombie infected all humans and wins!</color>";
        public static string SurvivalHumanWin { get; set; } = "<color=#14AAF5>Humans killed all zombies and stopped infection</color>";
        public static string SurvivalHumanWinTime { get; set; } = "<color=yellow>Humans survived, but infection is not stopped</color>";

        [Description("Fall Down Game Mode")] 
        public static string FallName { get; set; } = "FallDown";
        public static string FallDescription { get; set; } = "All platforms are destroyed. It is necessary to survive";
        public static string FallBroadcast { get; set; } = "%name%\n%time%\n<color=yellow>Remaining: </color>%count%<color=yellow> players</color>";
        public static string FallWinner { get; set; } = "<color=red>Winner:</color> %winner%";
        public static string FallDied { get; set; } = "<color=red>All players died</color>";

        [Description("Death Line Game Mode")]
        public static string LineName { get; set; } = "DeathLine";
        public static string LineDescription { get; set; } = "Avoid the spinning platform to survive.";
        public static string LineCycle { get; set; } = "<color=#FF4242>%name%</color>\n<color=#14AAF5>Time to end: %min%</color><color=#4a4a4a>:</color><color=#14AAF5>%sec%</color>\n<color=yellow>Players: %count%</color>";
        public static string LineMorePlayers { get; set; } = "<color=#FF4242>%name%</color>\n<color=yellow>%count% players survived</color>\n<color=red>Congratulate!</color>";
        public static string LineWinner { get; set; } = "<color=#FF4242>%name%</color>\n<color=yellow>Winner: %winner%</color>\n<color=red>Congratulate!</color>";
        public static string LineAllDied { get; set; } = "<color=red>All players died</color>";

        [Description("Down Cubes Game Mode")]
        public static string CubeName { get; set; } = "Down Cubes";
        public static string CubeDescription { get; set; } = "Cubes down....";
        public static string CubeBroadcast { get; set; } = "%name%\n%time%\n<color=yellow>Remaining: </color>%count%<color=yellow> players</color>";
        public static string CubeWinner { get; set; } = "<color=red>Winner:</color> %winner%";
        public static string CubeAllDied { get; set; } = "<color=red>All players died</color>";
        public static string CubeDied { get; set; } = "You died...";

        [Description("Hide And Seek Game Mode")]
        public static string HideName { get; set; } = "Hide And Seek";
        public static string HideDescription { get; set; } = "We need to catch up with all the players on the map.";
        public static string HideBroadcast { get; set; } = "RUN\nSelection of new catching up players.\n%time%";
        public static string HideCycle { get; set; } = "Pass the bat to another player\n<color=yellow><b><i>%time%</i></b> seconds left</color>";
        public static string HideHurt { get; set; } = "You didn't have time to pass the bat.";
        public static string HideMorePlayer { get; set; } = "There are a lot of players left.\nWaiting for a reboot.\n<color=yellow>Event time <color=red>%time%</color></color>";
        public static string HideOnePlayer { get; set; } = "The player won %winner%\n<color=yellow>Event time <color=red>%time%</color></color>";
        public static string HideAllDie { get; set; } = "No one survived.\nEnd of the game\n<color=yellow>Event time <color=red>%time%</color></color>";

        [Description("Death Party Game Mode")]
        public static string DeathName { get; set; } = "Death Party";
        public static string DeathDescription { get; set; } = "Survive in grenade rain.";
        public static string DeathCycle { get; set; } = "<color=yellow>Dodge the grenades!</color>\n<color=green>%time% seconds passed</color>\n<color=red>%count% players left</color>";
        public static string DeathMorePlayer { get; set; } = "<color=red>Death Party</color>\n<color=yellow><color=red>%count%</color> players survived.</color>\n<color=#ffc0cb>%time%</color>";
        public static string DeathOnePlayer { get; set; } = "<color=red>Death Party</color>\n<color=yellow>Winner - <color=red>%winner%</color></color>\n<color=#ffc0cb>%time%</color>";
        public static string DeathAllDie { get; set; } = "<color=red>Death Party</color>\n<color=yellow>No one survived.(((</color>\n<color=#ffc0cb>%time%</color>";
        [Description("FinishWay Game Mode")]
        public static string FinishWayName { get; set; } = "Finish Way";
        public static string FinishWayDescription { get; set; } = "Go to the end of the finish to win.";
        public static string FinishWayCycle { get; set; } = "%name%\n<color=yellow>Pass the finish!</color>\nTime left: %time%";
        public static string FinishWayDied { get; set; } = "You didnt pass the finish";
        public static string FinishWaySeveralSurvivors { get; set; } = "<color=red>Human wins!</color>\nSurvived %count%";
        public static string FinishWayOneSurvived { get; set; } = "<color=red>Human wins!</color>\nWinner: %player%";
        public static string FinishWayNoSurvivors { get; set; } = "<color=red>No one human survived</color>";
        [Description("Zombie Escape Game Mode")]
        public static string ZombieEscapeName { get; set; } = "Zombie Escape";
        public static string ZombieEscapeDescription { get; set; } = "�ou need to run away from zombies and escape by helicopter.";
        public static string ZombieEscapeBeforeStart { get; set; } = "<color=#D71868><b><i>Run Forward</i></b></color>\nInfection starts in: %time%";
        public static string ZombieEscapeHelicopter { get; set; } = "<color=yellow>%name%</color>\n<color=red>Need to call helicopter.</color>\nHumans left: %count%";
        public static string ZombieEscapeDied { get; set; } = "Warhead detonated";
        public static string ZombieEscapeZombieWin { get; set; } = "<color=red>Zombies wins!</color>\nAll humans died";
        public static string ZombieEscapeHumanWin { get; set; } = "<color=#14AAF5>Humans wins!</color>\nHumans escaped";
        [Description("Lava Game Mode")]
        public static string LavaName { get; set; } = "The floor is LAVA";
        public static string LavaDescription { get; set; } = "Survival, in which you need to avoid lava and shoot at others.";
        public static string LavaBeforeStart { get; set; } = "<size=100><color=red>%time%</color></size>\nTake weapons and climb up.";
        public static string LavaCycle { get; set; } = "<size=20><color=red><b>Alive: %count% players</b></color></size>";
        public static string LavaWin { get; set; } = "<color=red><b>Winner\nPlayer - %winner%</b></color>";
        public static string LavaAllDead { get; set; } = "<color=red><b>No one survived to the end.</b></color>";
        [Description("Boss Battle Game Mode")]
        public static string BossName { get; set; } = "Boss Battle";
        public static string BossDescription { get; set; } = "You need kill the Boss.";
        public static string BossTimeLeft { get; set; } = "<size=100><color=red>Starts in {time} </color></size>";
        public static string BossWin { get; set; } = "<color=red><b>Boss WIN</b></color>\n<color=yellow><color=#14AAF5>Humans</color> has been destroyed</color>\n<b><color=red>%hp%</color> Hp</b> left";
        public static string BossHumansWin { get; set; } = "<color=#14AAF5>Humans WIN</color>\n<color=yellow><color=red>Boss</color> has been destroyed</color>\n<color=#14AAF5>%count%</color> players left";
        public static string BossCounter { get; set; } = "<color=red><b>%hp% HP</b></color>\n<color=#14AAF5>%count%</color> players left\n<color=green>%time%</color> seconds left";
    }
}