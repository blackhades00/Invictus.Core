// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    using global::Invictus.Core.Invictus.Structures.GameObjects;
    using global::Invictus.Pub.Invictus;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    internal class MinionSelector
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
                    
                        if (GameObject.IsInRange(obj))
                        {
                            if (GameObject.IsAlive(obj) && GameObject.IsEnemy(obj))
                            {

                                if (GameObject.IsVisible(obj))
                                {
                                    if (GameObject.IsLasthitable(obj))
                                    {
                                        if (lasthitTarget == 0)
                                            lasthitTarget = obj;
                                        else if(GameObject.GetHealth(obj) < GameObject.GetHealth(lasthitTarget))
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
