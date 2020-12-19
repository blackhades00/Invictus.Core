using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules.Vayne;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using SharpDX;

namespace InvictusSharp.Modules.Champion_Modules
{
    public class TwitchModule : IChampionModule
    {
        private static IChampionModule module;

        private static float[] QCosts =
        {
            0,
            75f,
            80f,
            85f,
            90f,
            95f
        };

        private static float[] WCosts =
        {
            0,
            105f,
            110f,
            115f,
            120f,
            125f
        };



        void IChampionModule.Init()
        {
            module = new TwitchModule();
            module.OnStart();
            module.OnUpdate();
            module.OnDraw();
        }

        void IChampionModule.OnStart()
        {
            Logger.Log("Twitch Loaded", Logger.eLoggerType.Info);
        }

        void IChampionModule.OnDraw()
        {
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 825f, Color.Cyan, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 1000f, Color.Green, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 423f, Color.Purple, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), Engine.GetLocalObject().GetAttackRange(), Color.Blue, 1.5f);
        }

        void IChampionModule.OnTick()
        {
            if (Utils.IsKeyPressed(Keys.Space))
            {
                if (LocalChampionInfo.QInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 40)
                {
                    NativeImport.SendKey(0x10);
                }
            }
          

        }

        async void IChampionModule.OnUpdate()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (Engine.GetLocalObject().GetSpellCastInfo().GetSpellSlot() == 0)
                    {
                        //    Orbwalker.ResetAutoAttackTimer();
                        //  Logger.Log("RESET",Logger.eLoggerType.Debug);
                    }

                }
            });

        }
    }
}
