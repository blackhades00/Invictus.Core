// <copyright file="Offsets.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains all Offsets
    /// </summary>
    internal class Offsets
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
    IntPtr hProcess,
    IntPtr lpBaseAddress,
    [Out] byte[] lpBuffer,
    int dwSize,
    out IntPtr lpNumberOfBytesRead);

        private static readonly Process[] TargetProcess = Process.GetProcessesByName("League of Legends");
        internal static IntPtr PROCESS_HANDLE = TargetProcess[0].Handle;
        internal static int BASE = TargetProcess[0].MainModule.BaseAddress.ToInt32();

        public static readonly int OLocalPlayer = 0x34FF634;	// A1 ? ? ? ? 85 C0 74 07 05 ? ? ? ? EB 02 33 C0 56
        public static readonly int OObjIndex = 0x20;
        public static readonly int OObjTeam = 0x4C;
        public static readonly int OObjName = 0x6C;
        public static readonly int OObjNetworkID = 0xCC;
        public static readonly int OObjPos = 0x220; //0x1D8;
        public static readonly int OObjVisibility = 0x450; // 0x450
        public static readonly int OObjHealth = 0xFA8;
        public static readonly int OObjMaxHealth = 0xFB8;
        public static readonly int OObjArmor = 0x1464;
        public static readonly int OObjBaseAtk = 0x146C;
        public static readonly int OObjBonusAtk = 0x13EC;
        public static readonly int oTotalArmor = 0x1494;
        public static readonly int OObjMoveSpeed = 0x147C;
        public static readonly int OObjAtkRange = 0x14B4;	// D8 81 ? ? ? ? 8B 81 ? ? ? ?
        public static readonly int OObjSpellBook = 0x2AD0;
        public static readonly int OObjChampionName = 0x358C;
        public static readonly int OObjLevel = 0x4EA4;
        public static readonly int ORenderer = 0x35269A0;	// 8B 15 ? ? ? ? 83 EC 08 F3 // ["blurKernelSigma", +0x27F] // xref the string, move -0x27f there should be a dword.
        public static readonly int OViewMatrix = 0x3523CC0;	// B9 ? ? ? ? E8 ? ? ? ? B9 ? ? ? ? E9 ? ? ? ?
        public static readonly int OCharData = 0x3368;
        public static readonly int OObjManager = 0x1C5CC30;
        public static readonly int oGameTime = 0x34F7A7C;
        public static readonly int oHeroList = 0x28A8FFC;
        public static readonly int oMinionList = 0x28A915C;
        public static readonly int oTurretList = 0x34F412C;
        public static readonly int OGetFirst = 0x2BBAF0;
        public static readonly int OGetNext = 0x2BCCA0;
        public static readonly int oGetAttackCastDelay = 0x2B6360;
        public static readonly int oGetAttackDelay = 0x2B6460;
        public static readonly int oIsObjectType = 0x1898C0; // 51 56 57 8B F9 33 D2 0F B6 47 58 | find IsHero -> Decompile -> IsObjectType is being called within Ishero function
    }
}


