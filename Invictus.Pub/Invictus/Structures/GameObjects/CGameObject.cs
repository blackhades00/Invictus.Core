// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.GameEngine.GameObjects
{
    using System;
    using global::Invictus.Pub.Invictus.Drawings;
    using SharpDX;
    using UnicornManaged;
    using UnicornManaged.Const;

    internal class CGameObject
    {
        internal static Unicorn UC = new Unicorn(Common.UC_ARCH_X86, Common.UC_MODE_32);

        internal static int GetLocalPLayer()
        {
            return Utils.ReadInt(Offsets.BASE + Offsets.OLocalPlayer);
        }

        public static Vector3 GetObj3DPos(int gameObj)
        {
            float posX = Utils.ReadFloat(gameObj + Offsets.OObjPos);
            float posY = Utils.ReadFloat(gameObj + Offsets.OObjPos + 0x4);
            float posZ = Utils.ReadFloat(gameObj + Offsets.OObjPos + 0x8);

            return new Vector3() { X = posX, Y = posY, Z = posZ };
        }

        public static float GetDistance(int obj1, int obj2)
        {
            var vec1 = GetObj3DPos(obj1);
            var vec2 = GetObj3DPos(obj2);

            var distance = (float)Math.Sqrt(Math.Pow(vec1.X - vec2.X, 2) + Math.Pow(vec1.Y - vec2.Y, 2) + Math.Pow(vec1.Z - vec2.Z, 2));
            return distance;
        }

        internal static Vector2 GetObj2DPos(int gameObject)
        {
            return Renderer.WorldToScreen(GetObj3DPos(gameObject));
        }

        internal static float GetAttackRange(int gameObject)
        {
            return Utils.ReadFloat(gameObject + Offsets.OObjAtkRange) + GetBoundingRadius(gameObject);
        }

        internal static float GetHealth(int obj)
        {
            return Utils.ReadFloat(obj + Offsets.OObjHealth);
        }

        internal static int GetTeam(int obj)
        {
            return Utils.ReadInt(obj + Offsets.OObjTeam);
        }

        internal static float GetBoundingRadius(int obj)
        {
            float boundingRadius = Utils.ReadFloat(obj + Offsets.OCharData + 0x438);

            if (boundingRadius >= 200.00f)
            {
                return 65.00f;
            }
            else
            {
                return boundingRadius;
            }
        }

        internal static bool IsInRange(int obj)
        {
            return CGameObject.GetDistance(obj, CGameObject.GetLocalPLayer()) <= CGameObject.GetAttackRange(CGameObject.GetLocalPLayer());
        }

        internal static bool IsAlive(int obj)
        {
            return GetHealth(obj) > 0f;
        }

        internal static bool IsEnemy(int obj)
        {
            return GetTeam(obj) != GetTeam(GetLocalPLayer());
        }

        internal static bool IsValidTarget(int obj)
        {
            return IsInRange(obj) && IsAlive(obj) && IsEnemy(obj) && obj != 0;
        }
    }
}
