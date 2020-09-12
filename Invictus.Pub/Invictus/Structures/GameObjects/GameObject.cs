// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using SharpDX;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Structures.GameEngine;

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    /// <summary>
    /// The GameObject class contains everything related to GameObject class. For example Minions, Champions, Neutrals etc.
    /// Extension Class for Int.
    /// </summary>
    internal static class GameObject
    {
        public static Vector3 GetObj3DPos(this int obj)
        {
            float posX = Utils.ReadFloat(obj + Offsets.GameObject.OObjPos);
            float posY = Utils.ReadFloat(obj + Offsets.GameObject.OObjPos + 0x4);
            float posZ = Utils.ReadFloat(obj + Offsets.GameObject.OObjPos + 0x8);

            return new Vector3() { X = posX, Y = posY, Z = posZ };
        }

        public static float GetDistance(this int obj1, int obj2)
        {
            var vec1 = obj1.GetObj3DPos();
            var vec2 = obj2.GetObj3DPos();

            return Vector3.Distance(vec1, vec2);
        }

        internal static System.Drawing.Point GetObj2DPos(this int obj)
        {
            Vector2 enemyVec2 = Renderer.WorldToScreen(obj.GetObj3DPos());

            System.Drawing.Point enemyPos = new System.Drawing.Point((int)enemyVec2.X, (int)enemyVec2.Y);

            return enemyPos;
        }

        internal static float GetMaxHp(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.GameObject.OObjMaxHealth);
        }

        internal static bool IsNoMinion(this int obj)
        {
            return obj.GetMaxHp() == 1f || obj.GetMaxHp() == 3f || obj.GetMaxHp() == 4f;
        }

        internal static bool IsWard(this int obj)
        {
            return obj.GetMaxHp() == 3f || obj.GetMaxHp() == 4f;
        }


        internal static bool IsInRange(this int obj)
        {
            return obj.GetDistance(Engine.GetLocalObject()) <= Engine.GetLocalObjectAtkRange();
        }

        internal static float GetHealth(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.GameObject.OObjHealth);
        }

        private static int GetTeam(this int obj)
        {
            return Utils.ReadInt(obj + Offsets.GameObject.OObjTeam);
        }

        internal static string GetChampionName(this int obj)
        {
            return Utils.ReadString(obj + Offsets.GameObject.OObjChampionName, System.Text.Encoding.ASCII);
        }

        internal static string GetName(this int obj)
        {
            return Utils.ReadString(obj + Offsets.GameObject.OObjName, System.Text.Encoding.ASCII);
        }

        internal static float GetBaseAd(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.CharInfo.OBaseAttackDamage);
        }

        internal static float GetBonusAd(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.CharInfo.OFlatPhysicalDamageMod);
        }

        internal static float GetTotalAd(this int obj)
        {
            return obj.GetBaseAd() + obj.GetBonusAd();
        }

        internal static float GetTotalArmor(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.CharInfo.OArmor);
        }

        internal static float GetEffectiveHealth(this int obj)
        {
            var resistance = obj.GetTotalArmor();
            var effectiveHp = obj.GetHealth();

            effectiveHp *= 1 + (resistance / 100);
            return effectiveHp;
        }

        internal static bool IsLasthitable(this int obj)
        {
            return obj.GetEffectiveHealth() <= Engine.GetLocalObject().GetTotalAd();
        }

        internal static bool IsAlive(this int obj)
        {
            return obj.GetHealth() > 0.0f && obj.GetHealth() != 0 && obj.GetHealth() != 1000;
        }

        internal static bool IsEnemy(this int obj)
        {
            return obj.GetTeam() != Engine.GetLocalObject().GetTeam();
        }

        internal static bool IsVisible(this int obj)
        {
            return Utils.ReadBool(obj + Offsets.GameObject.OObjVisibility);
        }

        internal static bool IsTargetable(this int obj)
        {
            return Utils.ReadBool(obj + Offsets.GameObject.OIsTargetable);
        }
    }
}
