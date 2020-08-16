// <copyright file="OnDraw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Callbacks
{
    using global::Invictus.Pub.Invictus.Framework.Menu;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using global::Invictus.Pub.Invictus.Hacks.Drawings;
    using SharpDX;

    internal class OnDraw
    {
        // All drawings here!
        public static void LoadCallback()
        {
            if (Utils.IsGameInForeground())
            {
                Draw.DrawWatermark();

                Draw.DrawMenu();

                if(Globals.DrawAttackRange)
                Draw.DrawAttackRange(GameObject.GetLocalPLayer(), Color.Cyan);
            }
        }
    }
}
