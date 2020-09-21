using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Structures.GameEngine;

namespace Invictus.Core.Invictus.Structures.Spell_Structure
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
        internal SpellClass(int spellBookInstance ,SpellBook.SpellSlotId ID)
        {
            this.currentSpellbookInstance = spellBookInstance;
            this.spell = Utils.ReadInt(this.currentSpellbookInstance + Offsets.SpellStructs.SpellClass.SpellArray + (0x4 * (int)ID));
        }

        internal void SetSpell(SpellBook.SpellSlotId ID)
        {
            this.spell = Utils.ReadInt(this.currentSpellbookInstance + Offsets.SpellStructs.SpellClass.SpellArray + (0x4 * (int)ID));
        }

        internal int GetLevel()
        {
            return Utils.ReadInt(this.spell + Offsets.SpellStructs.SpellClass.Level);
        }

        internal float GetCooldown()
        {
            return Utils.ReadFloat(this.spell + Offsets.SpellStructs.SpellClass.Cooldown);
        }

        internal float GetCooldownExpire()
        {
            return Utils.ReadFloat(this.spell + Offsets.SpellStructs.SpellClass.CooldownExpire);
        }

        internal float GetFinalCooldownExpire()
        {
            return Utils.ReadFloat(this.spell + Offsets.SpellStructs.SpellClass.FinalCooldownExpire);
        }

        internal int GetCharges()
        {
            return Utils.ReadInt(this.spell + Offsets.SpellStructs.SpellClass.Charges);
        }

        internal bool IsSpellReady()
        {
            return GetCooldownExpire() - Engine.GetGameTime() <= 0 && GetLevel() > 0;
        }

    }
}