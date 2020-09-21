// <copyright file="AllPlayerData.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Invictus.Core.Invictus.Framework.API.Models;

namespace Invictus.Core.Invictus.Framework.API
{
    /// <summary>
    /// AllPlayerData Class contains Information all Players readen through JsonParsing parsed from the <see cref="Service"/> Class.
    /// </summary>
    public class AllPlayerData
    {
        public static IList<PlayerData> AllPlayers => GetAllPlayers();

        public static PlayerData FirstPlayer => GetPlayerData(0);

        public static PlayerData SecondPlayer => GetPlayerData(1);

        public static PlayerData ThirdPlayer => GetPlayerData(2);

        public static PlayerData FourthPlayer => GetPlayerData(3);

        public static PlayerData FifthPlayer => GetPlayerData(4);

        public static PlayerData SixthPlayer => GetPlayerData(5);

        public static PlayerData SeventhPlayer => GetPlayerData(6);

        public static PlayerData EighthPlayer => GetPlayerData(7);

        public static PlayerData NinthPlayer => GetPlayerData(8);

        public static PlayerData TenthPlayer => GetPlayerData(9);

        public static PlayerData EleventhPlayer => GetPlayerData(10);

        public static PlayerData TwelfthPlayer => GetPlayerData(11);

        private static PlayerData GetPlayerData(int PlayerId)
        {
            var allPlayerData = Service.GetAllPlayerData();
            if (allPlayerData.Count <= PlayerId)
                throw new IndexOutOfRangeException($"player: {PlayerId} is not available");

            var PlayerData = allPlayerData[PlayerId];
            var playerData = new PlayerData()
            {
                ChampionName = PlayerData["championName"].ToString(),
                IsBot = PlayerData["isBot"].ToObject<bool>(),
                IsDead = PlayerData["isDead"].ToObject<bool>(),
                Level = PlayerData["level"].ToObject<int>(),
                RolePosition = PlayerData["position"].ToString(),
                RawChampionName = PlayerData["rawChampionName"].ToString(),
                RespawnTimer = PlayerData["respawnTimer"].ToObject<float>(),
                SkinId = PlayerData["skinID"].ToObject<int>(),
                SummonerName = PlayerData["summonerName"].ToString(),
                Team = PlayerData["team"].ToString()
            };
            return playerData;
        }

        private static IList<PlayerData> GetAllPlayers()
        {
            IList<PlayerData> allPlayersList = new List<PlayerData>();
            foreach (var playerData in Service.GetAllPlayerData())
            {
                var playerToAdd = new PlayerData()
                {
                    ChampionName = playerData["championName"].ToString(),
                    IsBot = playerData["isBot"].ToObject<bool>(),
                    IsDead = playerData["isDead"].ToObject<bool>(),
                    Level = playerData["level"].ToObject<int>(),
                    RolePosition = playerData["position"].ToString(),
                    RawChampionName = playerData["rawChampionName"].ToString(),
                    RespawnTimer = playerData["respawnTimer"].ToObject<float>(),
                    SkinId = playerData["skinID"].ToObject<int>(),
                    SummonerName = playerData["summonerName"].ToString(),
                    Team = playerData["team"].ToString()
                };
                allPlayersList.Add(playerToAdd);
            }

            return allPlayersList;
        }
    }
}