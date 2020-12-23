// <copyright file="HeroManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.LogService;
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
        /// Static list which contains all enemys.
        /// </summary>
        internal static readonly List<int> enemyList = new List<int>();

        /// <summary>
        /// Static list which contains all allys.
        /// </summary>
        internal static readonly List<int> allyList = new List<int>();

        /// <summary>
        /// Pushes all Heroes in their specified collection. Function should be called upon gamestart.
        /// </summary>
        internal void PushHeroList()
        {
            int heroList_pretPtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OHeroList);

            int heroList = Utils.ReadInt(heroList_pretPtr + 0x4);

            int heroList_size = Utils.ReadInt(heroList_pretPtr + 0x8);
            for (int i = 0; i < heroList_size; i++)
            {
                int obj = Utils.ReadInt(heroList + i * 0x4);

                if (obj.IsEnemy())
                    enemyList.Add(obj);
                else if (obj != Engine.GetLocalObject())
                    allyList.Add(obj);
            }
        }

        /// <summary>
        /// Returns the lowest HP Object.
        /// The Object is valid for a attack, which means its in range and a valid target/succeeded on a validation check.
        /// </summary>
        /// <returns></returns>
        internal int GetLowestHPTarget(float range = 0f)
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
                                else if (lowestHPTarget.GetHealth() < enemy.GetHealth())
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

        /// <summary>
        /// Returns all allies in range.
        /// </summary>
        /// <returns></returns>
        internal List<int> GetAlliesInRange(float range)
        {
            List<int> alliesInRange = new List<int>();
            foreach (var ally in allyList.Where(ally => ally.IsAlive()))
            {
                if (ally.IsInRange(range))
                {
                    alliesInRange.Add(ally);
                }

            }

            return alliesInRange;
        }



        internal int GetClosestTarget()
        {
            var closestTarget = 0;


            return 0;
        }
    }
}