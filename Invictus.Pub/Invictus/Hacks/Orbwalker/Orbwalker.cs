// <copyright file="Orbwalker.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.Input;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;


namespace Invictus.Core.Invictus.Hacks.Orbwalker
{
    internal class Orbwalker
    {
        /// <summary>
        ///     The tick the most recent attack command was sent.
        /// </summary>
        public static int LastAttackCommandT;

        /// <summary>
        ///     <c>true</c> if the orbwalker will attack.
        /// </summary>
        public static bool Attack = true;

        /// <summary>
        ///     <c>true</c> if the orbwalker will move.
        /// </summary>
        public static bool Move = true;

        /// <summary>
        ///     <c>true</c> if the orbwalker will disable the next attack.
        /// </summary>
        public static bool DisableNextAttack = false;

        /// <summary>
        ///     <c>true</c> if the auto attack missile was launched from the player.
        /// </summary>
        internal static bool _missileLaunched;

        /// <summary>
        ///     The last target
        /// </summary>
        private static int _lastTarget;



        public static void Orbwalk(
            int target,
            float extraWindup = 90)
        {
            if (Utils.IsKeyPressed(Keys.Space) || Utils.IsKeyPressed(Keys.X) || Utils.IsKeyPressed(Keys.V))
            {

                if (Engine.GetGameTimeTickCount() - LastAttackCommandT < 70 + Math.Min(60, Engine.GetPing()))
                {
                    return;
                }

                try
                {
                    if (target != 0 && Engine.CanAttack() && Attack)
                    {
                        DisableNextAttack = false;
                        //FireBeforeAttack(target);

                        

                        if (!DisableNextAttack)
                        {
                            if (Engine.GetLocalObject().GetChampionName() != "Kalista")
                            {
                                _missileLaunched = false;
                            }

                            Point position = target.GetObj2DPos();
                            Point c = Cursor.Position;
                            IssueOrder(OrderType.AttackUnit, position);
                        
                            LastAttackCommandT = Engine.GetGameTimeTickCount();
                            _lastTarget = target;
                            Engine.LastAaTick = Engine.GetGameTimeTickCount() + Engine.GetPing();
                            while(Engine.CanAttack()) Thread.Sleep(1);
                            Cursor.Position = c;
                            Attack = false;
                            Move = true;

                        }
                    }

                    if (Engine.CanMove(extraWindup) && Move)
                    {
                        IssueMove();
                        Attack = true;
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

          
        }

        internal static void ResetAutoAttackTimer()
        {
            Engine.LastAaTick = 0;
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

                        NativeImport.SetCursorPos(vector2D.X, vector2D.Y);
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
            NativeImport.SendKey(0x50);
            Mouse.MouseRightDown();
            NativeImport.SendKey(0x50);
            Mouse.MouseRightUp();

        }
    }
}
