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
            return GameStats.GetGameTime();
        }

        internal static int GetLocalObject()
        {
            return Utils.ReadInt(Offsets.Base + Offsets.GameObject.OLocalPlayer);
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
            return (int)(1000.0f / Engine.GetLocalObjectAttackSpeed());
        }

        [DllImport("Invictus.ACD.dll")]
        private static extern float GetAttackCastDelay(IntPtr lolHandle, int attackCastDelayAddr, int @object);

        internal static float GetAttackCastDelay()
        {
            try
            {
                return GetAttackCastDelay(Offsets.ProcessHandle, Offsets.Base + Offsets.Engine.Functions.OGetAttackCastDelay, GetLocalObject());
            }
            catch (Exception e)
            {
                Logger.Log("Couldn't read AttackCastDelay", Logger.eLoggerType.Error);
                throw new Exception("AttackCastDelayException");
            }

        }

        internal static float GetLocalObjectAttackSpeed()
        {
            return ActivePlayerData.ChampionStats.GetAttackSpeed();
        }


        internal static float GetLocalObjectAtkRange()
        {
            return ActivePlayerData.ChampionStats.GetAttackRange() + Engine.BoundingRadius;
        }

        internal static void SetBoundingRadius()
        {
            try
            {
                Engine.BoundingRadius = int.Parse(ActivePlayerData.UnitRadiusData[GetLocalObject().GetChampionName()]["Gameplay radius"].ToString());
            }
            catch (Exception e)
            {
                Engine.BoundingRadius = 65;
            }
        }

        internal static bool CanAttack()
        {
            if (AiManager.IsDashing(GetLocalObject()))
            {
                return false;
            }

            return GetGameTimeTickCount() + GetPing() / 2 + 25 >= LastAaTick + GetAttackDelay();
        }

        internal static bool CanMove(float extrawindup)
        {
            return GetLocalObject().GetChampionName().Contains("Kalista") || GetGameTimeTickCount() + GetPing() / 2 >= LastAaTick + GetAttackCastDelay() * 1000 + extrawindup;
        }
    }
}
