// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Pub.Invictus;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    internal class MinionSelector
    {
        private static readonly int MinionList = Utils.ReadInt(Offsets.BASE + Offsets.oMinionList);

        internal static int GetLasthitTarget()
        {
            int lasthitTarget = 0;
            for (int i = 0; Utils.ReadInt(MinionList + i) != 0; i += 4)
            {
                var obj = Utils.ReadInt(MinionList + i);
                if (obj != 0)
                {
                    if (GameObject.IsInRange(obj))
                    {
                        if (GameObject.IsAlive(obj) && GameObject.IsVisible(obj))
                        {
                            if (GameObject.IsEnemy(obj))
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
            return lasthitTarget;
        }
    }
}
