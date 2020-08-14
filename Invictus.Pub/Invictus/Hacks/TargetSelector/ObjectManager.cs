// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Pub.Invictus.Framework.Menu;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    internal class ObjectManager
    {
        private static readonly int HeroList = Utils.ReadInt(Offsets.BASE + 0x0);

        internal static int GetTarget()
        {
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

                if (lowestHPTarget == 0) // if lowestHPTarget is empty
                {
                    lowestHPTarget = obj;
                }

                if (CGameObject.GetHealth(obj) < CGameObject.GetHealth(lowestHPTarget))
                {
                    lowestHPTarget = obj;
                }
            }
            return lowestHPTarget;
        }

        private static int GetClosestTarget()
        {
            int closestTarget = 0;
            int LocalPlayer = CGameObject.GetLocalPLayer();

            for (int i = 0x0; i <= 0x40; i += 0x4)
            {
                int obj = Utils.ReadInt(HeroList + i);

                if (closestTarget == 0)
                {
                    closestTarget = obj;
                }

                if (CGameObject.GetDistance(obj, LocalPlayer) < CGameObject.GetDistance(closestTarget, LocalPlayer))
                {
                    closestTarget = obj;
                }
            }


            return 0;
        }
    }
}
