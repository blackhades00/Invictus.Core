using System.Text;
using global::Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Structures.GameEngine;

namespace Invictus.Core.Invictus.Structures.Spell_Structure
{
    class SpellClass
    {
        public int CurrentSpell;

        public bool IsSpellReady()
        {
            return GetLevel() >= 1 && Engine.GetGameTime() >= GetCooldownExpire();
        }

        public string GetSpellName()
        {
            return Utils.ReadString(GetSpellData() + 0x58, Encoding.ASCII);
        }

        public int GetLevel()
        {
            return Utils.ReadInt(CurrentSpell + 0x20);
        }

        public float GetCooldown()
        {
            return Utils.ReadFloat(CurrentSpell + 0x78);
        }

        public float GetCooldownExpire()
        {
            return Utils.ReadFloat(CurrentSpell + 0x28);
        }

        public float GetFinalCooldownExpire()
        {
            return Utils.ReadFloat(CurrentSpell + 0x64);
        }

        public int GetCharges()
        {
            return Utils.ReadInt(CurrentSpell + 0x58);

            /*
             if is smite
                    {
                        if (spell->GetCharges() >= 1)
                            cooldownRemaining = spell->GetCDExpires() - LTimerModule::Get().GetGameTime();
                        else
                            cooldownRemaining = spell->GetFinalCDExpires() - LTimerModule::Get().GetGameTime();
                    }
             */
        }

        private int GetSpellInfo()
        {
            return Utils.ReadInt(CurrentSpell + 0x134);
        }

        private int GetSpellData()
        {
            return Utils.ReadInt(GetSpellInfo() + 0x44);
        }
    }
}
