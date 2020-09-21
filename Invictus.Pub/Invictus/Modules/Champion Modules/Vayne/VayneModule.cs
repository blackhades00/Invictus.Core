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
    internal class VayneModule : IChampionModule<VayneModule>
    {
        private IChampionModule<VayneModule> _championInterface;

        internal void Init()
        {
            _championInterface = new VayneModule();
            Load();
        }

        void IChampionModule<VayneModule>.QLogic()
        {
            if (LocalChampionInfo.QInstance.IsSpellReady())
                if (!Engine.CanAttack())
                {
                    Orbwalker.ResetAutoAttackTimer();
                    SpellBook.CastSpell(0x10);
                }
        }

        void IChampionModule<VayneModule>.WLogic()
        {
        }

        void IChampionModule<VayneModule>.ELogic()
        {
        }

        void IChampionModule<VayneModule>.RLogic()
        {
        }

        internal async void Load()
        {
            await Task.Run(() =>
            {
                while (true)
                    if (Utils.IsKeyPressed(Keys.Space))
                        _championInterface.QLogic();
            });
        }
    }
}