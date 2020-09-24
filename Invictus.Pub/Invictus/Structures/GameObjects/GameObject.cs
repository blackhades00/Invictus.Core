// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using SharpDX;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Hacks.Prediction;
using Invictus.Core.Invictus.Structures.AI_Manager;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.Spell_Structure;

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    /// <summary>
    /// The GameObjectStruct class contains everything related to GameObjectStruct class. For example Minions, Champions, Neutrals etc.
    /// Extension Class for Int.
    /// </summary>
    internal static class GameObject
    {
        internal static int Me;

        public static Vector3 GetObj3DPos(this int obj)
        {
            var posX = Utils.ReadFloat(obj + Offsets.GameObjectStruct.OObjPos);
            var posY = Utils.ReadFloat(obj + Offsets.GameObjectStruct.OObjPos + 0x4);
            var posZ = Utils.ReadFloat(obj + Offsets.GameObjectStruct.OObjPos + 0x8);

            return new Vector3() {X = posX, Y = posY, Z = posZ};
        }

        public static float GetDistance(this int obj1, int obj2)
        {
            var vec1 = obj1.GetObj3DPos();
            var vec2 = obj2.GetObj3DPos();

            return Vector3.Distance(vec1, vec2);
        }

        internal static System.Drawing.Point GetObj2DPos(this int obj)
        {
            var enemyVec2 = Renderer.WorldToScreen(obj.GetObj3DPos());

            var enemyPos = new System.Drawing.Point((int) enemyVec2.X, (int) enemyVec2.Y);

            return enemyPos;
        }

        internal static float GetMaxHp(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.GameObjectStruct.OObjMaxHealth);
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
            return obj.GetDistance(Engine.GetLocalObject()) <= Engine.GetLocalObject().GetAttackRange();
        }

        internal static bool IsAutoAttacking(this int obj)
        {
            return obj.GetSpellBook().GetSpellCastInfo().IsAutoAttack();
        }

        internal static float GetHealth(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.GameObjectStruct.OObjHealth);
        }

        private static int GetTeam(this int obj)
        {
            return Utils.ReadInt(obj + Offsets.GameObjectStruct.OObjTeam);
        }

        internal static string GetChampionName(this int obj)
        {
            return Utils.ReadString(obj + Offsets.GameObjectStruct.OObjChampionName, System.Text.Encoding.ASCII);
        }

        internal static string GetName(this int obj)
        {
            return Utils.ReadString(obj + Offsets.GameObjectStruct.OObjName, System.Text.Encoding.ASCII);
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

        internal static float GetAttackRange(this int obj)
        {
            return Utils.ReadFloat(obj + Offsets.GameObjectStruct.oAttackRange);
        }

        internal static int GetRecallState(this int obj)
        {
            return Utils.ReadInt(obj + Offsets.GameObjectStruct.oRecallState);
        }


        internal static int GetTarget(this int obj)
        {
            return Utils.ReadInt((obj + Offsets.GameObjectStruct.oObjTarget));
        }

        //Flag Checks
        internal static bool IsLasthitable(this int obj, int delay = 0)
        {
            return obj.GetEffectiveHealth() <= Engine.GetLocalObject().GetTotalAd() - Engine.GetLocalObject().GetSpellBook().GetSpellCastInfo().GetWindupTime();
        }

        internal static bool IsAlive(this int obj)
        {
            var alive = Utils.ReadInt(obj + Offsets.GameObjectStruct.oIsAlive);
            return alive % 2 == 0 && obj.GetHealth() > 0.0f;
        }

        internal static bool IsEnemy(this int obj)
        {
            return obj.GetTeam() != Engine.GetLocalObject().GetTeam();
        }

        internal static bool IsVisible(this int obj)
        {
            return Utils.ReadBool(obj + Offsets.GameObjectStruct.OObjVisibility);
        }

        internal static bool IsTargetable(this int obj)
        {
            return Utils.ReadBool(obj + Offsets.GameObjectStruct.OIsTargetable);
        }


        /// <summary>
        /// Returns an instance of the AI Manager
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal static AiManager GetAiManger(this int objectPtr)
        {
            var aiManagerInstance = Utils.DeobfuscateMember(objectPtr + Offsets.AIManager.OAiManager);

            return new AiManager(aiManagerInstance);
        }

        internal static SpellBook GetSpellBook(this int obj)
        {
            return new SpellBook(obj);
        }

    }
}