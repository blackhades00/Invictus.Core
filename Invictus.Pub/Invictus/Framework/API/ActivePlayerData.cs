// <copyright file="ActivePlayerData.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Linq;
using Invictus.Core.Invictus.LogService;
using Newtonsoft.Json.Linq;

namespace Invictus.Core.Invictus.Framework.API
{
    /// <summary>
    /// ActivePlayer Class contains Information about the LocalPlayer readen through JsonParsing parsed from the <see cref="Service"/> Class.
    /// </summary>
    public class ActivePlayerData
    {
      internal static JObject UnitRadiusData;
      internal static JObject SpellDB;
        public static string GetSummonerName()
        {
            return Service.GetActivePlayerData()["summonerName"].ToString();
        }

        public static string GetChampionName()
        {
            return AllPlayerData.AllPlayers.Where(x => x.SummonerName == GetSummonerName()).First().ChampionName;
        }

        public static void ParseUnitRadiusData()
        {
            try
            {
                string unitRadiusDataString = File.ReadAllText(Directory.GetCurrentDirectory() + @"\UnitRadius.json");
                UnitRadiusData = JObject.Parse(unitRadiusDataString);

              
            }
            catch (Exception ex)
            {
               DebugConsole.PrintErrorMessage("Failed Parsing BoundingRadius");
                throw new Exception("UnitRadiusParseExecption");
            }
        }

        public static void ParseSpellDB()
        {
            try
            {
                string unitRadiusDataString = File.ReadAllText(Directory.GetCurrentDirectory() + @"\SpellDB.json");
                UnitRadiusData = JObject.Parse(unitRadiusDataString);

              
            }
            catch (Exception ex)
            {
                DebugConsole.PrintErrorMessage("Failed Parsing BoundingRadius");
                throw new Exception("UnitRadiusParseExecption");
            }
        }

        public static int GetLevel()
        {
            return Service.GetActivePlayerData()["level"].ToObject<int>();
        }

        public static float GetCurrentGold()
        {
            return Service.GetActivePlayerData()["currentGold"].ToObject<float>();
        }

        public class Abilities
        {
            public class Q
            {
                public static int GetLevel()
                {
                    return Service.GetActivePlayerData()["Q"]["abilityLevel"].ToObject<int>();
                }

                public static string GetName()
                {
                    return Service.GetActivePlayerData()["Q"]["displayName"].ToString();
                }

                public static string GetSpellId()
                {
                    return Service.GetActivePlayerData()["Q"]["id"].ToString();
                }
            }

            public class W
            {
                public static int GetLevel()
                {
                    return Service.GetActivePlayerData()["W"]["abilityLevel"].ToObject<int>();
                }

                public static string GetName()
                {
                    return Service.GetActivePlayerData()["W"]["displayName"].ToString();
                }

                public static string GetSpellId()
                {
                    return Service.GetActivePlayerData()["W"]["id"].ToString();
                }
            }

            public class E
            {
                public static int GetLevel()
                {
                    return Service.GetActivePlayerData()["E"]["abilityLevel"].ToObject<int>();
                }

                public static string GetName()
                {
                    return Service.GetActivePlayerData()["E"]["displayName"].ToString();
                }

                public static string GetSpellId()
                {
                    return Service.GetActivePlayerData()["E"]["id"].ToString();
                }
            }

            public class R
            {
                public static int GetLevel()
                {
                    return Service.GetActivePlayerData()["R"]["abilityLevel"].ToObject<int>();
                }

                public static string GetName()
                {
                    return Service.GetActivePlayerData()["R"]["displayName"].ToString();
                }

                public static string GetSpellId()
                {
                    return Service.GetActivePlayerData()["R"]["id"].ToString();
                }
            }
        }

        public class ChampionStats
        {
            public static float GetAbilityPower()
            {
                return Service.GetActivePlayerData()["championStats"]["abilityPower"].ToObject<float>();
            }

            public static float GetArmor()
            {
                return Service.GetActivePlayerData()["championStats"]["armor"].ToObject<float>();
            }

