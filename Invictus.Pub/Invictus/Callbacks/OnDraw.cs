// <copyright file="OnDraw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Callbacks
{
    using SharpDX;

    /// <summary>
    /// OnDraw Callback, all Drawing Functions are being called here.
    /// </summary>
    internal class OnDraw
    {
        // All drawings here!
        public static void LoadCallback()
        {
            if (Utils.IsGameInForeground())
            {
               Draw.DrawWatermark();

                Draw.DrawMenu();

                if (TargetSelectorSettings.DrawAttackRange)
                {
                   Draw.DrawAttackRange(Engine.GetLocalObject(), Color.Cyan);
                }

                //Draw.DrawCooldown(GameObject.me);
               Draw.DrawWard();
            }
        }
    }
}
