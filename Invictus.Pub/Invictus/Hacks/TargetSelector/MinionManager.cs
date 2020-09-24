// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    internal class MinionManager
    {

        /// <summary>
        /// List containing all Turrets.
        /// </summary>
        internal static List<int> TurretList = new List<int>();

        /// <summary>
        /// Gets all minions depending on the given parameter.
        /// </summary>
        /// <param name="isEnemy"> set to true if only enemy minions should be filtered.</param>
        /// <param name="inRange"> set to true if only minions in range should be filtered.</param>
        /// <returns></returns>
        internal static List<int> GetMinions(bool isEnemy, bool inRange)
        {
            List<int> minions = new List<int>();

            var minionList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            var minionList = Utils.ReadInt(minionList_PrePtr + 0x4);

            var index = 0x0;
            var obj = -1;

            while (obj != 0)
            {
                obj = Utils.ReadInt(minionList + index);
                index += 0x4;

                if (obj == 0x00)
                    continue;
                else
                {
                    if (obj.IsInRange() == inRange)
                    {
                        if (obj.IsEnemy() == isEnemy)
                        {
                            if (obj.IsAlive() && obj.IsVisible() && obj.IsTargetable() == isEnemy)
                                minions.Add(obj);
                        }
                    }

                }
            }

            return minions;
        }

        /// <summary>
        /// Gets the lasthit target using the <see cref="GetMinions"/> function.
        /// </summary>
        /// <returns></returns>
        internal static int GetLasthitTarget()
        {
            var lasthitTarget = 0;
            foreach (var minion in GetMinions(true, true).Where(minion => minion.IsLasthitable()))
            {
                if (lasthitTarget == 0)
                    lasthitTarget = minion;

                if (minion.GetHealth() < lasthitTarget.GetHealth())
                    lasthitTarget = minion;
            }

            return lasthitTarget;
        }

        /// <summary>
        /// Gets the waveclear target using the <see cref="GetMinions"/> function.
        /// </summary>
        /// <returns></returns>
        internal static int GetWaveclearTarget()
        {
            if (GetEnemyTurretInRange() != 0)
                return GetEnemyTurretInRange();

            var target = 0;

            foreach (var minion in GetMinions(true, true).Where(minion => !minion.IsNoMinion()))
            {
                if (target == 0)
                    target = minion;

                if (minion.GetHealth() < target.GetHealth())
                    target = minion;
            }

            return target;
        }

        /// <summary>
        /// Gets all Enemy Turrets in attack range. Turrets are targetable.
        /// </summary>
        /// <returns></returns>
        internal static int GetEnemyTurretInRange()
        {
            foreach (var Turret in TurretList)
            {
                if (Turret.IsInRange())
                {
                    if (Turret.IsVisible())
                        if (Turret.IsEnemy())
                        {
                            if (Turret.IsAlive() && Turret.IsTargetable())
                                return Turret;

                        }
                }
            }

            return 0;
        }

        /// <summary>
        /// Pushes all Turrets into the <see cref="TurretList"/>.
        /// </summary>
        internal static void PushTurretList()
        {
            var turretList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OTurretList);
            var turretList = Utils.ReadInt(turretList_PrePtr + 0x4);

            var target = 0;

            var index = 0x0;
            var obj = -1;
            while (obj != 0)
            {

                index += 0x4;

                switch (obj)
                {
                    case 0x00:
                        continue;
                    default:
                        {

                            if (obj.IsAlive())
                            {
                                TurretList.Add(obj);
                            }
                            break;
                        }
                }
            }
        }

    }
}