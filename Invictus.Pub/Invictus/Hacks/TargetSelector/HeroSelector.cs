// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Core.Invictus.Hacks.TargetSelector;
    using global::Invictus.Core.Invictus.Structures.GameObjects;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using System.Collections.Generic;

    /// <summary>
    /// The HeroSelector class contains all TargetSelector functions regarding Heroes.
    /// </summary>
    internal class HeroSelector
    {


        internal static int GetLowestHPTarget()
        {
            int lowestHPTarget = 0;

            for (int i = 0; i < ObjectManager.CachedHeroes.Count; i++)
            {
                var obj = ObjectManager.CachedHeroes[i];

                if (GameObject.IsInRange(obj))
                {

                    if (GameObject.IsEnemy(obj))
                    {
                        if (lowestHPTarget == 0)
                            lowestHPTarget = obj;
                        else if (GameObject.GetHealth(obj) < GameObject.GetHealth(lowestHPTarget))
                            lowestHPTarget = obj;
                    }

                }
            }

            return lowestHPTarget;
        }

        internal static int GetClosestTarget()
        {
            int closestTarget = 0;
            var localPlayer = GameObject.GetLocalPLayer();

            for (int i = 0; i < ObjectManager.CachedHeroes.Count; i++)
            {
                var obj = ObjectManager.CachedHeroes[i];

                if (GameObject.IsInRange(obj))
                {

                    if (GameObject.IsEnemy(obj))
                    {
                        if (closestTarget == 0)
                            closestTarget = obj;
                        else if (GameObject.GetDistance(obj,localPlayer) < GameObject.GetDistance(localPlayer,closestTarget))
                            closestTarget = obj;
                    }

                }
            }

            return closestTarget;
        }
    }
}
