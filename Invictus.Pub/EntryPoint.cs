// <copyright file="EntryPoint.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.API;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Hacks.TargetSelector;
using Invictus.Core.Invictus.LogService;
using Invictus.Core.Invictus.Modules.Champion_Modules;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Pub.Invictus.Framework.Security;

namespace Invictus.Core
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
            Application.SetCompatibleTextRenderingDefault(false);
            InitialiseCore(); // Init the core, start of main functions. Call this in Loader.
        }

        internal static async void InitialiseCore()
        {
            Logger.Log("Initiating InvictusSharp...", Logger.eLoggerType.Info);


            try
            {
                await Task.Run(() => ActivePlayerData.ParseUnitRadiusData());
                Engine.SetBoundingRadius();
                ActivePlayerData.ParseSpellDB();

                Offsets.Base = Offsets.GetBase();
                Offsets.ProcessHandle = Offsets.GetLeagueHandle();
                GameObject.Me = Engine.GetLocalObject();

                HeroManager.PushHeroList();
                await Task.Run(() => MainThread.MainLoop());
             //   GetChampionModule.LoadChampionModule();
                await Task.Run(() => Utils.ShowWelcomeMessage());
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