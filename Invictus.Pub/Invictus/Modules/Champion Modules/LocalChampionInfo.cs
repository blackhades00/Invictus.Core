using Invictus.Core.Invictus.Structures.AI_Manager;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Core.Invictus.Structures.Spell_Structure;

namespace Invictus.Core.Invictus.Modules.Champion_Modules
{
    public class LocalChampionInfo
    {
        /// <summary>
        /// SpellBook instance of LocalPlayer
        /// </summary>
        internal static SpellBook SpellBookInstance = GameObject.Me.GetSpellBook();

        /// <summary>
        /// SpellClass Instance for Q Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass QInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.Q);

        /// <summary>
        /// SpellClass Instance for W Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass WInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.W);

        /// <summary>
        /// SpellClass Instance for E Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass EInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.E);

        /// <summary>
        /// SpellClass Instance for R Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass RInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.R);

        /// <summary>
        /// AI Manager Instance of LocalPlayer.
        /// </summary>
        internal static AiManager AiManager = GameObject.Me.GetAiManger();
    }
}