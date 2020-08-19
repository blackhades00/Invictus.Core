// <copyright file="Draw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.Drawings
{
    using System.Windows.Forms;
    using global::Invictus.Pub.Invictus.Drawings;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;
    using Paradox.Core.Drawing;
    using SharpDX;

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

        /// <summary>
        /// Draws Champion Attack Range.
        /// </summary>
        /// <param name="rGB"></param>
        internal static void DrawAttackRange(int gameObject, Color rGB)
        {
            if(Utils.IsGameInForeground())
            DrawFactory.DrawCircleRange(GameObject.GetObj3DPos(gameObject), GameObject.GetBoundingRadius(gameObject) + GameObject.GetAttackRange(gameObject), rGB, 1.5f);
        }

        internal static void DrawCooldown(int obj)
        {
            var w2sPos = GameObject.GetObj2DPos(obj);
            DrawFactory.DrawFont("TEST", 30, new SharpDX.Point(w2sPos.X, w2sPos.Y), Color.Cyan);
        }
    }
}