/* PATTERN
 *
 *
FUNCTION, oGetAttackDelay, "8B 44 24 04 51 F3", 0
FUNCTION, oGetAttackCastDelay, "83 EC 0C 53 8B 5C 24 14 8B CB 56 57 8B 03 FF 90", 0
FUNCTION, oGetPing, "E8 ? ? ? ? 8B 4F 2C 85 C9 0F",0
FUNCTION, oDrawCircle, "E8 ? ? ? ? 83 C4 1C 8B 7C 24 28", 0
FUNCTION, oIsAlive, "56 8B F1 8B 06 8B 80 ? ? ? ? FF D0 84 C0 74 19", 0
FUNCTION, oIsInhib, "E8 ? ? ? ? 83 C4 04 84 C0 74 38", 0
FUNCTION, oIsNexus, "E8 ? ? ? ? 57 88 44 24 20", 0
FUNCTION, oIsTurret, "E8 ? ? ? ? 83 C4 04 84 C0 74 09 5F", 0
FUNCTION, oIsMinion, "E8 ? ? ? ? 83 C4 04 80 7F 26 06", 0
FUNCTION, oIsDragon, "83 EC 10 A1 ? ? ? ? 33 C4 89 44 24 0C 56 81 C1 ? ? ? ?", 0
FUNCTION, oIsBaron, "E8 ? ? ? ? 84 C0 74 0A BB ? ? ? ?", 0
FUNCTION, oIsHero, "E8 ? ? ? ? 83 C4 04 84 C0 74 2B", 0
FUNCTION, oIsMissile, "E8 ? ? ? ? 83 C4 04 84 C0 74 1C FF", 0
FUNCTION, oIsTargetable, "56 8B F1 E8 ? ? ? ? 84 C0 74 2E", 0
FUNCTION, oIssueOrder, "81 EC ? ? ? ? 56 57 8B F9 C7", 0
FUNCTION, oGetSpellState, "E8 ? ? ? ? 8B F8 8B CB 89", 0
FUNCTION, oCastSpell, "83 EC 38 56 8B 74 24 40", 0
FUNCTION, oGetBasicAttack, "53 8B D9 B8 ? ? ? ? 8B 93", 0
FUNCTION, oUpdateChargeableSpell, "E8 ? ? ? ? 8B 43 24 8B 0D ? ? ? ?", 0
FUNCTION, oIsNotWall, "E8 ? ? ? ? 33 C9 83 C4 0C 84", 0
FUNCTION, oGameVersion, "8B 44 24 04 BA ? ? ? ? 2B D0", 0
FUNCTION, oWorldToScreen, "83 EC 10 56 E8 ? ? ? ? 8B 08", 0
FUNCTION, oGetFirstObject, "8B 41 14 8B 51 18", 0
FUNCTION, oGetNextObject, "E8 ? ? ? ? 8B F0 85 F6 75 E4", 0
FUNCTION, oChatClientPtr, "8B 35 ? ? ? ? 52", 0
FUNCTION, oIsTroy, "53 56 8B 74 24 10 57 8B 7C 24 10 8A ", 0
ADDRESS, oLocalPlayer, "A1 ? ? ? ? 85 C0 74 07 05 ? ? ? ? EB 02 33 C0 56", 1
ADDRESS, oObjManager, "89 ? ? ? ? ? 57 C7 06 ? ? ? ? 66 C7 46 04 ? ?", 2
ADDRESS, oGameTime, "F3 0F 11 05 ? ? ? ? 8B 49", 4
ADDRESS, oHudInstance, "8B 0D ? ? ? ? F3 0F 11 04 24 50 8B 49 0C E8 ? ? ? ? 83 C4 0C", 2
ADDRESS, oRenderer, "8B 15 ? ? ? ? 83 EC 08 F3", 2
ADDRESS, oD3DRenderer, "A1 ? ? ? ? 89 54 24 18", 1
ADDRESS, oZoomClass, "A3 ? ? ? ? 83 FA 10 72 32", 1
ADDRESS, oNetClient, "8B 0D ? ? ? ? 85 C9 74 07 8B 01 6A 01 FF 50 08 8B", 2
ADDRESS, oUnderMouseObject, "8B 0D ? ? ? ? 89 0D ? ? ? ? 3B 44 24 30", 2
ADDRESS, oGameInfo, "A1 ? ? ? ? 83 78 08 02 0F 94 C0", 1
FUNCTION, oMinionList, "E8 ? ? ? ? 8B 4D 04 8B 75 08", 0
FUNCTION, oHeroList, "83 EC 34 F3 0F 10 81 ? ? ? ?", 0
ADDRESS, oViewMatrix, "B9 ? ? ? ? E8 ? ? ? ? B9 ? ? ? ? E9 ? ? ? ?", 6
OFFSET, oObjAttackRange, "D8 81 ? ? ? ? 8B 81 ? ? ? ?", 2
ADDRESS, oNetClient, "8B 0D ? ? ? ? 85 C9 74 07 8B 01 6A 01 FF 50 08 8B", 2
 *
 *
 */
