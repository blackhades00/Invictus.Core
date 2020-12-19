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
            module.OnStart();
            module.OnUpdate();
            module.OnDraw();
        }

        void IChampionModule.OnStart()
        {
            Logger.Log("Vayne Loaded",Logger.eLoggerType.Info);
        }

        void IChampionModule.OnDraw()
        {
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), Engine.GetLocalObject().GetBoundingRadius(), Color.Orange, 1.5f);
        }

        void IChampionModule.OnTick()
        {
        }

        async void IChampionModule.OnUpdate()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                   if(LocalChampionInfo.QInstance.GetCharges() == 0)
                       Logger.Log("TEST",Logger.eLoggerType.Debug);
                      
                }
            });
           
        }
    }
}