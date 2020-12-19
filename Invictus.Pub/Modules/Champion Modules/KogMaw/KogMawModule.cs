using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputInjectorNet;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules.Vayne;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using SharpDX;

namespace InvictusSharp.Modules.Champion_Modules.KogMaw
{
    public class KogMawModule : IChampionModule
    {
        private static IChampionModule module;
        private String Mode = "Combo";
        private static float[] wRange =
        {
            0,
            130f,
            150f,
            170f,
            190f,
            210f
        };

        void IChampionModule.Init()
        {
            module = new KogMawModule();
            module.OnStart();
            module.OnUpdate();
            module.OnDraw();
        }

        void IChampionModule.OnStart()
        {
            Logger.Log("KogMaw Loaded", Logger.eLoggerType.Info);
        }

        void IChampionModule.OnDraw()
        {
            if (LocalChampionInfo.WInstance.IsSpellReady())
                DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), Engine.GetLocalObject().GetAttackRange() + wRange[LocalChampionInfo.WInstance.GetLevel()], Color.Purple, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 1175f, Color.Purple, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 1280f, Color.Purple, 1.5f);
        }

        void WLogic()
        {

            if (LocalChampionInfo.WInstance.IsSpellReady())
            {
                HeroManager heroManager = new HeroManager();
                var target = heroManager.GetLowestHPTarget(Engine.GetLocalObject().GetAttackRange() + wRange[LocalChampionInfo.WInstance.GetLevel()]);

                if (target != 0)
                    NativeImport.SendKey(0x11);
            }
        }

        void QLogic()
        {
            if (LocalChampionInfo.QInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 40)
            {
                HeroManager heroManager = new HeroManager();
                int target = heroManager.GetLowestHPTarget(1280f);


                if (target != 0)
                {
                    var pos = target.GetObj2DPos();
                    var c = Cursor.Position;

                    InjectedInputMouseInfo input = new InjectedInputMouseInfo
                    {
                        DeltaX = pos.X - c.X,
                        DeltaY = pos.Y - c.Y,
                        MouseOptions = InjectedInputMouseOptions.Move,
                    };
                    Thread.Sleep(10);
                    InputInjector.InjectMouseInput(input);
                    NativeImport.SendKey(0x10);
                    input.DeltaX = c.X - pos.X;
                    input.DeltaY = c.Y - pos.Y;
                    InputInjector.InjectMouseInput(input);

                }
            }
        }

        void QFarmLogic()
        {
            if (LocalChampionInfo.QInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 40)
            {
                MinionManager minionManager = new MinionManager();
                int target = minionManager.GetWaveclearTarget(1175f);

                if (target != 0)
                {
                    var pos = target.GetObj2DPos();
                    var c = Cursor.Position;

                    InjectedInputMouseInfo input = new InjectedInputMouseInfo
                    {
                        DeltaX = pos.X - c.X,
                        DeltaY = pos.Y - c.Y,
                        MouseOptions = InjectedInputMouseOptions.Move,
                    };
                    Thread.Sleep(10);
                    InputInjector.InjectMouseInput(input);
                    NativeImport.SendKey(0x10);
                    input.DeltaX = c.X - pos.X;
                    input.DeltaY = c.Y - pos.Y;
                    InputInjector.InjectMouseInput(input);

                }
            }
        }

        void ELogic()
        {
            if (LocalChampionInfo.EInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 70 + 10 * LocalChampionInfo.EInstance.GetLevel())
            {
                HeroManager heroManager = new HeroManager();
                int target = heroManager.GetLowestHPTarget(1280f);


                if (target != 0)
                {
                    var pos = target.GetObj2DPos();
                    var c = Cursor.Position;

                    InjectedInputMouseInfo input = new InjectedInputMouseInfo
                    {
                        DeltaX = pos.X - c.X,
                        DeltaY = pos.Y - c.Y,
                        MouseOptions = InjectedInputMouseOptions.Move,
                    };
                    Thread.Sleep(10);
                    InputInjector.InjectMouseInput(input);
                    NativeImport.SendKey(0x12);
                    input.DeltaX = c.X - pos.X;
                    input.DeltaY = c.Y - pos.Y;
                    InputInjector.InjectMouseInput(input);

                }
            }
        }

        void EFarmLogic()
        {
            if (LocalChampionInfo.EInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 70 + 10 * LocalChampionInfo.EInstance.GetLevel())
            {
                MinionManager minionManager = new MinionManager();
                int target = minionManager.GetWaveclearTarget(1280f);


                if (target != 0)
                {
                    var pos = target.GetObj2DPos();
                    var c = Cursor.Position;

                    InjectedInputMouseInfo input = new InjectedInputMouseInfo
                    {
                        DeltaX = pos.X - c.X,
                        DeltaY = pos.Y - c.Y,
                        MouseOptions = InjectedInputMouseOptions.Move,
                    };
                    Thread.Sleep(10);
                    InputInjector.InjectMouseInput(input);
                    NativeImport.SendKey(0x12);
                    input.DeltaX = c.X - pos.X;
                    input.DeltaY = c.Y - pos.Y;
                    InputInjector.InjectMouseInput(input);

                }
            }
        }

        void IChampionModule.OnTick()
        {
            if (Utils.IsKeyPressed(Keys.Space))
            {
                WLogic();
                Thread.Sleep(10);
                QLogic();
                Thread.Sleep(10);
                ELogic();
            }
            else if (Utils.IsKeyPressed(Keys.V))
            {
                WLogic();
                Thread.Sleep(20);
                QFarmLogic();
                Thread.Sleep(20);
                EFarmLogic();
            }

        }

        async void IChampionModule.OnUpdate()
        {
            await Task.Run(() =>
            {
                while (true)
                {

                }
            });

        }
    }
}