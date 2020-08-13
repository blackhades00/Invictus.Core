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

        public static string riot = String.Empty;

        public static void LoadCore()
        {
            if (riot.Equals("Wv*'B-H~00Xr{x_IYfIaXv4;PD{!~%_v-(M.UKgYcbKf&O8vT8kT_IG<ELoRt6") == false)
            {
                Environment.Exit(1);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitialiseCore(); // Init the core, start of main functions. Call this in Loader.
        }

        internal static async void InitialiseCore()
        {

            await Task.Run(() => Console.ForegroundColor = ConsoleColor.Cyan);
            await Task.Run(() => ThreadService.LoadMainThread());
            await Task.Run(() => overlay.Show());
        }
    }
}
