using System;
using System.Runtime.CompilerServices;
using System.Text;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;

namespace InvictusSharp.Structures.Spell_Structure
{
    public class SpellData
    {
        public int SpellDataInstance { get; set; }

        internal SpellData(int spellDataInstance)
        {
            this.SpellDataInstance = spellDataInstance;
        }

        internal String GetSpellName()
        {
            return Utils.ReadString(this.SpellDataInstance + Offsets.SpellStructs.SpellData.MissileName, Encoding.ASCII);
        }

        internal float GetCoefficient1()
        {
            return Utils.ReadFloat(this.SpellDataInstance + Offsets.SpellStructs.SpellData.Coefficient);
        }

        internal float GetMissileSpeed()
        {
            return Utils.ReadFloat(this.SpellDataInstance + 0x410);
        }

    }
}