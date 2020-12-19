using System.Linq;
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

namespace InvictusSharp.Modules.Champion_Modules.Sona
{
    public class SonaModule : IChampionModule
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
            module = new SonaModule();
            module.OnStart();
            module.OnUpdate();
            module.OnDraw();
        }

        void IChampionModule.OnStart()
        {
            Logger.Log("Sona Loaded", Logger.eLoggerType.Info);
        }

        void IChampionModule.OnDraw()
        {
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 825f, Color.Cyan, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 1000f, Color.Green, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 423f, Color.Purple, 1.5f);
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), Engine.GetLocalObject().GetAttackRange(), Color.Blue, 1.5f);
        }

        bool IsHealableAllyInRange()
        {
            HeroManager heroManager = new HeroManager();
            foreach (var ally in heroManager.GetAlliesInRange(1000f))
            {
                if (ally.GetHealth() / ally.GetMaxHp() <= 0.8f)
                    return true;
            }

            return false;
        }

        void IChampionModule.OnTick()
        {
            if (Engine.GetLocalObject().GetMana() / Engine.GetLocalObject().GetMaxMana() <= 0.3f)
                return;
            HeroManager heroManager = new HeroManager();
            var target = heroManager.GetLowestHPTarget(825f);

            if (Utils.IsKeyPressed(Keys.Space))
            {
                if (target != 0)
                {
                    if (LocalChampionInfo.QInstance.IsSpellReady() &&
                        Engine.GetLocalObject().GetMana() >= QCosts[LocalChampionInfo.QInstance.GetLevel()])
                    {
                        NativeImport.SendKey(0x10);
                    }
                }


                if (IsHealableAllyInRange())
                {
                    if (LocalChampionInfo.WInstance.IsSpellReady() &&
                        Engine.GetLocalObject().GetMana() >= WCosts[LocalChampionInfo.WInstance.GetLevel()])
                    {
                        NativeImport.SendKey(0x11);
                    }


                }

                if (heroManager.GetAlliesInRange(430f).Count >= 2)
                {
                    if (LocalChampionInfo.EInstance.IsSpellReady() && Engine.GetLocalObject().GetMana() >= 90f)
                    {
                        NativeImport.SendKey(0x12);
                    }
                }

            }

            if (Utils.IsKeyPressed(Keys.V))
            {
                MinionManager minionManager = new MinionManager();
                var waveclearTarget = minionManager.GetWaveclearTarget();
                if (waveclearTarget != 0)
                {
                    if (LocalChampionInfo.QInstance.IsSpellReady() &&
                        Engine.GetLocalObject().GetMana() >= QCosts[LocalChampionInfo.QInstance.GetLevel()])
                    {
                        NativeImport.SendKey(0x10);
                    }
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
