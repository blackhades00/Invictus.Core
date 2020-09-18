// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    internal class MinionManager
    {
        internal static int GetLasthitTarget()
        {
            int minionList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            int minionList = Utils.ReadInt(minionList_PrePtr + 0x4);

            int index = 0x0;
            int obj = -1;
            while (obj != 0)
            {
                obj = Utils.ReadInt(minionList + index);
                index += 0x4;

                switch (obj)
                {
                    case 0x00:
                        continue;
                    default:
                        {
                            if (obj.IsInRange())
                            {
                                if (obj.IsEnemy() && !obj.IsNoMinion())
                                {
                                    if (obj.IsVisible())
                                    {

                                        if (obj.IsAlive() && obj.IsTargetable())
                                        {
                                            if (obj.IsLasthitable())
                                            {
                                                return obj;
                                            }
                                        }

                                    }
                                }
                            }

                            break;
                        }
                }
            }

            return 0;
        }


        internal static int GetWaveclearTarget()
        {
            int minionList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            int minionList = Utils.ReadInt(minionList_PrePtr + 0x4);

            int index = 0x0;
            int obj = -1;
            while (obj != 0)
            {
                obj = Utils.ReadInt(minionList + index);
                index += 0x4;

                switch (obj)
                {
                    case 0x00:
                        continue;
                    default:
                        {
                            if (obj.IsInRange())
                            {
                                if (obj.IsEnemy() && !obj.IsNoMinion())
                                {
                                    if (obj.IsVisible())
                                    {

                                        if (obj.IsAlive() && obj.IsTargetable())
                                        {
                                            return obj;
                                        }

                                    }
                                }
                            }

                            break;
                        }
                }
            }

            return 0;
        }
    }
}

