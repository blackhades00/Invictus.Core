// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.GameEngine.GameObjects
{
    using System;
    using System.Runtime.InteropServices;
    using ExSharpBase.API;
    using global::Invictus.Core.Invictus.Hacks.TargetSelector;
    using global::Invictus.Core.Invictus.Structures.GameObjects;
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

            return Vector3.Distance(vec1, vec2);
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
            return 65f;

        }

        [DllImport("Invictus.ACD.dll")]
        private static extern float GetAttackCastDelay(IntPtr LolHandle, int AttackCastDelayAddr, int Object);

        internal static float GetAttackCastDelay(int obj)
        {
            return GetAttackCastDelay(Offsets.PROCESS_HANDLE, Offsets.BASE + Offsets.oGetAttackCastDelay, obj);
        }

        internal static string GetChampionName(int obj)
        {
            return Utils.ReadString(obj + Offsets.OObjChampionName, System.Text.Encoding.ASCII);
        }

        internal static float GetBaseAD(int obj)
        {
            return Utils.ReadFloat(obj + Offsets.OObjBaseAtk);
        }

        internal static float GetBonusAD(int obj)
        {
            return Utils.ReadFloat(obj + Offsets.OObjBonusAtk);
        }

        internal static float GetTotalAD(int obj)
        {
            return GetBaseAD(obj) + GetBonusAD(obj);
        }

        internal static int GetAttackDelay(int obj)
        {
            return (int)(1000.0f / GameObject.GetAttackSpeed(GameObject.GetLocalPLayer()));
        }

        internal static float GetTotalArmor(int obj)
        {
            return Utils.ReadFloat(obj + Offsets.oTotalArmor);
        }

        internal static float GetEffectiveHealth(int target)
        {
            var resistance = GetTotalArmor(target);
            var effectiveHP = GetHealth(target);

            effectiveHP *= 1 + (resistance / 100);
            return effectiveHP;

            // return GetTotalAD(GetLocalPLayer()) * (100 / (100 + GetTotalArmor(target)));
        }

        internal static bool IsLasthitable(int obj)
        {
            return GetEffectiveHealth(obj) <= GetTotalAD(GetLocalPLayer());
        }

        internal static bool IsInRange(int obj)
        {
            return GameObject.GetDistance(obj, GameObject.GetLocalPLayer()) <= GameObject.GetAttackRange(GameObject.GetLocalPLayer());
        }

        /// <summary>
        /// Checks if the given object is alive through String comparison
        /// to a DeadChampions List given by <see cref="ObjectManager.GetDeadChampions()"/>.
        /// <return>returns true if the given objects name is != to all objects from the <see cref="ObjectManager.GetDeadChampions()"/> List.</return>
        /// </summary>
        /// <param name="obj">the object to check</param>
        /// <returns></returns>
        internal static bool IsAlive(int obj)
        {
            return GameObject.GetHealth(obj) > 0.0f && GameObject.GetHealth(obj) != 1000.0f ;
        }

        internal static bool IsEnemy(int obj)
        {
            return GetTeam(obj) != GetTeam(GetLocalPLayer());
        }

        internal static bool IsVisible(int obj)
        {
            return Utils.Read<byte>((IntPtr)(obj + Offsets.OObjVisibility)) == 1;
        }
    }
}
