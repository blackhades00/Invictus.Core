// <copyright file="Draw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Runtime.InteropServices;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;

namespace InvictusSharp.Hacks.Drawings
{
    internal class Draw
    {
        /// <summary>
        /// Draws In-Game Menu.
        /// </summary>
        internal static void DrawMenu()
        {
            if (Utils.IsShiftPressed())
                Overlay.MenuBoxView.Show();
            else
                Overlay.MenuBoxView.Hide();
        }

        [DllImport("Vault7.Overlay.dll", SetLastError = true)]
        public static extern void main();

        internal static void InitVisuals()
        {
            main();
        }

        /// <summary>
        /// Draws Watermark.
        /// </summary>
        internal static void DrawWatermark()
        {
            var watermarkPoint = new Point();
            watermarkPoint.X = Screen.PrimaryScreen.WorkingArea.Width / 2;
            watermarkPoint.Y = Screen.PrimaryScreen.WorkingArea.Top + 10;

            DrawFactory.DrawFont("Vault7", 60, watermarkPoint, Color.Red);
        }

        internal static void DrawDebugText(string debugText)
        {
            var debugTextPos = new Point();
            debugTextPos.X = Screen.PrimaryScreen.WorkingArea.Width / 2 + 20;
            debugTextPos.Y = Screen.PrimaryScreen.WorkingArea.Top + 10;

            DrawFactory.DrawFont(debugText, 60, debugTextPos, Color.White);
        }

        /// <summary>
        /// Draws Champion Attack Range.
        /// </summary>
        /// <param name="rGb"></param>
        internal static void DrawAttackRange(int gameObject, Color rGb)
        {
            if (Utils.IsGameInForeground())
                DrawFactory.DrawCircleRange(gameObject.GetObj3DPos(),
                     Engine.GetLocalObject().GetAttackRange(), rGb, 1.5f);
        }

        /// <summary>
        /// Draws wards (not visible ones). The colors are specified for the wardtype.
        /// Control wards have a red circle, while normal wards got a yellow one.
        /// </summary>
        internal static void DrawWard()
        {
            var minionlist_PrePtr = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            var minionList = Utils.ReadInt(minionlist_PrePtr + 0x4);
            if (Utils.IsGameInForeground())
            {
                var index = 0x0;
                var obj = -1;
                while (obj != 0)
                {
                    obj = Utils.ReadInt(minionList + index);
                    index += 0x4;

                    if (obj == 0x00)
                    {
                        continue;
                    }
                    else
                    {
                        if (obj.IsWard())
                            if (obj.IsEnemy())
                                if (obj.IsAlive())
                                {
                                    DrawFactory.DrawCircleRange(obj.GetObj3DPos(), 60f, Color.Red, 1.5f);

                                    var w2SPos = obj.GetObj2DPos();

                                    var objectMaxHp = obj.GetMaxHp();

                                    switch (objectMaxHp)
                                    {
                                        case 3f:
                                            DrawFactory.DrawFont("Ward", 30, new Point(w2SPos.X, w2SPos.Y),
                                                Color.Yellow);
                                            break;
                                        case 4f:
                                            DrawFactory.DrawFont("Control Ward", 30, new Point(w2SPos.X, w2SPos.Y),
                                                Color.Red);
                                            break;
                                    }
                                }
                    }
                }
            }
        }

        /// <summary>
        /// Draws spell cooldowns for the given object.
        /// </summary>
        /// <param name="obj"></param>
        public static void DrawCooldown(int obj)
        {
            var cooldownExpiredQ = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Q).IsSpellReady();
            var cooldownTimeQ = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Q).GetCurrentCooldown();

