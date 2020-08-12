// <copyright file="ObjectManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Structures.GameObject
{
    internal class ObjectManager
    {
        private static readonly int ObjManager = Utils.ReadInt(Offsets.BASE + Offsets.OObjManager);

        internal static int GetFirst()
        {
            return Utils.ReadInt(Offsets.BASE + Offsets.OGetFirst) + ObjManager;
        }

        internal static int GetNext(int obj)
        {
            return Utils.ReadInt(Offsets.BASE + Offsets.OGetNext) + ObjManager + obj;
        }
    }
}
