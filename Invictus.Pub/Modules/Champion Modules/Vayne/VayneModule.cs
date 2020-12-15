using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using InvictusSharp.Callbacks;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;
using Color = SharpDX.Color;

namespace InvictusSharp.Modules.Champion_Modules.Vayne
{
    internal class VayneModule : IChampionModule
    {
        private static IChampionModule module;
        void IChampionModule.Init()
        {
            module = new VayneModule();
            module.OnDraw();
        }


        void IChampionModule.Combo()
        {

        }

        void IChampionModule.Farm()
        {
        }

        void IChampionModule.JungleClear()
        {
        }

        void IChampionModule.OnDraw()
        {
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), Engine.GetLocalObject().GetBoundingRadius(), Color.Orange, 1.5f);
        }

        void IChampionModule.OnTick()
        {

        }
    }
}