            public static float GetArmorPenetrationFlat()
            {
                return Service.GetActivePlayerData()["championStats"]["armorPenetrationFlat"].ToObject<float>();
            }

            public static float GetArmorPenetrationPercent()
            {
                return Service.GetActivePlayerData()["championStats"]["armorPenetrationPercent"].ToObject<float>();
            }

            public static float GetAttackDamage()
            {
                return Service.GetActivePlayerData()["championStats"]["attackDamage"].ToObject<float>();
            }

            public static float GetAttackRange()
            {
                return Service.GetActivePlayerData()["championStats"]["attackRange"].ToObject<float>();
            }

            public static float GetAttackSpeed()
            {
                return Service.GetActivePlayerData()["championStats"]["attackSpeed"].ToObject<float>();
            }

            public static float GetBonusArmorPenetrationPercent()
            {
                return Service.GetActivePlayerData()["championStats"]["bonusArmorPenetrationPercent"].ToObject<float>();
            }

            public static float GetBonusMagicPenetrationPercent()
            {
                return Service.GetActivePlayerData()["championStats"]["bonusMagicPenetrationPercent"].ToObject<float>();
            }

            public static float GetCooldownReduction()
            {
                return Service.GetActivePlayerData()["championStats"]["cooldownReduction"].ToObject<float>();
            }

            public static float GetCritChance()
            {
                return Service.GetActivePlayerData()["championStats"]["critChance"].ToObject<float>();
            }

            public static float GetCritDamage()
            {
                return Service.GetActivePlayerData()["championStats"]["critDamage"].ToObject<float>();
            }

            public static float GetCurrentHealth()
            {
                return Service.GetActivePlayerData()["championStats"]["currentHealth"].ToObject<float>();
            }

            public static float GetHealthRegenRate()
            {
                return Service.GetActivePlayerData()["championStats"]["healthRegenRate"].ToObject<float>();
            }

            public static float GetLifeSteal()
            {
                return Service.GetActivePlayerData()["championStats"]["lifeSteal"].ToObject<float>();
            }

            public static float GetMagicLethality()
            {
                return Service.GetActivePlayerData()["championStats"]["magicLethality"].ToObject<float>();
            }

            public static float GetMagicPenetrationFlat()
            {
                return Service.GetActivePlayerData()["championStats"]["magicPenetrationFlat"].ToObject<float>();
            }

            public static float GetMagicPenetrationPercent()
            {
                return Service.GetActivePlayerData()["championStats"]["magicPenetrationPercent"].ToObject<float>();
            }

            public static float GetMagicResist()
            {
                return Service.GetActivePlayerData()["championStats"]["magicResist"].ToObject<float>();
            }

            public static float GetMaxHealth()
            {
                return Service.GetActivePlayerData()["championStats"]["maxHealth"].ToObject<float>();
            }

            public static float GetMoveSpeed()
            {
                return Service.GetActivePlayerData()["championStats"]["moveSpeed"].ToObject<float>();
            }

            public static float GetPhysicalLethality()
            {
                return Service.GetActivePlayerData()["championStats"]["physicalLethality"].ToObject<float>();
            }

            public static float GetResourceMax()
            {
                return Service.GetActivePlayerData()["championStats"]["resourceMax"].ToObject<float>();
            }

            public static float GetResourceRegenRate()
            {
                return Service.GetActivePlayerData()["championStats"]["resourceRegenRate"].ToObject<float>();
            }

            public static string GetResourceType()
            {
                return Service.GetActivePlayerData()["championStats"]["resourceType"].ToObject<string>();
            }

            public static float GetResourceValue()
            {
                return Service.GetActivePlayerData()["championStats"]["resourceValue"].ToObject<float>();
            }

            public static float GetSpellVamp()
            {
                return Service.GetActivePlayerData()["championStats"]["spellVamp"].ToObject<float>();
            }

            public static float GetTenacity()
            {
                return Service.GetActivePlayerData()["championStats"]["tenacity"].ToObject<float>();
            }
        }
    }
}
