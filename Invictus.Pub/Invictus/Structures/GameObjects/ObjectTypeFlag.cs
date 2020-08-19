// <copyright file="ObjectTypeFlag.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    using global::Invictus.Pub.Invictus;
    using System;
    using System.Runtime.InteropServices;

    class ObjectTypeFlag
    {
        private enum ECObjectTypeFlags
        {
            GameObject = 0x1,
            NeutralCamp = 0x2,
            DeadObject = 0x10,
            InvalidObject = 0x20,
            AIBaseCommon = 0x80,
            AttackableUnit = 1024, //0x200, // 2048, 1024 4640
            AI = 0x400,
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
        private static extern bool LeagueIsObjectType(IntPtr leagueHandle, int ObjectPointer, int flags, int IS_OBJECT_TYPE_ADDR);

        private static bool CompareObjectType(int obj, int a2)
        {
            return LeagueIsObjectType(Offsets.PROCESS_HANDLE, obj, a2, Offsets.BASE + Offsets.oIsObjectType);
        }

        internal static bool IsDeadObject(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.DeadObject);
        }

        internal static bool IsInvalidObject(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.InvalidObject);
        }

        internal static bool IsAIBaseCommon(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.AIBaseCommon);
        }

        internal static bool IsAttackable(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.AttackableUnit);
        }

        internal static bool IsAI(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.AI);
        }

        internal static bool IsMinion(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.Minion);
        }

        
        internal static bool IsHero(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.Hero);
        }
        
        internal static bool IsTurret(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.Turret);
        }

        internal static bool IsMissile(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.Missile);
        }

        internal static bool IsBuilding(int obj)
        {
            return CompareObjectType(obj, (int)ECObjectTypeFlags.Building);
        }
    }
}
