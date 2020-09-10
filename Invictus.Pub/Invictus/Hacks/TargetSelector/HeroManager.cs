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
        private static readonly int HeroList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OHeroList);

        private static List<GameObject> enemyList = new List<GameObject>();

        internal static void PushHeroList()
        {
            int index = 0x4;
            int obj = -1;

            while (obj != 0)
            {
                obj = Utils.ReadInt(HeroList + index);
                GameObject hero = new GameObject(obj);
                index += 0x4;

                switch (obj)
                {
                    case 0x00:
                        continue;
                    default:
                    {
                        if(GameObject.IsEnemy(obj))
                            enemyList.Add(obj);
                        break;
                    }
                }
            }
        }

        internal static GameObject GetLowestHPTarget()
        {
            GameObject lowestHPTarget = null;

            foreach (var enemyObject in enemyList)
            {
                GameObject enemy = new GameObject(enemyObject);

                if (lowestHPTarget == null)
                {
                    lowestHPTarget = enemy;
                }
               


            }

            return null;
        }

       /*
        internal static int GetLowestHpTarget()
        {
            int lowestHpTarget = 0;

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
                            if (GameObject.IsEnemy(obj))
                            {
                                if (GameObject.IsVisible(obj))
                                {
                                    if (GameObject.IsInRange(obj))
                                    {
                                        if (GameObject.IsAlive(obj) && GameObject.IsTargetable(obj))
                                        {
                                            if (lowestHpTarget == 0)
                                                lowestHpTarget = obj;

                                            else if (GameObject.GetHealth(obj) < GameObject.GetHealth(lowestHpTarget))
                                                lowestHpTarget = obj;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                }
            }

            return lowestHpTarget;
        }
       */
        internal static int GetClosestTarget()
        {
            int closestTarget = 0;
            var localPlayer = GameObject.Me;


            return closestTarget;
        }
    }
}
