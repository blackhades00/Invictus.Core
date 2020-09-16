// <copyright file="EntryPoint.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invictus.Core.Invictus.Framework.API;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Hacks.TargetSelector;
using Invictus.Core.Invictus.LogService;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Core.Invictus.ThreadService;

namespace Invictus.Core
{
    public class EntryPoint
    {
        internal static Overlay Overlay = new Overlay();

        public static string Riot = string.Empty;

        public static void LoadCore()
        {
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
            //  DebugConsole.AllocConsole();
            await Task.Run(() =>{
            });
            await Task.Run(() => ActivePlayerData.ParseUnitRadiusData());
            // await Task.Run(() => Service.ParseSpellDBData());
            await Task.Run(() => Engine.SetBoundingRadius());

            await Task.Run(() => HeroManager.PushHeroList());

            await Task.Run(() => ThreadService.LoadMainThread());
            await Task.Run(() => Overlay.Show());
        }
    }
}
