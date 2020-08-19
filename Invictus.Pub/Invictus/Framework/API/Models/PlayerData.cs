// <copyright file="PlayerData.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace ExSharpBase.API.Models
{
    using System.Collections.Generic;

    public class PlayerData
    {
        public string ChampionName { get; set; }

        public bool IsBot { get; set; }

        public bool IsDead { get; set; }

        public int Level { get; set; }

        public string RolePosition { get; set; }

        public string RawChampionName { get; set; }

        public float RespawnTimer { get; set; }

        public int SkinID { get; set; }

        public string SummonerName { get; set; }

        public string Team { get; set; }

        public IList<Item> Items { get; set; }
    }
}
