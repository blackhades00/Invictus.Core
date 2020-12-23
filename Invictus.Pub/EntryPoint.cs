// <copyright file="EntryPoint.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Callbacks;
using InvictusSharp.Framework;
using InvictusSharp.Framework.API;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.Features;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;

namespace InvictusSharp
{
    public class EntryPoint
    {
        internal static Overlay Overlay = new Overlay();

        public static string Riot = string.Empty;

        public static void LoadCore()
        {
            // AntiDebugService.StartAntiDbgService();
            if (!Riot.Equals("Wv*'B-H~00Xr{x_IYfIaXv4;PD{!~%_v-(M.UKgYcbKf&O8vT8kT_IG<ELoRt6"))
            {
                Environment.Exit(1);
                return;
            }
            DebugConsole.AllocConsole();
            Application.EnableVisualStyles();
            WaitForGame(); // Waits for game instance
        }

        public static bool init = false;
        public static bool waiting = true;
        public static async void WaitForGame()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (Utils.IsGameInForeground() && !init) //if not initiated and game is in forground
                    {
                        Offsets.TargetProcess = Process.GetProcessesByName("League of Legends");
                        if (Offsets.GetBase() != 0)
                        {
                            Offsets.Base = Offsets.GetBase();
                            Offsets.ProcessHandle = Offsets.GetLeagueHandle();
                            if (Engine.GetLocalObject() != 0) //If I am Ingame and LocalPlayer exists
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Game found!");
                                init = true;
                                waiting = true;
                                InitialiseCore();
                            }
                        }

                    }
                    else if (Engine.GetLocalObject() == 0) // if game is not NOT in forground and localObject doesnt exist, init is false.
                    {
                        init = false;
                        if (waiting)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Waiting for Game...");
                        }
                        
                        waiting = false;
                    }
                }
            });
        }

        internal static async void InitialiseCore()
        {
            try
            {
                HeroManager heroManager = new HeroManager();
                MinionManager minionManager = new MinionManager();

                GameObject.Me = Engine.GetLocalObject();

                HeroManager.enemyList.Clear();
                heroManager.PushHeroList();

                MinionManager.InhibList.Clear();
                MinionManager.TurretList.Clear();
                minionManager.PushStructureLists();

                GetChampionModule.LoadChampionModule();
                await Task.Run(() => MainThread.MainLoop());

                if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetSpellInfo().GetSpellName()
                    .Contains("Smite") || Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetSpellInfo().GetSpellName()
                    .Contains("Smite"))
                {
                    await Task.Run(() => AutoSmite.Load());
                }

                if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetSpellInfo().GetSpellName()
                    .Contains("SummonerDot") || Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetSpellInfo().GetSpellName()
                    .Contains("SummonerDot"))
                {
                    await Task.Run(() => AutoIgnite.Load());
                }
                await Task.Run(() => Overlay.Show());
            }
            catch (Exception)
            {
                Logger.Log("Error while initializing.", Logger.eLoggerType.Fatal);
                throw new Exception("InitException");
            }
        }

    }
}