// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.GameEngine.GameObjects
{
    using System;
    using System.Runtime.InteropServices;
    using ExSharpBase.API;
    using global::Invictus.Pub.Invictus.Drawings;
    using SharpDX;

    internal class GameObject
    {

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

        internal static System.Drawing.Point GetObj2DPos(int gameObject)
        {
            Vector2 enemyVec2 = Renderer.WorldToScreen(GetObj3DPos(gameObject));

            System.Drawing.Point enemyPos = new System.Drawing.Point((int)enemyVec2.X, (int)enemyVec2.Y);

            return enemyPos;
        }

        internal static float GetAttackSpeed(int obj)
        {
           return ActivePlayerData.ChampionStats.GetAttackSpeed();
           // return Utils.ReadFloat(obj + Offsets.oAttackSpeed);
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

            float boundingRadius = Utils.ReadFloat(obj + Offsets.OCharData + 0x1c);

            if (boundingRadius >= 200.00f)
            {
                return 65.00f;
            }
            else
            {
                return boundingRadius;
            }


        }

        [DllImport("Invictus.ACD.dll")]
        private static extern float GetAttackCastDelay(IntPtr LolHandle, int AttackCastDelayAddr, int Object);

        internal static float GetAttackCastDelay(int obj)
        {
            return GetAttackCastDelay(Offsets.PROCESS_HANDLE, Offsets.BASE + Offsets.oGetAttackCastDelay, obj);
        }

        internal static string GetChampionName(int obj)
        {
            return Utils.ReadString(obj + Offsets.OObjChampionName,System.Text.Encoding.ASCII);
        }

        [DllImport("Invictus.ACD.dll")]
        private static extern int GetAttackDelay(IntPtr LolHandle, int AttackDelayAddr, int Object);
        internal static int GetAttackDelay(int obj)
        {
             return (int)(1000.0f / GameObject.GetAttackSpeed(GameObject.GetLocalPLayer()));
        }

        internal static bool IsInRange(int obj)
        {
            return GameObject.GetDistance(obj, GameObject.GetLocalPLayer()) <= GameObject.GetAttackRange(GameObject.GetLocalPLayer());
        }

        internal static bool IsAlive(int obj)
        {
            return GetHealth(obj) > 1.0f;
        }

        internal static bool IsEnemy(int obj)
        {
            return GetTeam(obj) != GetTeam(GetLocalPLayer());
        }

        internal static bool IsVisible(int obj)
        {
            return Utils.Read<byte>(obj + Offsets.OObjVisibility) == 1;
        }
    }
}
