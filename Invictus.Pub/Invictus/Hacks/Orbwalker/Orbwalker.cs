// <copyright file="Orbwalker.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Pub.Invictus.GameEngine.GameObjects;
using Invictus.Pub.Invictus.Hacks.TargetSelector;
using Invictus.Pub.Invictus.LogService;
using SharpDX;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Invictus.Pub.Invictus.Hacks.Orbwalker
{
    internal class Orbwalker
    {
        internal static void Orbwalk()
        {
            DebugConsole.PrintDbgMessage("" + CGameObject.GetHealth(ObjectManager.GetTarget()));
            IssueAttack(ObjectManager.GetTarget());
        }

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        private static void IssueAttack(int obj)
        {
            System.Drawing.Point currentMousePos = Cursor.Position;

            Vector2 enemyPos = CGameObject.GetObj2DPos(obj);

            SetCursorPos((int)enemyPos.X, (int)enemyPos.Y);

        }
    }
}
