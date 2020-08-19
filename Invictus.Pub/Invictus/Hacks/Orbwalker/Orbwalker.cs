// <copyright file="Orbwalker.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks.Orbwalker
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using global::Invictus.Core.Invictus.Framework.Input;
    using global::Invictus.Core.Invictus.Hacks.Orbwalker;
    using global::Invictus.Core.Invictus.Hacks.TargetSelector;
    using global::Invictus.Core.Invictus.Structures.GameEngine;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    internal class Orbwalker
    {
        private static Point lastMovePoint;
        private static Point Position = Point.Empty;

        internal static void Orbwalk()
        {

            if (Utils.IsKeyPressed(Keys.Space) || Utils.IsKeyPressed(Keys.X))
            {
                if (ObjectManager.GetTarget() != 0 && Engine.CanAttack())
                {
                    Point c = Cursor.Position;
                    IssueOrder(OrderType.AttackUnit, GameObject.GetObj2DPos(ObjectManager.GetTarget()));
                    Engine.LastAATick = Environment.TickCount - 30 / 2;
                    Cursor.Position = c;
                }

                if (Engine.CanMove(45f))
                    Mouse.MouseClickRight();

            }
        }

        public static void IssueOrder(OrderType Order, Point Vector2D = new Point())
        {
            if (Utils.IsGameInForeground())
            {
                switch (Order)
                {
                    case OrderType.HoldPosition:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_S);
                        break;
                    case OrderType.MoveTo:
                        if (Vector2D.X == 0 && Vector2D.Y == 0)
                        {
                            Mouse.MouseClickRight();
                            break;
                        }

                        if (Vector2D == new Point(Cursor.Position.X, Cursor.Position.Y))
                        {
                            Mouse.MouseClickRight();
                            break;
                        }

                        Mouse.MouseMove(Vector2D.X, Vector2D.Y);
                        Mouse.MouseClickRight();
                        break;
                    case OrderType.AttackUnit:
                        if (Vector2D.X == 0 && Vector2D.Y == 0)
                        {
                            Mouse.MouseMove(Cursor.Position.X, Cursor.Position.Y);
                            Mouse.MouseClickRight();
                            break;
                        }

                        Mouse.MouseMove(Vector2D.X, Vector2D.Y);
                        Mouse.MouseClickRight();
                        break;
                    case OrderType.AutoAttack:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_OPENING_BRACKETS);
                        break;
                    case OrderType.Stop:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_S);
                        break;
                }
            }
        }
    }
}
