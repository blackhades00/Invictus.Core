// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.Structures.GameEngine;

namespace InvictusSharp.Callbacks
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
                    if (Utils.IsGameInForeground()) Orbwalker.Orbwalk(ObjectManager.GetTarget(), Properties.Settings.Default.Orbwalker_ExtraWindup);
                }
            });
        }
    }
}