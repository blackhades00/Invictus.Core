// <copyright file="Offsets.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Invictus.Core.Invictus.Framework.UpdateService
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
            int Base = TargetProcess[0].MainModule.BaseAddress.ToInt32();

            return Base;
        }

        internal static IntPtr GetLeagueHandle()
        {
            IntPtr ProcessHandle = TargetProcess[0].Handle;

            return ProcessHandle;
        }


        internal static class StaticLists
        {
            public static readonly int OHeroList = 0x1C3B63C;
            public static readonly int OMinionList = 0x1C3D790;
            public static readonly int OTurretList = 0x34F412C;

        }

        internal static class Renderer
        {
            public static readonly int ORenderer = 0x3507670;
            public static readonly int OViewMatrix = 0x3504990;
        }

        internal static class GameObjectStruct
        {
            public static readonly int OLocalPlayer = 0x34E0280;

            public static readonly int OObjTeam = 0x4C;
            public static readonly int OObjName = 0x6C;
            public static readonly int OObjPos = 0x1d8;
            public static readonly int OObjVisibility = 0x270;
            public static readonly int OIsTargetable = 0xD30;
            public static readonly int OObjHealth = 0xDC4;
            public static readonly int OObjMaxHealth = 0xDD4;
            public static readonly int OObjChampionName = 0x312C;
            public static readonly int oAttackRange = 0x12CC;
            public static readonly int oIsAlive = 0x218;
        };

        internal static class CharInfo
        {
            public static readonly int OCharInfo = 0x1680;

            public static readonly int OBaseAttackDamage = OCharInfo + 304;
            public static readonly int OFlatPhysicalDamageMod = OCharInfo + 112;

            public static readonly int OArmor = OCharInfo + 448;
            public static readonly int OBonusArmor = OCharInfo + 464;
        };


        internal static class EngineStruct
        {
            public static readonly int OGameTime = 0x34D846C;

            internal struct Functions
            {
                public static readonly int OGetAttackCastDelay = 0x29D1A0;
                public static readonly int OIsObjectType = 0x17BA50;
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
                //Shitton of offsets gotta import
            }

            internal static class SpellCastInfo //Or ActiveSpellEntry
            {
                public const int SpellInfoInstance = 0x134; //Leads to the spellbook structs // or spellbook + 0x20?

                public const int SpellSlot = 0x0C;
                public const int MissileIndex = 0x14;
                public const int CasterName = 0x20;
                public const int SpellStartPos = 0x80;
                public const int SpellEndPos = 0x8C;

                public const int WindupTime = 0x4C0;
                public const int Cooldown = 0x4D4;
                public const int IsAutoAttack = 0x4E0;
                public const int IsSpecialAttack = 0x4E1;
                public const int CastStartTime = 0x524;
                public const int CastEndTime = 0x528;
            }
        }

    }
}
