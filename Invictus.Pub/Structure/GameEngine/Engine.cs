// <copyright file="EngineStruct.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InvictusSharp.Framework;
using InvictusSharp.Framework.API;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Structures.GameEngine
{
    internal class Engine
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
            return Utils.ReadFloat(Offsets.Base + Offsets.EngineStruct.OGameTime);
        }

        internal static int GetLocalObject()
        {
            return Utils.ReadInt(Offsets.Base + Offsets.GameObjectStruct.OLocalPlayer);
        }

        internal static int GetGameTimeTickCount()
        {
            return (int) (GetGameTime() * 1000);
        }

        internal static int GetPing()
        {
            return 30;
        }


        [DllImport("Invictus.ACD.dll")]
        private static extern float GetAttackCastDelay(IntPtr lolHandle, int attackCastDelayAddr, int obj);

        internal static float GetAttackCastDelay()
        {
            try
            {
                return GetAttackCastDelay(Offsets.ProcessHandle,
                    Offsets.Base + Offsets.EngineStruct.Functions.OGetAttackCastDelay, GetLocalObject());
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

        internal static void SetBoundingRadius()
        {
            try
            {
                BoundingRadius =
                    int.Parse(ActivePlayerData.UnitRadiusData[ActivePlayerData.GetChampionName()]["Gameplay radius"]
                        .ToString());
            }
            catch (Exception e)
            {
                Logger.Log("Couldn't parse Bounding Radius " + e.Message, Logger.eLoggerType.Fatal);
                throw;
            }
        }
    }
}