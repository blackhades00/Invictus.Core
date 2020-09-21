// <copyright file="Draw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Hacks.TargetSelector;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;
using Invictus.Core.Invictus.Structures.Spell_Structure;
using SharpDX;

namespace Invictus.Core.Invictus.Hacks.Drawings
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

        /// <summary>
        /// Draws Watermark.
        /// </summary>
        internal static void DrawWatermark()
        {
            var watermarkPoint = new Point();
            watermarkPoint.X = Screen.PrimaryScreen.WorkingArea.Width / 2;
            watermarkPoint.Y = Screen.PrimaryScreen.WorkingArea.Top + 10;

            DrawFactory.DrawFont("InvictusSharp", 60, watermarkPoint, Color.Red);
        }

        internal static void DrawDebugText(string debugText)
        {
            var debugTextPos = new Point();
            debugTextPos.X = Screen.PrimaryScreen.WorkingArea.Width / 2 + 20;
            debugTextPos.Y = Screen.PrimaryScreen.WorkingArea.Top + 10;
        }

        /// <summary>
        /// Draws Champion Attack Range.
        /// </summary>
        /// <param name="rGb"></param>
        internal static void DrawAttackRange(int gameObject, Color rGb)
        {
            if (Utils.IsGameInForeground())
                DrawFactory.DrawCircleRange(gameObject.GetObj3DPos(),
                    Engine.BoundingRadius + Engine.GetLocalObject().GetAttackRange(), rGb, 1.5f);
        }

        /// <summary>
        /// Draws wards (not visible ones). The colors are specified for the wardtype.
        /// Control wards have a red circle, while normal wards got a yellow one.
        /// </summary>
        internal static async void DrawWard()
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
        internal static void DrawCooldown(int obj)
        {
            var spellClassInstance = obj.GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Q);
            var cooldownExpiredQ = spellClassInstance.GetCooldownExpire() - Engine.GetGameTime() <= 0 &&
                                   spellClassInstance.GetLevel() > 0;


            spellClassInstance.SetSpell(SpellBook.SpellSlotId.W);
            var cooldownExpiredW = spellClassInstance.GetCooldownExpire() - Engine.GetGameTime() <= 0 &&
                                   spellClassInstance.GetLevel() > 0;

            spellClassInstance.SetSpell(SpellBook.SpellSlotId.E);
            var cooldownExpiredE = spellClassInstance.GetCooldownExpire() - Engine.GetGameTime() <= 0 &&
                                   spellClassInstance.GetLevel() > 0;

            spellClassInstance.SetSpell(SpellBook.SpellSlotId.R);
            var cooldownExpiredR = spellClassInstance.GetCooldownExpire() - Engine.GetGameTime() <= 0 &&
                                   spellClassInstance.GetLevel() > 0;


            var position = Point.Zero;
            ;
            if (cooldownExpiredQ)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("Q", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("Q", 30, position, Color.Red);
            }


            if (cooldownExpiredW)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("W", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 20;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("W", 30, position, Color.Red);
            }


            if (cooldownExpiredE)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 40;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("E", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 40;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("E", 30, position, Color.Red);
            }


            if (cooldownExpiredR)
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 60;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("R", 30, position, Color.Green);
            }
            else
            {
                var w2SPos = obj.GetObj2DPos();
                position.X = w2SPos.X + 60;
                position.Y = w2SPos.Y;
                DrawFactory.DrawFont("R", 30, position, Color.Red);
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
    }
}