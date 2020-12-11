// <copyright file="MinionSelector.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.Prediction;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Hacks.TargetSelector
{
    internal class MinionManager
    {

        #region Minions
        internal static List<int> TurretList = new List<int>();

        internal static List<int> InhibList = new List<int>();

        /// <summary>
        /// Gets all minions depending on the given parameter.
        /// </summary>
        /// <param name="isEnemy"> set to true if only enemy minions should be filtered.</param>
        /// <param name="inRange"> set to true if only minions in range should be filtered.</param>
        /// <returns></returns>
        internal static List<int> GetMinions(bool isEnemy, bool inRange)
        {
            int minionList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);

            int minionList = Utils.ReadInt(minionList_PrePtr + 0x4);

            int minionList_size = Utils.ReadInt(minionList_PrePtr + 0x8);
            List<int> minions = new List<int>();

            for (int i = 0; i < minionList_size; i++)
            {
                int obj = Utils.ReadInt(minionList + i * 0x4);

                if (obj.IsAlive())
                {
                    if (obj.IsInRange() == inRange)
                    {
                        if (obj.IsEnemy() == isEnemy)
                        {
                            if (obj.IsVisible() && obj.IsTargetable() == isEnemy)
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
            foreach (var minion in GetMinions(true, true))
            {
                if (minion.IsLasthitable())
                    return minion;

            }

            return 0;
        }

        /// <summary>
        /// Gets the waveclear target using the <see cref="GetMinions"/> function.
        /// </summary>
        /// <returns></returns>
        internal static int GetWaveclearTarget()
        {
            var target = 0;
            if (GetEnemyStructuresInRange() != 0)
                return GetEnemyStructuresInRange();

            foreach (var minion in GetMinions(true, true))
            {

                if (minion.IsLasthitable())
                    return minion;
                else
                {
                    if (target == 0)
                    {
                        target = minion;
                    }
                    else if (minion.GetHealth() < target.GetHealth())
                    {
                        target = minion;
                    }
                }
            }

            return target;
        }

        #endregion

        #region Turret

        private static readonly int turretList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OTurretList);
        private static readonly int turretList = Utils.ReadInt(turretList_PrePtr + 0x4);
        private static readonly int turretList_size = Utils.ReadInt(turretList_PrePtr + 0x8);

        private static readonly int inhibList_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OInhibList);
        private static readonly int inhibList = Utils.ReadInt(inhibList_PrePtr + 0x4);
        private static readonly int inhibList_size = Utils.ReadInt(inhibList_PrePtr + 0x8);


        /// <summary>
        /// Gets all Enemy Turrets in attack range. Turrets are targetable.
        /// </summary>
        /// <returns></returns>
        internal static int GetEnemyStructuresInRange()
        {
            foreach (var Turret in TurretList)
            {
                if (Turret.IsInRange())
                {
                    if (Turret.IsVisible())
                        if (Turret.IsEnemy())
                        {
                            if ( Turret.IsTargetable())
                                return Turret;

                        }
                }
            }

            foreach (var Inhib in InhibList)
            {
                if (Inhib.IsInRange())
                {
                    if (Inhib.IsVisible())
                        if (Inhib.IsEnemy())
                        {
                            if (Inhib.IsAlive() && Inhib.IsTargetable())
                                return Inhib;

                        }
                }
            }

            return 0;
        }

        /// <summary>
        /// Pushes all Turrets into the <see cref="TurretList"/>.
        /// </summary>
        internal static void PushStructureLists()
        {

            for (int i = 0; i < turretList_size; i++)
            {
                int obj = Utils.ReadInt(turretList + i * 0x4);
                TurretList.Add(obj);

            }

            for (int i = 0; i < inhibList_size; i++)
            {
                int obj = Utils.ReadInt(inhibList + i * 0x4);
                InhibList.Add(obj);
            }
        }

        #endregion


    }
}