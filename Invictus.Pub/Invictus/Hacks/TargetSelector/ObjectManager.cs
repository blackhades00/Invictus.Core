// <copyright file="ObjectManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Pub.Invictus;
using Invictus.Pub.Invictus.Framework.Menu;
using Invictus.Pub.Invictus.Hacks.TargetSelector;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    class ObjectManager
    {
        internal static int GetTarget()
        {
            int target = 0;

            //if lasthitKey is being pressed, return lasthit target.
            if(Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
            {
                target = MinionSelector.GetLasthitTarget();
                return target;
            }

            // if ComboKey is being pressed, return Hero Target.
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.Space))
            {
                switch (TargetSelectorSettings.TSMode)
                {
                    case "LowestHPTarget":
                        target = HeroSelector.GetLowestHPTarget();
                        break;

                    case "ClosestTarget":
                        target = HeroSelector.GetClosestTarget();
                        break;
                }
            }
            return target;
        }
    }
}
