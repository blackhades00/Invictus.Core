using System.Threading.Tasks;
using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Hacks.Orbwalker;
using Invictus.Core.Invictus.Structures.AI_Manager;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Core.Invictus.Structures.Spell_Structure;

namespace Invictus.Core.Invictus.Modules.Champion_Modules
{
    internal class VayneModule : IChampionModule
    {
        public SpellBook spellBookInstance { get; set; }
        public SpellClass qInstance { get; set; }
        public SpellClass wInstance { get; set; }
        public SpellClass eInstance { get; set; }
        public SpellClass rInstance { get; set; }
        public AiManager aiManager { get; set; }

        private IChampionModule championInterface;

        internal void Init()
        {
            this.championInterface = new VayneModule();

            this.spellBookInstance = GameObject.Me.GetSpellBook();
            this.qInstance = this.spellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.Q);
            this.wInstance = this.spellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.W);
            this.eInstance = this.spellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.E);
            this.rInstance = this.spellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.R);

            championInterface.aiManager = GameObject.Me.GetAiManger();

            Load();
        }

        void IChampionModule.QLogic()
        {
            if (this.qInstance.IsSpellReady())
            {
                SpellBook.CastSpell(0x10);

                if (championInterface.aiManager.GetNavEnd() == GameObject.Me.GetObj3DPos())
                    Orbwalker.ResetAutoAttackTimer();
            }
        }

        void IChampionModule.WLogic()
        {

        }

        void IChampionModule.ELogic()
        {

        }

        void IChampionModule.RLogic()
        {

        }

        internal async void Load()
        {
            await Task.Run(() =>
             {
                 while (true)
                 {
                     if (Utils.IsKeyPressed(Keys.Space))
                     {
                         championInterface.QLogic();

                     }

                 }
             });


        }
    }
}