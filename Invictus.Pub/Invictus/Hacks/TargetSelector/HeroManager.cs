// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Pub.Invictus.Framework.Menu;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using global::Invictus.Pub.Invictus.LogService;
    using global::Invictus.Pub.Invictus.Structures.GameObject;

    internal class HeroManager
    {

        internal static int GetTarget()
        {
            int target = 0;
            switch (Globals.TSMode)
            {
                case "LowestHPTarget":
                    target = HeroManager.GetLowestHPTarget();
                    break;

                case "ClosestTarget":
                    target = HeroManager.GetNearestTarget();
                    break;
            }

            return target;
        }

        private static int GetLowestHPTarget()
        {
            return 0;
        }

        private static int GetNearestTarget()
        {
            return 0;
        }
    }
}
