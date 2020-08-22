// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Pub.Invictus;
using Invictus.Pub.Invictus.GameEngine.GameObjects;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    internal class MinionManager
    {
        private static readonly int MinionList = Utils.ReadInt(Offsets.BASE + Offsets.oMinionList);
        internal static int GetLasthitTarget()
        {
            int lasthitTarget = 0;
            int index = 0x0;
            int obj = -1;
            while (obj != 0)
            {
                obj = Utils.ReadInt(MinionList + index);
                index += 0x4;

                if (obj == 0x00)
                    continue;
                else
                {
                    if (!ObjectTypeFlag.IsDeadObject(obj) && !ObjectTypeFlag.IsInvalidObject(obj))
                    {
                        if (ObjectTypeFlag.IsMinion(obj))
                        {
                            if (GameObject.IsInRange(obj))
                            {
                                if (GameObject.IsAlive(obj) && GameObject.IsEnemy(obj) && GameObject.IsVisible(obj))
                                {
                                    if (GameObject.IsLasthitable(obj))
                                    {
                                        if (lasthitTarget == 0)
                                            lasthitTarget = obj;

                                        else if (GameObject.GetHealth(obj) < GameObject.GetHealth(lasthitTarget))
                                            lasthitTarget = obj;
                                    }
                                }
                            }

                        }

                    }
                }
            }

            return lasthitTarget;
        }
    }
}
