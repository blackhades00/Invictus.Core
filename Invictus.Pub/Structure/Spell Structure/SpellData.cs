using System;
using System.Runtime.CompilerServices;
using System.Text;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using SharpDX;

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
            var spellname = Utils.ReadInt(this.SpellDataInstance + Offsets.SpellStructs.SpellData.SpellName);
            return Utils.ReadString(spellname, Encoding.ASCII);
        }

        internal float GetCoefficient1()
        {
            return Utils.ReadFloat(this.SpellDataInstance + Offsets.SpellStructs.SpellData.Coefficient);
        }

        internal float GetMissileSpeed()
        {
            return Utils.ReadFloat(this.SpellDataInstance + Offsets.SpellStructs.SpellData.SpellSpeed); //or 0x410 idk
        }

        internal float GetSpellWidth()
        {
            return Utils.ReadFloat(this.SpellDataInstance + Offsets.SpellStructs.SpellData.SpellWidth);
        }

    }
}