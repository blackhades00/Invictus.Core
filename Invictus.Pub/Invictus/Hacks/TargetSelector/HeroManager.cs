// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Structures.GameObjects;
using System.Collections.Generic;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{

    /// <summary>
    /// The HeroSelector class contains all TargetSelector functions regarding Heroes.
    /// </summary>
    internal class HeroManager
    {
        /// <summary>
        /// Returns the static HeroList. Contains all active Heroes within a game. Objects must be checked for invalidity or deletion though.
        /// </summary>
        private static readonly int HeroList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OHeroList);

        /// <summary>
        /// Static list which contains all enemys.
        /// </summary>
        private static readonly List<int> enemyList = new List<int>();

        /// <summary>
        /// Pushes all Heroes in their specified collection. Function should be called upon gamestart.
        /// </summary>
        internal static void PushHeroList()
        {
            int index = 0x4;
            int obj = -1;
            while (obj != 0)
            {
                obj = Utils.ReadInt(HeroList + index);
                index += 0x4;

                switch (obj)
                {
                    case 0x00:
                        continue;
                    default:
                        {
                            if (obj.IsEnemy())
                            {
                                enemyList.Add(obj);
                            }


                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Returns the lowest HP Object.
        /// The Object is valid for a attack, which means its in range and a valid target/succeeded on a validation check.
        /// </summary>
        /// <returns></returns>
        internal static int GetLowestHPTarget()
        {
            int lowestHPTarget = 0;

            for (int i = 0; i < enemyList.Count; i++)
            {

                if (enemyList[i].IsInRange())
                {
                    if (enemyList[i].IsAlive() && enemyList[i].IsVisible() && enemyList[i].IsTargetable())
                    {
                        if (lowestHPTarget == 0)
                        {
                            lowestHPTarget = enemyList[i];
                        }

                        if (enemyList[i].GetHealth() < lowestHPTarget.GetHealth())
                            lowestHPTarget = enemyList[i];
                    }
                }
            }
            return lowestHPTarget;
        }

        internal static int GetClosestTarget()
        {
            var closestTarget = 0;


            return 0;
        }
    }
}
