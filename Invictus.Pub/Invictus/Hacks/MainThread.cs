// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Pub.Invictus.GameEngine.GameObjects;
using Invictus.Pub.Invictus.LogService;

namespace Invictus.Pub.Invictus.Hacks
{
    internal class MainThread
    {
        internal static void MainLoop()
        {
            DebugConsole.AllocConsole();
            while (true)
            {
                Utils.Unload();
                if(Utils.IsGameInForeground() && GameObject.GetLocalPLayer() != 0)
                {
                    Orbwalker.Orbwalker.Orbwalk();
                }

            }

        }
    }
}
