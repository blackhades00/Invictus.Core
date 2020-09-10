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
            int minionList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            
            int lasthitTarget = 0;
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
                        if (GameObject.IsEnemy(obj) && !GameObject.IsNoMinion(obj))
                        {
                            if (GameObject.IsVisible(obj))
                            {
                                if (GameObject.IsInRange(obj))
                                {
                                    if (GameObject.IsAlive(obj) && GameObject.IsTargetable(obj))
                                    {
                                        if (GameObject.IsLasthitable(obj))
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

            return lasthitTarget;
        }


        internal static int GetWaveclearTarget()
        {
            int minionList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            int turretList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OTurretList);

            int turretIdx = 0x0;
            int turretObj = -1;

            while(turretObj != 0)
            {
                turretObj = Utils.ReadInt(turretList + turretIdx);
                turretIdx += 0x4;

                switch (turretObj)
                {
                    case 0x00:
                        continue;
                    default:
                    {
                        if(GameObject.IsInRange(turretObj))
                        {
                            if (GameObject.IsEnemy(turretObj) && GameObject.IsAlive(turretObj) && GameObject.IsTargetable(turretObj))
                                return turretObj;
                        }

                        break;
                    }
                }
            }

            int waveclearTarget = 0;
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
                        if (GameObject.IsEnemy(obj) && !GameObject.IsNoMinion(obj))
                        {
                            if (GameObject.IsVisible(obj))
                            {
                                if (GameObject.IsInRange(obj))
                                {
                                    if (GameObject.IsAlive(obj) && GameObject.IsTargetable(obj))
                                    {
                                        if (GameObject.GetTeam(obj) == 300)
                                            return obj;
                                        else
                                        {
                                            if (GameObject.IsLasthitable(obj))
                                                return obj;
                                            else
                                            {
                                                return obj;
                                            }

                                        }


                                    }
                                }
                            }
                        }

                        break;
                    }
                }
            }

            return waveclearTarget;
        }
    }
}
