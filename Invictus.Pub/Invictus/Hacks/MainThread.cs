// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks
{
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using System;

    internal class MainThread
    {
        internal static void MainLoop()
        {
            while (true)
            {
                Utils.Unload();
                if (Utils.IsGameInForeground())
                {
                    Orbwalker.Orbwalker.Orbwalk();
                }

                if (GameObject.GetLocalPLayer() == 0)
                {
                    Environment.Exit(1);
                }
            }

        }
    }
}
