using Invictus.Core.Invictus.Structures.AI_Manager;
using Invictus.Core.Invictus.Structures.Spell_Structure;

namespace Invictus.Core.Invictus.Modules.Champion_Modules
{
    internal interface IChampionModule
    {
        #region properties
         SpellBook spellBookInstance { get; set; }
         SpellClass qInstance { get; set; }
         SpellClass wInstance { get; set; }
         SpellClass eInstance { get; set; }
         SpellClass rInstance { get; set; }
          AiManager aiManager { get; set; }

        #endregion

        void QLogic();

        void WLogic();

        void ELogic();

        void RLogic();
    }
}