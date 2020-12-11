using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Structures.GameEngine;

namespace InvictusSharp.Structures.Spell_Structure
{
    internal class SpellClass
    {
        private int spell { get; set; }
        private int currentSpellbookInstance { get; set; }

        /// <summary>
        /// Returns a SpellClass Instance.
        /// </summary>
        /// <param name="spellBookInstance"> the SpellBook instance of the current spell</param>
        /// <param name="ID"> The SlotID of the current Spell</param>
        internal SpellClass(int spellBookInstance, SpellBook.SpellSlotId ID)
        {
            currentSpellbookInstance = spellBookInstance;
            spell = Utils.ReadInt(
                currentSpellbookInstance + 0x4 * (int) ID);
        }

        internal void SetSpell(SpellBook.SpellSlotId ID)
        {
            spell = Utils.ReadInt(
                currentSpellbookInstance + Offsets.SpellStructs.SpellClass.SpellArray + 0x4 * (int) ID);
        }

        internal int GetLevel()
        {
            return Utils.ReadInt(spell + Offsets.SpellStructs.SpellClass.Level);
        }

        internal float GetCooldown()
        {
            return Utils.ReadFloat(spell + Offsets.SpellStructs.SpellClass.Cooldown);
        }

        internal float GetCooldownExpire()
        {
            return Utils.ReadFloat(spell + Offsets.SpellStructs.SpellClass.CooldownExpire);
        }

        internal float GetFinalCooldownExpire()
        {
            return Utils.ReadFloat(spell + Offsets.SpellStructs.SpellClass.FinalCooldownExpire);
        }

        internal int GetCharges()
        {
            return Utils.ReadInt(spell + Offsets.SpellStructs.SpellClass.Charges);
        }

        internal bool IsSpellReady()
        {
            return GetCooldownExpire() - Engine.GetGameTime() <= 0 && GetLevel() > 0;
        }

        internal int GetCurrentCooldown()
        {
            return (int)(GetCooldownExpire() - Engine.GetGameTime());
        }

        internal SpellInfo GetSpellInfo()
        {
            var spellInfo = Utils.ReadInt(spell + 0x134);

            return new SpellInfo(spellInfo);
        }
    }
}