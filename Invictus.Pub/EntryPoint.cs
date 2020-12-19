// <copyright file="EntryPoint.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
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
            InitialiseCore(); // Init the core, start of main functions. Call this in Loader.
        }

        internal static async void InitialiseCore()
        {
            Logger.Log("Initiating Vault7...", Logger.eLoggerType.Info);


            try
            {
                HeroManager heroManager = new HeroManager();
                MinionManager minionManager = new MinionManager();

                Offsets.Base = Offsets.GetBase();
                Offsets.ProcessHandle = Offsets.GetLeagueHandle();
                GameObject.Me = Engine.GetLocalObject();
                heroManager.PushHeroList();

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

                Logger.Log("Welcome to the Vault", Logger.eLoggerType.Info);
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