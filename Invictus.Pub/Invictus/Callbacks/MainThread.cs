// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Hacks.TargetSelector;
using Invictus.Core.Invictus.Structures.GameEngine;

namespace Invictus.Core.Invictus.Hacks
{
    internal class MainThread
    {
        internal static async void MainLoop()
        {
            await Task.Run(() =>
            {
                while (Engine.GetLocalObject() != 0)
                {
                    Utils.Unload();
                    if (Utils.IsGameInForeground()) Orbwalker.Orbwalker.Orbwalk(ObjectManager.GetTarget(), Properties.Settings.Default.Orbwalker_ExtraWindup);
                }
            });
        }
    }
}