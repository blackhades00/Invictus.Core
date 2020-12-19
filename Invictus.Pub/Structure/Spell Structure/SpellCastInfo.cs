using System.Text;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using SharpDX;

namespace InvictusSharp.Structures.Spell_Structure
{
    public class SpellCastInfo
    {
        private int activeSpellEntryInstance { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="activeSpellEntryInstance"></param>
        internal SpellCastInfo(int activeSpellEntryInstance)
        {
            this.activeSpellEntryInstance = activeSpellEntryInstance;
        }

        internal int GetSpellSlot()
        {
            return Utils.ReadInt(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellSlot);
        }

        /// <summary>
        /// Gets the Index from the objectManager of the current missile.
        /// </summary>
        /// <returns></returns>
        internal int GetMissileIndex()
        {
            return Utils.ReadInt(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.MissileIndex);
        }

        internal string GetCasterName()
        {
            return Utils.ReadString(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.CasterName,
                Encoding.ASCII);
        }

        internal Vector3 GetSpellStartPos()
        {
            var x = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos);
            var y = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos + 4);
            var z = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos + 8);

            return new Vector3(x, y, z);
        }

        internal Vector3 GetSpellEndPos()
        {
            var x = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos);
            var y = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos + 4);
            var z = Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos + 8);

            return new Vector3(x, y, z);
        }

        internal float GetWindupTime()
        {
            return Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.WindupTime);
        }

        internal float GetCooldown()
        {
            return Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.Cooldown);
        }

        internal bool IsAutoAttack()
        {
            return Utils.ReadBool(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.IsAutoAttack);
        }

        internal bool IsSpecialAttack()
        {
            return Utils.ReadBool(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.IsSpecialAttack);
        }

        internal float GetCastStartTime()
        {
            return Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.CastStartTime);
        }

        internal float GetCastEndTime()
        {
            return Utils.ReadFloat(activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.CastEndTime);
        }

        internal SpellInfo GetSpellInfo()
        {
            var spellInfoInstance =
                Utils.ReadInt(this.activeSpellEntryInstance + Offsets.SpellStructs.SpellCastInfo.SpellInfoPtr);

            return new SpellInfo(spellInfoInstance);
        }

    }
}