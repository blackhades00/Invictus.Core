// <copyright file="Engine.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>


using System;
using System.Runtime.InteropServices;
using global::Invictus.Core.Invictus.Framework;
using global::Invictus.Core.Invictus.Framework.UpdateService;
using global::Invictus.Core.Invictus.Structures.AI_Manager;
using Invictus.Core.Invictus.Framework.API;
using Invictus.Core.Invictus.LogService;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Structures.GameEngine
{
    class Engine
    {
        /// <summary>
        /// Time of the last auto attack tick.
        /// </summary>
        internal static float LastAaTick = 0;

        /// <summary>
        /// BoundingRadius of LocalPlayer. Set through <see cref="SetBoundingRadius()"/> Method.
        /// </summary>
        internal static int BoundingRadius = 0;


        internal static float GetGameTime()
        {
            //return Utils.ReadFloat(Offsets.Base + Offsets.Engine.OGameTime);
            return GameStats.GetGameTime();
        }

        internal static GameObject GetLocalPlayer()
        {
            var localPlayer = Utils.ReadInt(Offsets.Base + Offsets.GameObject.OLocalPlayer);

            return new GameObject(localPlayer);
        }

        internal static int GetGameTimeTickCount()
        {
            return (int)(GetGameTime() * 1000);
        }

        internal static int GetPing()
        {
            return 30;
        }


        internal static float GetAttackDelay()
        {
            return (int)(1000.0f / Engine.GetLocalPlayerAttackSpeed());
        }

        [DllImport("Invictus.ACD.dll")]
        private static extern float GetAttackCastDelay(IntPtr lolHandle, int attackCastDelayAddr, int @object);

        internal static float GetAttackCastDelay()
        {
            try
            {
                return GetAttackCastDelay(Offsets.ProcessHandle, Offsets.Base + Offsets.Engine.Functions.OGetAttackCastDelay, GetLocalPlayer()._objAddr);
            }
            catch (Exception e)
            {
                Logger.Log("Couldn't read AttackCastDelay", Logger.eLoggerType.Error);
                throw new Exception("AttackCastDelayException");
            }

        }

        internal static float GetLocalPlayerAttackSpeed()
        {
            return ActivePlayerData.ChampionStats.GetAttackSpeed();
        }


        internal static float GetLocalPlayerAtkRange()
        {
            return ActivePlayerData.ChampionStats.GetAttackRange() + Engine.BoundingRadius;
        }


        internal bool IsInRange(GameObject obj)
        {
            return GetLocalPlayer().GetDistanceTo(obj) <= Engine.GetLocalPlayerAtkRange();
        }

        internal static void SetBoundingRadius(int obj)
        {
            try
            {
                Engine.BoundingRadius = int.Parse(ActivePlayerData.UnitRadiusData[GetLocalPlayer().GetChampionName()]["Gameplay radius"].ToString());
            }
            catch (Exception e)
            {
                Engine.BoundingRadius = 65;
            }
        }

        internal static bool CanAttack()
        {
            if (AiManager.IsDashing(GetLocalPlayer()._objAddr))
            {
                return false;
            }

            return GetGameTimeTickCount() + GetPing() / 2 + 25 >= LastAaTick + GetAttackDelay();
        }

        internal static bool CanMove(float extrawindup)
        {
            return GetLocalPlayer().GetChampionName().Contains("Kalista") || GetGameTimeTickCount() + GetPing() / 2 >= LastAaTick + GetAttackCastDelay() * 1000 + extrawindup;
        }
    }
}
