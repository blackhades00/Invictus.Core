// <copyright file="Draw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;
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
            {
                Overlay.MenuBoxView.Show();
            }
            else
            {
                Overlay.MenuBoxView.Hide();
            }
        }

        /// <summary>
        /// Draws Watermark.
        /// </summary>
        internal static void DrawWatermark()
        {
            Point watermarkPoint = new Point();
            watermarkPoint.X = Screen.PrimaryScreen.WorkingArea.Width / 2;
            watermarkPoint.Y = Screen.PrimaryScreen.WorkingArea.Top + 10;

            DrawFactory.DrawFont("InvictusSharp", 60, watermarkPoint, Color.Red);
        }

        internal static void DrawDebugText(string debugText)
        {
            Point debugTextPos = new Point();
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
            {
                DrawFactory.DrawCircleRange(gameObject.GetObj3DPos(), Engine.BoundingRadius + Engine.GetLocalObjectAtkRange(), rGb, 1.5f);
            }
        }
        
        /// <summary>
        /// Draws wards (not visible ones). The colors are specified for the wardtype.
        /// Control wards have a red circle, while normal wards got a yellow one.
        /// </summary>
        internal static void DrawWard()
        {


            int minionList = Utils.ReadInt(Offsets.Base + Offsets.StaticLists.OMinionList);
            if (Utils.IsGameInForeground())
            {
                int index = 0x0;
                int obj = -1;
                while (obj != 0)
                {
                    obj = Utils.ReadInt(minionList + index);
                    index += 0x4;

                    if (obj == 0x00)
                        continue;
                    else
                    {
                        if (obj.IsWard())
                        {

                            if (obj.IsEnemy())
                            {

                                if (obj.IsAlive())
                                {
                                    DrawFactory.DrawCircleRange(obj.GetObj3DPos(), 60f, Color.Red, 1.5f);

                                    var w2SPos = obj.GetObj2DPos();

                                    float objectMaxHp = obj.GetMaxHp();

                                    switch (objectMaxHp)
                                    {
                                        case 3f:
                                            DrawFactory.DrawFont("Ward", 30, new Point(w2SPos.X, w2SPos.Y), Color.Yellow);
                                            break;
                                        case 4f:
                                            DrawFactory.DrawFont("Control Ward", 30, new Point(w2SPos.X, w2SPos.Y), Color.Red);
                                            break;
                                    }
                                }
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
            var w2SPos = obj.GetObj2DPos();
            DrawFactory.DrawFont("TEST", 30, new Point(w2SPos.X, w2SPos.Y), Color.Cyan);
        }
    }
}
