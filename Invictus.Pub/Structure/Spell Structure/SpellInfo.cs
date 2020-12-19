using System;
using System.Text;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;

namespace InvictusSharp.Structures.Spell_Structure
{
    public class SpellInfo
    {
        private int SpellInfoPtr_;
        public SpellInfo(int SpellInfoPtr)
        {
            this.SpellInfoPtr_ = SpellInfoPtr;
        }

        public String GetSpellName()
        {
            return Utils.ReadString(SpellInfoPtr_ + 0x18,Encoding.ASCII);
        }

        public SpellData GetSpellData()
        {
            var spellData = Utils.ReadInt(SpellInfoPtr_ + Offsets.SpellStructs.SpellData.SpellDataInstance);

            return new SpellData(spellData);
        }
    }
}