// <copyright file="CGameObject.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using SharpDX;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.Drawings;
using Invictus.Core.Invictus.Structures.GameEngine;

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    /// <summary>
    /// The GameObject class contains everything related to GameObject class. For example Minions, Champions, Neutrals etc.
    /// </summary>
    internal class GameObject
    {
        /// <summary>
        /// The memory addreess of this GameObject.
        /// </summary>
        internal readonly int _objAddr;

        /// <summary>
        /// the Team
        /// </summary>
        internal readonly int _Team;

        /// <summary>
        /// True if GameObject is alive.
        /// </summary>
        internal readonly bool _Alive;

        /// <summary>
        /// True if GameObject is vargetable.
        /// </summary>
        internal readonly bool _Targetable;

        /// <summary>
        /// True if GameObject is visible.
        /// </summary>
        internal readonly bool _Visible;

        /// <summary>
        /// True if GameObject is in minionList but it is not a minion.
        /// </summary>
        internal readonly bool _NoMinion;

        internal GameObject(int objAddr)
        {
            this._objAddr = objAddr;

            _Team = this.GetTeam();
            _Alive = this.IsAlive();
            _Targetable = this.IsTargetable();
            _Visible = this.IsVisible();
            _NoMinion = this.IsNoMinion();
        }

        public Vector3 GetObj3DPos()
        {
            float posX = Utils.ReadFloat(this._objAddr + Offsets.GameObject.OObjPos);
            float posY = Utils.ReadFloat(this._objAddr + Offsets.GameObject.OObjPos + 0x4);
            float posZ = Utils.ReadFloat(this._objAddr + Offsets.GameObject.OObjPos + 0x8);

            return new Vector3() { X = posX, Y = posY, Z = posZ };
        }

        public float GetDistanceTo(GameObject obj)
        {
            var vec1 = this.GetObj3DPos();
            var vec2 = obj.GetObj3DPos();

            return Vector3.Distance(vec1, vec2);
        }

        internal System.Drawing.Point GetObj2DPos()
        {
            Vector2 enemyVec2 = Renderer.WorldToScreen(this.GetObj3DPos());

            System.Drawing.Point enemyPos = new System.Drawing.Point((int)enemyVec2.X, (int)enemyVec2.Y);

            return enemyPos;
        }

        internal float GetMaxHp()
        {
            return Utils.ReadFloat(this._objAddr + Offsets.GameObject.OObjMaxHealth);
        }

        internal bool IsNoMinion()
        {
            return this.GetMaxHp() == 1f || this.GetMaxHp() == 3f || this.GetMaxHp() == 4f;
        }

        internal bool IsWard()
        {
            return this.GetMaxHp() == 3f || this.GetMaxHp() == 4f;
        }

        internal float GetHealth()
        {
            return Utils.ReadFloat(this._objAddr + Offsets.GameObject.OObjHealth);
        }

        internal int GetTeam()
        {
            return Utils.ReadInt(this._objAddr + Offsets.GameObject.OObjTeam);
        }

        internal string GetChampionName()
        {
            return Utils.ReadString(this._objAddr + Offsets.GameObject.OObjChampionName, System.Text.Encoding.ASCII);
        }

        internal float GetBaseAd()
        {
            return Utils.ReadFloat(this._objAddr + Offsets.CharInfo.OBaseAttackDamage);
        }

        internal float GetBonusAd()
        {
            return Utils.ReadFloat(this._objAddr + Offsets.CharInfo.OFlatPhysicalDamageMod);
        }

        internal float GetTotalAd()
        {
            return this.GetBaseAd() + this.GetBonusAd();
        }

        internal float GetTotalArmor()
        {
            return Utils.ReadFloat(this._objAddr + Offsets.CharInfo.OArmor);
        }

        internal float GetEffectiveHealth()
        {
            var resistance = this.GetTotalArmor();
            var effectiveHp = this.GetHealth();

            effectiveHp *= 1 + (resistance / 100);
            return effectiveHp;
        }

        internal bool IsLasthitable()
        {
            return this.GetEffectiveHealth() <= this.GetTotalAd();
        }

        internal bool IsAlive()
        {
            return this.GetHealth() > 0.0f && this.GetHealth() != 0 && this.GetHealth() != 1000;
        }

        internal bool IsEnemy()
        {
            return this._Team != Engine.GetLocalPlayer()._Team;
        }

        internal bool IsVisible()
        {
            return Utils.ReadBool(this._objAddr + Offsets.GameObject.OObjVisibility);
        }

        internal bool IsTargetable()
        {
            return Utils.ReadBool(this._objAddr + Offsets.GameObject.OIsTargetable);
        }
    }
}
