// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Core.Invictus.Structures.GameObjects;
    using global::Invictus.Pub.Invictus.Framework.Menu;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using global::Invictus.Pub.Invictus.LogService;

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
            switch (TargetSelectorSettings.TSMode)
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


            for (int i = 0; Utils.ReadInt(HeroList + i) != 0; i += 4)
            {
                var obj = Utils.ReadInt(HeroList + i);
                if (obj != 0)
                {
                    if (GameObject.IsInRange(obj))
                    {
                        if (GameObject.IsAlive(obj) && GameObject.IsVisible(obj))
                        {
                            if (GameObject.IsEnemy(obj))
                            {
                                if (lowestHPTarget == 0)
                                    lowestHPTarget = obj;

                                else if(GameObject.GetHealth(obj) < GameObject.GetHealth(lowestHPTarget))
                                {
                                    lowestHPTarget = obj;
                                }
                            }
                        }
                    }

                }
            }

            return lowestHPTarget;
        }

        private static int GetClosestTarget()
        {
            int closestTarget = 0;
            var LocalPlayer = GameObject.GetLocalPLayer();

            for (int i = 0; Utils.ReadInt(HeroList + i) != 0; i += 4)
            {
                var obj = Utils.ReadInt(HeroList + i);
                if (obj != 0)
                {
                    if (GameObject.IsInRange(obj))
                    {
                        if (GameObject.IsAlive(obj) && GameObject.IsVisible(obj))
                        {
                            if (GameObject.IsEnemy(obj))
                            {
                                if (closestTarget == 0)
                                    closestTarget = obj;

                                else if (GameObject.GetDistance(LocalPlayer,obj) < GameObject.GetDistance(LocalPlayer, closestTarget))
                                {
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
