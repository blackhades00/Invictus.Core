// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Web.UI.WebControls;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Hacks.TargetSelector
{
    /// <summary>
    /// The HeroSelector class contains all TargetSelector functions regarding Heroes.
    /// </summary>
    internal class HeroManager
    {
        /// <summary>
        /// Returns the static heroList_firstPtr. Contains all active Heroes within a game. Objects must be checked for invalidity or deletion though.
        /// </summary>
        private static readonly int heroList_pretPtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OHeroList);

        private static readonly int heroList = Utils.ReadInt(heroList_pretPtr + 0x4);

        private static readonly int heroList_size = Utils.ReadInt(heroList_pretPtr + 0x8);

        /// <summary>
        /// Static list which contains all enemys.
        /// </summary>
        internal static readonly List<int> enemyList = new List<int>();

        /// <summary>
        /// Pushes all Heroes in their specified collection. Function should be called upon gamestart.
        /// </summary>
        internal static void PushHeroList()
        {
            for (int i = 0; i < heroList_size; i++)
            {
                int obj = Utils.ReadInt(heroList + i * 0x4);

                if(obj.IsEnemy())
                    enemyList.Add(obj);
            }
        }

        /// <summary>
        /// Returns the lowest HP Object.
        /// The Object is valid for a attack, which means its in range and a valid target/succeeded on a validation check.
        /// </summary>
        /// <returns></returns>
        internal static int GetLowestHPTarget(float range = 0f)
        {
            if (range == 0f)
                range = Engine.GetLocalObject().GetAttackRange();

            var lowestHPTarget = 0;
            foreach (var enemy in enemyList)
            {
                if (enemy.IsInRange(range))
                {
                    if (enemy.IsAlive())
                    {
                        if (enemy.IsVisible())
                        {
                            if (enemy.IsTargetable())
                            {
                                if (lowestHPTarget == 0)
                                    lowestHPTarget = enemy;
                                else if(lowestHPTarget.GetHealth() < enemy.GetHealth())
                                {
                                    lowestHPTarget = enemy;
                                }
                            }
                        }
                    }
                }
            } 

            return lowestHPTarget;
        }

        internal static int GetClosestTarget()
        {
            var closestTarget = 0;


            return 0;
        }
    }
}