using System.Text;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using SharpDX;

namespace Invictus.Core.Invictus.Structures.Spell_Structure
{
   
    public class SpellCastInfo
    {
        private int spellCastInfoInstance { get; set; }

        internal SpellCastInfo(int spellCastInfoInstance)
        {
            this.spellCastInfoInstance = spellCastInfoInstance;
        }

        internal int GetSpellSlot()
        {
            return Utils.ReadInt(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellSlot);
        }

        internal int GetMissileIndex()
        {
            return Utils.ReadInt(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.MissileIndex);
        }

        internal string GetCasterName()
        {
            return Utils.ReadString(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.CasterName, Encoding.ASCII);
        }

        internal Vector3 GetSpellStartPos()
        {
            var x = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos);
            var y = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos + 4);
            var z = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellStartPos + 8);

            return new Vector3(x,y,z);
        }

        internal Vector3 GetSpellEndPos()
        {
            var x = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos);
            var y = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos + 4);
            var z = Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.SpellEndPos + 8);

            return new Vector3(x,y,z);
        }

        internal float GetWindupTime()
        {
            return Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.WindupTime);
        }

        internal float GetCooldown()
        {
            return Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.Cooldown);
        }

        internal bool IsAutoAttack()
        {
            return Utils.ReadBool(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.IsAutoAttack);
        }

        internal bool IsSpecialAttack()
        {
            return Utils.ReadBool(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.IsSpecialAttack);
        }

        internal float GetCastStartTime()
        {
            return Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.CastStartTime);
        }

        internal float GetCastEndTime()
        {
            return Utils.ReadFloat(this.spellCastInfoInstance + Offsets.SpellStructs.SpellCastInfo.CastEndTime);
        }
    }
}