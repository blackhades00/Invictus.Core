﻿// <copyright file="Offsets.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls.WebParts;

namespace InvictusSharp.Framework.UpdateService
{
    /// <summary>
    /// Contains all Offsets
    /// </summary>
    internal class Offsets
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesRead);

        private static Process[] TargetProcess = Process.GetProcessesByName("League of Legends");
        internal static int Base { get; set; }
        internal static IntPtr ProcessHandle { get; set; }

        internal static int GetBase()
        {
            var Base = TargetProcess[0].MainModule.BaseAddress.ToInt32();

            return Base;
        }

        internal static IntPtr GetLeagueHandle()
        {
            var ProcessHandle = TargetProcess[0].Handle;

            return ProcessHandle;
        }


        internal static class StaticLists
        {
            public static readonly int OHeroList = 0x1C549FC;
            public static readonly int OMinionList = 0x1C56B50;
            public static readonly int OTurretList = 0x34EA640;
        }

        internal static class Renderer
        {
            public static readonly int ORenderer = 0x351AAD4;
            public static readonly int OViewMatrix = 0x3517E08;
        }

        internal static class ObjectManager
        {
            public static readonly int oObjManager = 0x1C56B04; //8B 0D ? ? ? ? 89 74 24 14

            public static readonly int oGetFirst = 0x27B1E0; //8B 41 14 8B 51 18
            public static readonly int oGetNext = 0x27CD40; //E8 ? ? ? ? 8B F0 85 F6 75 E4
        }

        internal static class GameObjectStruct
        {
            public static readonly int OLocalPlayer = 0x34F36CC;

            public static readonly int OObjTeam = 0x4C;
            public static readonly int OObjName = 0x6C;
            public static readonly int oObjLevel = 0x3674;
            public static readonly int OObjPos = 0x1D8;
            public static readonly int oNetworkID = 0xCC;
            public static readonly int OObjVisibility = 0x270;
            public static readonly int OIsTargetable = 0xD30;
            public static readonly int OObjHealth = 0xDC4;
            public static readonly int OObjMaxHealth = 0xDD4;
            public static readonly int OObjChampionName = 0x3134;
            public static readonly int oBasicAttack = 0x1284;
            public static readonly int oBonusAttack = 0x1204;
            public static readonly int oAttackRange = 0x12CC;
            public static readonly int oIsAlive = 0x218;
            public static readonly int oRecallState = 0xDA4;
            public static readonly int oObjTarget = 0x3150;
        };

        internal static class CharInfo
        {
            public static readonly int OCharInfo = 0x168C;

            public static readonly int OBaseAttackDamage = OCharInfo + 304;
            public static readonly int OFlatPhysicalDamageMod = OCharInfo + 112;

            public static readonly int OArmor = OCharInfo + 448;
            public static readonly int OBonusArmor = OCharInfo + 464;
        };


        internal static class EngineStruct
        {
            public static readonly int OGameTime = 0x34EB794; //F3 0F 11 05 ? ? ? ? 8B 49

            internal struct Functions
            {
                public static readonly int OGetAttackCastDelay = 0x29D150;
                public static readonly int OIsObjectType = 0x17BBB0; //51 56 57 8B F9 33 D2 0F B6 47 58
            }
        };

        internal static class AIManager
        {
            public static readonly int OAiManager = 0x3010;

            public static readonly int OVelocity = 0x2C8;
            public static readonly int NavBegin = 0x1BC;
            public static readonly int NavEnd = 0x1C0;
            public static readonly int PassedWaypoints = 0x19C;
            public static readonly int IsMoving = 0x198;
            public static readonly int IsDashing = 0x1EC;
            public static readonly int CurrentDashSpeed = 0x1D0;
            public static readonly int TargetPos = 0x10;
            public static readonly int ServerPosition = 0x2BC;
        }

        internal static class SpellBook
        {
            public static readonly int Instance = 0x2708;
        }

        internal static class SpellStructs
        {
            internal static class SpellClass
            {
                public const int SpellArray = 0x478;

                public const int Level = 0x20;
                public const int Cooldown = 0x78;
                public const int CooldownExpire = 0x28;
                public const int FinalCooldownExpire = 0x64;
                public const int Charges = 0x58;
            }


            internal static class SpellData
            {
                public static readonly int SpellDataInstance = 0x44; //SpellCastInfoInstance + SpellDataInstance Offset

                public static readonly int MissileName = 0x58;
                public static readonly int SpellName = 0x7C;
                public static readonly int Coefficient = 0x1D4;
                public static readonly int Coefficient2 = 0x1D8;
                public static readonly int MaxHighlightTargets = 0x1DC;
                public static readonly int DelayCastOffsetPercent = 0x26C;
                public static readonly int SpellSpeed = 0x424;

            }

            internal static class SpellCastInfo //Or ActiveSpellEntry
            {
                public const int SpellInfoInstance = 0x20; //  spellbook + offset

                public const int SpellSlot = 0x0C;
                public const int MissileIndex = 0x14;
                public const int CasterName = 0x20;
                public const int SpellStartPos = 0x80;
                public const int SpellEndPos = 0x8c;

                public const int oActiveSpellTargetIndex = 0xc0;
                public const int WindupTime = 0x4C0;
                public const int Cooldown = 0x4d4;
                public const int oIsSpell = 0x4dc;
                public const int IsAutoAttack = 0x4E0;
                public const int IsSpecialAttack = 0x4E1;
                public const int ManaCost = 0x4f0;
                public const int CastStartTime = 0x10;
                public const int CastEndTime = 0x528;
            }

            internal static class MissileClient
            {
                //NOT CHANGED
                public const int oMissileSpellInfo = 0x230;
                public const int oMissileSourceIndex = 0x290;
                public const int oMissileTargetIndex = 0x2E8;
                public const int oMissileStartPos = 0x2A8;
                public const int oMissileEndPos = 0x2B4;
            }
        }
    }
}