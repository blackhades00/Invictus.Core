using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.Spell_Structure;

namespace InvictusSharp.Modules.Champion_Modules.Vayne
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