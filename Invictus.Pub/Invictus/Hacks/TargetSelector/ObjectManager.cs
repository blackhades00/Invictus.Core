// <copyright file="ObjectManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using ExSharpBase.API;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Pub.Invictus;
using Invictus.Pub.Invictus.Framework.Menu;
using Invictus.Pub.Invictus.GameEngine.GameObjects;
using Invictus.Pub.Invictus.Hacks.TargetSelector;
using Invictus.Pub.Invictus.LogService;
using System.Collections.Generic;
using System.Linq;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    class ObjectManager
    {
        private static readonly int HeroList = Utils.ReadInt(Offsets.BASE + Offsets.oHeroList);
        private static readonly int MinionList = Utils.ReadInt(Offsets.BASE + Offsets.oMinionList);


        internal static List<int> CachedHeroes = new List<int>();
        internal static List<int> CachedMinions = new List<int>();
        internal static List<int> CachedTurrets = new List<int>();

        internal static List<string> DeadHeroes = new List<string>();

        internal static int GetTarget()
        {
            int target = 0;

            //if lasthitKey is being pressed, return lasthit target.
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
            {
                target = MinionSelector.GetLasthitTarget();
                return target;
            }

            // if ComboKey is being pressed, return Hero Target.
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.Space))
            {
                switch (TargetSelectorSettings.TSMode)
                {
                    case "LowestHPTarget":
                        target = HeroSelector.GetLowestHPTarget();
                        break;

                    case "ClosestTarget":
                        target = HeroSelector.GetClosestTarget();
                        break;
                }
            }
            return target;
        }

        /// <summary>
        /// Cache all valid Heroes from the Static HeroList and save it into the CachedHeroes List.
        /// </summary>
        private static void CacheHeroes()
        {
            CachedHeroes.Clear();
            int index = 0x0;
            int obj = -1;
            while (obj != 0)
            {
                obj = Utils.ReadInt(HeroList + index);
                index += 0x4;

                if (obj == 0x00)
                    continue;
                else
                {
                    if (!ObjectTypeFlag.IsDeadObject(obj) && !ObjectTypeFlag.IsInvalidObject(obj))
                    {
                        DeadHeroes.Clear();
                        for (int i = 0; i < AllPlayerData.AllPlayers.Count; i++)
                        {
                            if (AllPlayerData.AllPlayers[i].IsDead)
                                DeadHeroes.Add(AllPlayerData.AllPlayers[i].ChampionName);
                        }
    
                            if (DeadHeroes.Count > 0)
                            {
                                for (int i = 0; i < DeadHeroes.Count; i++)
                                {
                                    if (DeadHeroes[i].Substring(0, 3) != GameObject.GetChampionName(obj).Substring(0, 3)) // if first 3 digits are the same
                                        CachedHeroes.Add(obj);

                                    DebugConsole.PrintDbgMessage(DeadHeroes[i].Substring(0, 3) + "            " + GameObject.GetChampionName(obj).Substring(0, 3));
                                }
                            }
                            else
                                CachedHeroes.Add(obj);
                        
                    }
                }
            }
        }

        /// <summary>
        /// Cache all vaid Minions from the static MinionList and save it into the CachedMinions List.
        /// </summary>
        private static void CacheMinions()
        {
            CachedMinions.Clear();
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
                            CachedMinions.Add(obj);
                    }
                }
            }
        }

        internal static void UpdateAndCache()
        {
            while (true)
            {
                CacheHeroes();
                CacheMinions();
            }

        }
    }
}
