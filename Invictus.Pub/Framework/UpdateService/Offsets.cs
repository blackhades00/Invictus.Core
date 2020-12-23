// <copyright file="Offsets.cs" company="Invictus">
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

        internal static Process[] TargetProcess = Process.GetProcessesByName("League of Legends");
        internal static int Base { get; set; }
        internal static IntPtr ProcessHandle { get; set; }

        internal static int GetBase()
        {
            return TargetProcess[0].MainModule.BaseAddress.ToInt32();
        }

        internal static IntPtr GetLeagueHandle()
        {
            var ProcessHandle = TargetProcess[0].Handle;

            return ProcessHandle;
        }


        internal static class StaticLists
        {
            public static readonly int OHeroList = 0x1C5B580;
            public static readonly int OMinionList = 0x28A9C24;
            public static readonly int OTurretList = 0x34F12B8;
            public static readonly int OInhibList = 0x34FA89C;
            public static readonly int OMissileList = 0x34F848C;
        }

        internal static class Renderer
        {
            public static readonly int ORenderer = 0x3522E34;
            public static readonly int OViewMatrix = 0x3520038; //0x353DF38;
        }

        internal static class ObjectManager
        {
            public static readonly int oObjManager = 0x1C56B04; //8B 0D ? ? ? ? 89 74 24 14

            public static readonly int oGetFirst = 0x27B1E0; //8B 41 14 8B 51 18
            public static readonly int oGetNext = 0x27CD40; //E8 ? ? ? ? 8B F0 85 F6 75 E4
        }

        internal static class GameObjectStruct
        {
            public static readonly int OLocalPlayer = 0x34FA11C;

            public static readonly int OObjTeam = 0x4C;
            public static readonly int OObjName = 0x6C;
            public static readonly int oObjLevel = 0x3694;
            public static readonly int OObjPos = 0x1D8;
            public static readonly int oNetworkID = 0xCC;
            public static readonly int OObjVisibility = 0x270;
            public static readonly int OIsTargetable = 0xD00;
            public static readonly int OObjHealth = 0xD98;
            public static readonly int oObjMana = 0x298;
            public static readonly int oObjMaxMana = 0x2A8;
            public static readonly int OObjMaxHealth = 0xDA8;
            public static readonly int oObjArmor = 0x1278;
            public static readonly int OObjChampionName = 0x310C;
            public static readonly int oBasicAttack = 0x1250;
            public static readonly int oMoveSpeed = 0x1290;
            public static readonly int oBonusAttack = 0x11D0;
            public static readonly int oAttackRange = 0x1298;
            public static readonly int oIsAlive = 0x218;
            public static readonly int oRecallState = 0xD8C;
            public static readonly int oObjTarget = 0x3150;
            public static readonly int oUnitComponentInfo = 0x2F1C;
            public static readonly int oUCIProperties = 0x1C;
            public static readonly int oUnitBoundingRadius = 0x454;
        };

        internal static class EngineStruct
        {
            public static readonly int OGameTime = 0x34F22F0; //F3 0F 11 05 ? ? ? ? 8B 49
            public static readonly int oZoomClass = 0x34F21F0;
            internal struct Functions
            {
                public static readonly int OGetAttackCastDelay = 0x002a6090;
                public static readonly int OIsObjectType = 0x171280; //51 56 57 8B F9 33 D2 0F B6 47 58

                public static readonly int oUnderMouseObject = 0x1C0A160;
            }
        };

        internal static class AIManager
        {
            public static readonly int OAiManager = 0x2FF0;//0x2FF8;//0x16DB60;

            public static readonly int OVelocity = 0x2C8;
            public static readonly int NavBegin = 0x1BC;
            public static readonly int NavEnd = 0x1c0;
            public static readonly int oMoveSpeed = 0x194;
            public static readonly int PassedWaypoints = 0x19C;
            public static readonly int IsMoving = 0x198;
            public static readonly int IsDashing = 0x1EC;
            public static readonly int CurrentDashSpeed = 0x1D0;
            public static readonly int TargetPos = 0x10;
            public static readonly int ServerPosition = 0x2BC;
        }

        internal static class SpellBook
        {
            public static readonly int Instance = 0x2B60;
        }

        internal static class SpellStructs
        {
            internal static class SpellClass
            {
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
                public static readonly int SpellSpeed = 0x428;
                public static readonly int SpellWidth = 0x45C;

            }

            internal static class SpellCastInfo //Or ActiveSpellEntry
            {
                public static readonly int SpellInfoPtr = 0x8;
                public const int ActiveSpellEntryPtr = 0x2708; // 0x20  spellbook + offset

                public const int SpellSlot = 0xC;
                public const int MissileIndex = 0x14;
                public const int CasterName = 0x20;
                public const int CasterIndex = 0x6C;
                public const int SpellStartPos = 0x80;
                public const int SpellCastPos = 0x98;
                public const int SpellEndPos = 0x8c;

                public const int oActiveSpellTargetIndex = 0xc0;
                public const int WindupTime = 0x4C0;
                public const int Cooldown = 0x4d4;
                public const int oIsSpell = 0x4dc;
                public const int IsAutoAttack = 0xBC;
                public const int IsSpecialAttack = 0x4E1;
                public const int ManaCost = 0x4f0;
                public const int CastStartTime = 0x544;
                public const int CastEndTime = 0x530;
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