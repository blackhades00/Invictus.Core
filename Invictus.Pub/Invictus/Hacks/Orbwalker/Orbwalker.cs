// <copyright file="Orbwalker.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.Input;
using Invictus.Core.Invictus.Hacks.TargetSelector;
using Invictus.Core.Invictus.LogService;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Hacks.Orbwalker
{
    internal class Orbwalker
    {
        internal static void Orbwalk()
        {
            GameObject test = new GameObject(GameObject.Me);
            DebugConsole.PrintDbgMessage("HEALTH: " + test.GetHealth());

            if (Utils.IsKeyPressed(Keys.Space) || Utils.IsKeyPressed(Keys.X) || Utils.IsKeyPressed(Keys.V))
            {
                if (ObjectManager.GetTarget() != 0 && Engine.CanAttack() && GameObject.IsAlive(ObjectManager.GetTarget()) && GameObject.IsTargetable(ObjectManager.GetTarget()))
                {
                    Point enemyPos = GameObject.GetObj2DPos(ObjectManager.GetTarget());
                    Point c = Cursor.Position;
                    IssueOrder(OrderType.AttackUnit, enemyPos);
                    Engine.LastAaTick = Engine.GetGameTimeTickCount() + 20;

                    while (Engine.CanAttack()) Thread.Sleep(1);
                    Cursor.Position = c;
                }
                if (Engine.CanMove(90f)) IssueMove();
            }
        }

        public static void IssueOrder(OrderType order, Point vector2D = new Point())
        {
            if (Utils.IsGameInForeground())
            {
                switch (order)
                {
                    case OrderType.HoldPosition:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KeyS);
                        break;
                    case OrderType.MoveTo:
                        if (vector2D.X == 0 && vector2D.Y == 0)
                        {
                            Mouse.MouseClickRight();
                            break;
                        }

                        if (vector2D == new Point(Cursor.Position.X, Cursor.Position.Y))
                        {
                            Mouse.MouseMove(vector2D.X, vector2D.Y);
                            IssueMove();
                            break;
                        }

                        Mouse.MouseMove(vector2D.X, vector2D.Y);
                        Mouse.MouseClickRight();
                        break;
                    case OrderType.AttackUnit:
                        if (vector2D.X == 0 && vector2D.Y == 0)
                        {
                            Cursor.Position = vector2D;
                            Mouse.MouseClickRight();
                            break;
                        }

                        Cursor.Position = vector2D;
                        Thread.Sleep(3);
                        Mouse.MouseClickRight();
                        break;
                    case OrderType.AutoAttack:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KeyOpeningBrackets);
                        break;
                    case OrderType.Stop:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KeyS);
                        break;
                }
            }
        }

        private static void IssueMove()
        {
            Thread.Sleep(30);
            Mouse.MouseRightDown();
            Mouse.MouseRightUp();
        }
    }
}
