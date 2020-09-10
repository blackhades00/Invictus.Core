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

        private static readonly Process[] TargetProcess = Process.GetProcessesByName("League of Legends");
        internal static IntPtr ProcessHandle = TargetProcess[0].Handle;
        internal static int Base = TargetProcess[0].MainModule.BaseAddress.ToInt32();



        internal static class StaticLists
        {
            public static readonly int OHeroList = 0x288E754;
            public static readonly int OMinionList = 0x288E8CC;
            public static readonly int OTurretList = 0x34F412C;

        }

        internal static class Renderer
        {
            public static readonly int ORenderer = 0x3508E90;	// 8B 15 ? ? ? ? 83 EC 08 F3 // ["blurKernelSigma", +0x27F] // xref the string, move -0x27f there should be a dword.
            public static readonly int OViewMatrix = 0x35061B0;	// B9 ? ? ? ? E8 ? ? ? ? B9 ? ? ? ? E9 ? ? ? ?
        }

        internal static class GameObject
        {
            public static readonly int OLocalPlayer = 0x34E1A34; // A1 ? ? ? ? 85 C0 74 07 05 ? ? ? ? EB 02 33 C0 56

            public static readonly int OObjTeam = 0x4C;
            public static readonly int OObjName = 0x6C;
            public static readonly int OObjPos = 0x1d8;
            public static readonly int OObjVisibility = 0x270; //0x450; // 0x39 for AI Manager
            public static readonly int OIsTargetable = 0xD30; //object + offset
            public static readonly int OObjHealth = 0xDC4;
            public static readonly int OObjMaxHealth = 0xDD4;
            public static readonly int OObjAtkRange = 0x12CC; // D8 81 ? ? ? ? 8B 81 ? ? ? ?
            public static readonly int OObjChampionName = 0x35BC;
        };

        internal static class CharData
        {
            public static readonly int oCharData = 0x2ED8;

            public static readonly int oBaseAttackSpeed = 0x1D0;
        }

        internal static class CharInfo
        {
            public static readonly int OCharInfo = 0x1680;

            public static readonly int OBaseAttackDamage = OCharInfo + 304;
            public static readonly int OFlatPhysicalDamageMod = OCharInfo + 112;

            public static readonly int OArmor = OCharInfo + 448;
            public static readonly int OBonusArmor = OCharInfo + 464;

            public static readonly int OAttackSpeedMod = OCharInfo + 256;
        };


        internal static class Engine
        {
            public static readonly int OGameTime = 0x34D9C1C;

            internal struct Functions
            {
                public static readonly int OGetAttackCastDelay = 0x29C560;
                public static readonly int OIsObjectType = 0x17BA50; // 51 56 57 8B F9 33 D2 0F B6 47 58 | find IsHero -> Decompile -> IsObjectType is being called within Ishero function
            }
          
        };

        internal static class AIManager
        {
            public static readonly int OAiManager = 0x3010;

            public static readonly int OAiManagerIsDashing = 0x398;
            public static readonly int OAiManagerIsMoving = 0x198;
        }

        internal static class SpellBook
        {
            public static readonly int Instance = 0x2B08;
        }

    }
}


/* PATTERN
 *
 *
FUNCTION, oGetAttackDelay, "8B 44 24 04 51 F3", 0
FUNCTION, oGetAttackCastDelay, "83 EC 0C 53 8B 5C 24 14 8B CB 56 57 8B 03 FF 90", 0
FUNCTION, oGetSpellState, "E8 ? ? ? ? 8B F8 8B CB 89", 0
FUNCTION, oGetBasicAttack, "53 8B D9 B8 ? ? ? ? 8B 93", 0
FUNCTION, oUpdateChargeableSpell, "E8 ? ? ? ? 8B 43 24 8B 0D ? ? ? ?", 0
FUNCTION, oGameVersion, "8B 44 24 04 BA ? ? ? ? 2B D0", 0
FUNCTION, oIsObjectType, "51 56 57 8B F9 33 D2 0F B6 47 58", 0
ADDRESS, oLocalPlayer, "A1 ? ? ? ? 85 C0 74 07 05 ? ? ? ? EB 02 33 C0 56", 1
ADDRESS, oGameTime, "F3 0F 11 05 ? ? ? ? 8B 49", 4
ADDRESS, oHudInstance, "8B 0D ? ? ? ? F3 0F 11 04 24 50 8B 49 0C E8 ? ? ? ? 83 C4 0C", 2
ADDRESS, oRenderer, "8B 15 ? ? ? ? 83 EC 08 F3", 2
ADDRESS, oNetClient, "8B 0D ? ? ? ? 85 C9 74 07 8B 01 6A 01 FF 50 08 8B", 2
ADDRESS, oGameInfo, "A1 ? ? ? ? 83 78 08 02 0F 94 C0", 1
ADDRESS, oMinionList, "8B 35 ? ? ? ? F3 0F 11 45 ?", 2
ADDRESS, oHeroList, "8B 35 ? ? ? ? 33 ED 33 DB", 2
ADDRESS, oTurretList, "8B 35 ? ? ? ? 8B 3D ? ? ? ? 3B F7 74 48", 2
ADDRESS, oViewMatrix, "b9 ? ? ? ? e8 ? ? ? ? b9 ? ? ? ? e9 ? ? ? ? cc cc cc cc cc cc cc cc", 2
OFFSET, oObjAttackRange, "D8 81 ? ? ? ? 8B 81 ? ? ? ?", 2
ADDRESS, oNetClient, "8B 0D ? ? ? ? 85 C9 74 07 8B 01 6A 01 FF 50 08 8B", 2

 *
 *
 */
