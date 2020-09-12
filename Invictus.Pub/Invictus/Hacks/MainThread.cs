// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Hacks
{
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

                if (Engine.GetLocalObject() == 0)
                {
                    Environment.Exit(1);
                }
            }

        }
    }
}