            var cooldownExpiredW = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.W).IsSpellReady();
            var cooldownTimeW = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.W).GetCurrentCooldown();

            var cooldownExpiredE = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.E).IsSpellReady();
            var cooldownTimeE = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.E).GetCurrentCooldown();

            var cooldownExpiredR = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.R).IsSpellReady();
            var cooldownTimeR = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.R).GetCurrentCooldown();


            var cooldownSumm1 = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).IsSpellReady();
            var cooldownTimeSumm1 = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetCurrentCooldown();

            var cooldownSumm2 = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).IsSpellReady();
            var cooldownTimeSumm2 = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetCurrentCooldown();

            var position = Point.Zero;
            ;
            if (cooldownExpiredQ)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("Q", 30, position, Color.Green);
            }
            else if(obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Q).GetLevel() >= 1)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont(""+cooldownTimeQ, 30, position, Color.Red);
            }


            if (cooldownExpiredW)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("W", 30, position, Color.Green);
            }
            else if(obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.W).GetLevel() >= 1)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont(""+cooldownTimeW, 30, position, Color.Red);
            }


            if (cooldownExpiredE)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 40;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("E", 30, position, Color.Green);
            }
            else if(obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.E).GetLevel() >= 1)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 40;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont(""+cooldownTimeE, 30, position, Color.Red);
            }


            if (cooldownExpiredR)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 60;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("R", 30, position, Color.Green);
            }
            else if(obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.R).GetLevel() >= 1)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 60;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont(""+cooldownTimeR, 30, position, Color.Red);
            }

            if (cooldownSumm1)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y + 20;
                DrawFactory.DrawFont("D", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y + 20;
                DrawFactory.DrawFont(""+cooldownTimeSumm1/60, 30, position, Color.Red);
            }


            if (cooldownSumm2)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y + 20;
                DrawFactory.DrawFont("F", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y + 20;
                DrawFactory.DrawFont(""+cooldownTimeSumm2/60, 30, position, Color.Red);
            }

        }

        /// <summary>
        /// Draws cooldowns of enemys using the <see cref="DrawCooldown()"/> function.
        /// </summary>
        internal static void DrawEnemyCooldowns()
        {
            for (var i = 0; i < HeroManager.enemyList.Count; i++)
                if (HeroManager.enemyList[i].IsAlive() && HeroManager.enemyList[i].IsVisible())
                    DrawCooldown(HeroManager.enemyList[i]);
        }

        internal static void DrawSmite()
        {
            DrawFactory.DrawCircleRange(Engine.GetLocalObject().GetObj3DPos(), 500f, Color.Orange, 1.5f, false);
        }

        internal static void DrawRecallTracker()
        {
            for (var i = 0; i < HeroManager.enemyList.Count; i++)
                if (HeroManager.enemyList[i].IsAlive())
                {
                    if (HeroManager.enemyList[i].GetRecallState() == 6)
                    {
                        Point pos;
                        pos.X = Screen.PrimaryScreen.WorkingArea.Width / 2 - 100;
                        pos.Y = Screen.PrimaryScreen.WorkingArea.Top + 650 + i * 10;
                        DrawFactory.DrawFont(HeroManager.enemyList[i].GetChampionName() + " is Recalling", 50, pos, Color.White);
                    }
             
                }

        }

        internal static void DrawFoWTracker()
        {
            for (int i = 0; i < HeroManager.enemyList.Count; i++)
            {
                var w2s = Renderer.WorldToScreen(HeroManager.enemyList[i].GetObj3DPos());
                if (!HeroManager.enemyList[i].IsVisible())
                {
                    DrawFactory.DrawBox(w2s.X - 30f, w2s.Y - 60f, 50f, 80f, Color.Aqua);
                    Draw.DrawCooldown(HeroManager.enemyList[i]);
                    DrawFactory.DrawFont(HeroManager.enemyList[i].GetChampionName(), 50, new Point((int)w2s.X, (int)w2s.Y), Color.Aqua);
                }

            }
        }

        internal static void DrawObjectNames()
        {
            for (int i = 0; i < HeroManager.enemyList.Count; i++)
            {
                if (HeroManager.enemyList[i].IsAlive())
                {
                    Point pos;
                    pos.X = HeroManager.enemyList[i].GetObj2DPos().X;
                    pos.Y = HeroManager.enemyList[i].GetObj2DPos().Y;

                    DrawFactory.DrawFont(HeroManager.enemyList[i].GetChampionName(), 50, pos, Color.White);
                }
            }
        }
    }
}