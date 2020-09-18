// <copyright file="ObjectTypeFlag.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework.UpdateService;

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    using System;
    using System.Runtime.InteropServices;

    class ObjectTypeFlag
    {
        private enum EcObjectTypeFlags
        {
            GameObject = 0x1,
            NeutralCamp = 0x2,
            DeadObject = 0x10,
            InvalidObject = 0x20,
            AiBaseCommon = 0x80,
            AttackableUnit = 0x200, //0x200, // 2048, 1024 4640
            Ai = 0x400,
            Minion = 0x800,
            Hero = 4096,//0x1000,
            Turret = 0x2000,
            Unknown0 = 0x4000,
            Missile = 0x8000,
            Unknown1 = 0x10000,
            Building = 0x20000,
            Unknown2 = 0x40000,
        };

        [DllImport("Invictus.ACD.dll")]
        private static extern bool LeagueIsObjectType(IntPtr leagueHandle, int objectPointer, int flags, int iSObjectTypeAddr);

        private static bool CompareObjectType(int obj, int a2)
        {
            return LeagueIsObjectType(Offsets.ProcessHandle, obj, a2, Offsets.Base + Offsets.EngineStruct.Functions.OIsObjectType);
        }

        internal static bool IsDeadObject(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.DeadObject);
        }

        internal static bool IsInvalidObject(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.InvalidObject);
        }

        internal static bool IsAiBaseCommon(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.AiBaseCommon);
        }

        internal static bool IsAttackable(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.AttackableUnit);
        }

        internal static bool IsAi(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Ai);
        }

        internal static bool IsMinion(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Minion);
        }

        internal static bool IsHero(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Hero);
        }

        internal static bool IsTurret(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Turret);
        }

        internal static bool IsMissile(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Missile);
        }

        internal static bool IsBuilding(int obj)
        {
            return CompareObjectType(obj, (int) EcObjectTypeFlags.Building);
        }
    }
}
