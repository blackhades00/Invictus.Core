// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Core.Invictus.Structures.GameObjects;
    using global::Invictus.Pub.Invictus.Framework.Menu;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    internal class TargetSelector
    {
        private static readonly int HeroList = Utils.ReadInt(Offsets.BASE + Offsets.oHeroList);
        private static readonly int MinionList = Utils.ReadInt(Offsets.BASE + Offsets.oMinionList);

        internal static int GetTarget()
        {
            //pseudocode
            /* if (x gedrückt) -> return lasthit target..same for waveclear
            */

            int target = 0;
            switch (Globals.TSMode)
            {
                case "LowestHPTarget":
                    target = GetLowestHPTarget();
                    break;

                case "ClosestTarget":
                    target = GetClosestTarget();
                    break;
            }

            return target;
        }

        private static int GetLowestHPTarget()
        {

            /*
             * 0x40 = max amount of heroes | 10 heroes, everyone 0x4 byte = 10 * 0x4 = 0x40
             * 0x4 from each other
             */
            int lowestHPTarget = 0;


            for (int i = 0x0; i <= 0x40; i += 0x4)
            {
                int obj = Utils.ReadInt(HeroList + i);
                if (obj != 0)
                {
                    if (!ObjectTypeFlag.IsDeadObject(obj) && !ObjectTypeFlag.IsInvalidObject(obj))
                    {
                        if (GameObject.IsInRange(obj) && obj != 0x00)
                        {
                            if (GameObject.IsValidTarget(obj))
                            {
                                if (lowestHPTarget == 0)
                                {
                                    lowestHPTarget = obj;
                                }
                                else if (GameObject.GetHealth(obj) < GameObject.GetHealth(lowestHPTarget))
                                {
                                    lowestHPTarget = obj;
                                }
                            }

                        }
                    }

                }
                else
                    break;

            }
            return lowestHPTarget;
        }

        private static int GetClosestTarget()
        {
            int closestTarget = 0;
            int LocalPlayer = GameObject.GetLocalPLayer();

            for (int i = 0x0; i < 0x40; i += 0x4)
            {
                int obj = Utils.ReadInt(HeroList + i);
                if (obj != 0)
                {
                    if (GameObject.IsInRange(obj))
                    {
                        if (GameObject.IsValidTarget(obj))
                        {
                            if (closestTarget == 0)
                            {
                                closestTarget = obj;
                            }
                            else if (GameObject.GetDistance(obj, LocalPlayer) < GameObject.GetDistance(closestTarget, LocalPlayer))
                            {
                                closestTarget = obj;
                            }
                        }

                    }

                }
                else
                {
                    break;
                }
            }


            return closestTarget;
        }
    }
}
