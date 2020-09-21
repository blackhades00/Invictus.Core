// <copyright file="GameStats.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Framework.API
{
    /// <summary>
    /// The GameStats class contains information about the current game readen from the Riot Web API. Data is being parsed through a JsonParser (<see cref="Service").
    /// </summary>
    internal class GameStats
    {
        internal static string GetGameMode()
        {
            return Service.GetGameStatsData()["gameMode"].ToString();
        }

        internal static float GetGameTime()
        {
            return Service.GetGameStatsData()["gameTime"].ToObject<float>();
        }

        internal static string GetMapName()
        {
            return Service.GetGameStatsData()["mapName"].ToString();
        }

        internal static int GetMapNumber()
        {
            return Service.GetGameStatsData()["mapNumber"].ToObject<int>();
        }

        internal static string GetMapTerrain()
        {
            return Service.GetGameStatsData()["mapTerrain"].ToString();
        }
    }
}