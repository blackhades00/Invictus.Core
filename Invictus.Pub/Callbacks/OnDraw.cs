// <copyright file="OnDraw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Framework.Input;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using log4net;
using SharpDX;

namespace InvictusSharp.Callbacks
{
    /// <summary>
    /// OnDraw Callback, all Drawing Functions are being called here.
    /// </summary>
    internal class OnDraw
    {
        // All drawings here!
        public static void LoadCallback()
        {
            Draw.DrawMenu();
            if (Utils.IsGameInForeground())
            {
                Draw.DrawWatermark();


                if (Properties.Settings.Default.DrawAttackRange) Draw.DrawAttackRange(Engine.GetLocalObject(), Color.Cyan);

                Draw.DrawWard();

                if (Properties.Settings.Default.DrawSpellCD) Draw.DrawEnemyCooldowns();

                if (Properties.Settings.Default.DrawRecallTracker) Draw.DrawRecallTracker();


            }
        }
    }
}