// <copyright file="EngineStruct.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>


using System;
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


        internal static float GetAttackDelay()
        {
            return (int) (1000.0f / GetLocalObjectAttackSpeed());
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

        public static bool CanAttack()
        {
            /*
            if (Player.IsCastingInterruptableSpell())
            {
                return false;
            }
            */
            /*
            if (Player.HasBuffOfType(BuffType.Blind) && Player.CharData.BaseSkinName != "Kalista")
            {
                return false;
            }
*/
            if (GetLocalObject().GetChampionName() == "Graves")
            {
                var attackDelay = 1.0740296828d * 1000 * GetAttackDelay() - 716.2381256175d;
                if (GetGameTimeTickCount() + GetPing() >= LastAaTick + attackDelay)
                    // && Player.HasBuff("GravesBasicAttackAmmo1"))
                    return true;

                return false;
            }

            /*
            if (GetLocalObject().GetChampionName() == "Jhin")
            {
                if (Player.HasBuff("JhinPassiveReload"))    
                {
                    return false;
                }
            }
            */
            return GetGameTimeTickCount() + GetPing() + Engine.GetLocalObject().GetSpellBook().GetSpellCastInfo().GetWindupTime() >= LastAaTick + GetAttackDelay();
        }

        public static bool CanMove(float extraWindup, bool disableMissileCheck = false)
        {
            if (Orbwalker._missileLaunched && !disableMissileCheck) return true;

            var localExtraWindup = 0;
            if (GetLocalObject().GetChampionName() ==
                "Rengar" /*&& (Player.HasBuff("rengarqbase") || Player.HasBuff("rengarqemp"))*/) localExtraWindup = 200;

            return GetLocalObject().GetChampionName().Equals("Kalista")
                   || GetGameTimeTickCount() + GetPing() / 2
                   >= LastAaTick + GetAttackCastDelay() * 1000 + extraWindup + localExtraWindup;
        }
    }
}