// <copyright file="EntryPoint.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using global::Invictus.Pub.Invictus.LogService;
    using global::Invictus.Pub.Invictus.ThreadService;
    using Paradox.Core.Drawing;

    public class EntryPoint
    {
        internal static Overlay overlay = new Overlay();

        public static void LoadCore()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitialiseCore(); // Init the core, start of main functions. Call this in Loader.
        }

        internal static async void InitialiseCore()
        {
            await Task.Run(() => DebugConsole.AllocConsole());

            await Task.Run(() => Console.ForegroundColor = ConsoleColor.Cyan);
            await Task.Run(() => DebugConsole.PrintDbgMessage("Invictus Loaded"));

            await Task.Run(() => ThreadService.LoadMainThread());
            await Task.Run(() => overlay.Show());
        }
    }
}
