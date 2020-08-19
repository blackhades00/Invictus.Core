// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Core.Invictus.Structures.GameObjects;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using System.Collections.Generic;

    /// <summary>
    /// The HeroSelector class contains all TargetSelector functions regarding Heroes.
    /// </summary>
    internal class HeroSelector
    {
        private static readonly int HeroList = Utils.ReadInt(Offsets.BASE + Offsets.oHeroList);

        internal static int GetLowestHPTarget()
        {
            int lowestHPTarget = 0;
            int index = 0x0;
            int obj = -1;

            while (obj != 0)
            {
                obj = Utils.ReadInt(HeroList + index);
                index += 0x4;

                if (obj == 0x00)
                    continue;
                else
                {
                    if (!ObjectTypeFlag.IsDeadObject(obj) && !ObjectTypeFlag.IsInvalidObject(obj))
                    {
                        if (GameObject.IsInRange(obj))
                        {
                            if (GameObject.IsAlive(obj) && GameObject.IsEnemy(obj))
                            {

                                if (GameObject.IsVisible(obj) && ObjectTypeFlag.IsAttackable(obj))
                                {
                                    if (lowestHPTarget == 0)
                                        lowestHPTarget = obj;
                                    else if (GameObject.GetHealth(lowestHPTarget) > GameObject.GetHealth(obj))
                                        lowestHPTarget = obj;
                                }

                            }
                        }
                    }
                }

            }
            return lowestHPTarget;
        }

        internal static int GetClosestTarget()
        {
            int closestTarget = 0;
            var localPlayer = GameObject.GetLocalPLayer();
            int index = 0x0;
            int obj = -1;

            while (obj != 0)
            {
                obj = Utils.ReadInt(HeroList + index);
                index += 0x4;

                if (obj == 0x00)
                    continue;
                else
                {
                    if (!ObjectTypeFlag.IsDeadObject(obj) && !ObjectTypeFlag.IsInvalidObject(obj))
                    {
                        if (GameObject.IsInRange(obj))
                        {
                            if (GameObject.IsAlive(obj) && GameObject.IsEnemy(obj))
                            {

                                if (GameObject.IsVisible(obj) && ObjectTypeFlag.IsAttackable(obj))
                                {
                                    if (closestTarget == 0)
                                        closestTarget = obj;
                                    else if (GameObject.GetHealth(closestTarget) > GameObject.GetHealth(obj))
                                        closestTarget = obj;

                                }
                            }
                        }
                    }
                }
            }
            return closestTarget;
        }
    }
}
