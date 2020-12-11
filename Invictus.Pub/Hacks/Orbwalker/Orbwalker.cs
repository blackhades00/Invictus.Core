// <copyright file="Orbwalker.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Framework.Input;
using InvictusSharp.Hacks.Features;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InputInjectorNet;

namespace InvictusSharp.Hacks.Orbwalker
{

    internal class Orbwalker
    {

        public static float Windup;

        /// <summary>
        ///     The tick the most recent attack command was sent.
        /// </summary>
        public static int LastAttackCommandT;

        /// <summary>
        /// The tick the most recent move command was sent.
        /// </summary>
        public static float LastMoveCommandT;

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

        private static bool Attack = true;

        private static bool Move = true;

        private static Random rnd = new Random();

        public static void Orbwalk(
            int target,
            float extraWindup = 0f)
        {
           
            if (Utils.IsKeyPressed(Keys.Space) || Utils.IsKeyPressed(Keys.X) || Utils.IsKeyPressed(Keys.V))
            {
                if (Engine.GetGameTimeTickCount() - LastAttackCommandT < 70 + Math.Min(60, Engine.GetPing())) return; //check if it works with last aa tick



                if (target != 0 && CanAttack() )
                {

                    if (Engine.GetLocalObject().GetChampionName() != "Kalista") _missileLaunched = false;

                    var position = target.GetObj2DPos();
                    var c = Cursor.Position;

                    InjectedInputMouseInfo input = new InjectedInputMouseInfo
                    {
                        DeltaX = position.X - c.X,
                        DeltaY = position.Y - c.Y,
                        MouseOptions = InjectedInputMouseOptions.Move,
                    };


                    InputInjector.InjectMouseInput(input);
                    InjectedInputMouseInfo input2 = new InjectedInputMouseInfo
                    {
                        MouseOptions = InjectedInputMouseOptions.RightDown,
                    };
                    InjectedInputMouseInfo input3 = new InjectedInputMouseInfo
                    {
                        MouseOptions = InjectedInputMouseOptions.RightUp,
                    };
                    InputInjector.InjectMouseInput(input2);
                    Thread.Sleep(20);
                    InputInjector.InjectMouseInput(input3);
                    input.DeltaX = c.X - position.X;
                    input.DeltaY = c.Y - position.Y;
                    InputInjector.InjectMouseInput(input);


                    Engine.LastAaTick = Environment.TickCount;
                    LastMoveCommandT = Environment.TickCount + Engine.GetWindupTime();
                    _lastTarget = target;

                }

                if (CanMove(extraWindup))
                {
                    IssueMove();
                    LastMoveCommandT = Environment.TickCount + rnd.Next(50, 80);
                    Thread.Sleep(rnd.Next(20, 50));
                }


            }
        }

        internal static void ResetAutoAttackTimer()
        {
            Engine.LastAaTick = 0;
        }


        public static bool CanAttack()
        {
            return Engine.LastAaTick + Engine.GetAttackDelay() < Environment.TickCount;
        }

        public static bool CanMove(float extraWindup, bool disableMissileCheck = false)
        {
            if (Orbwalker._missileLaunched && !disableMissileCheck) return true;

            var localExtraWindup = 0;
            if (Engine.GetLocalObject().GetChampionName() ==
                "Rengar" /*&& (Player.HasBuff("rengarqbase") || Player.HasBuff("rengarqemp"))*/) localExtraWindup = 200;

            return LastMoveCommandT < Environment.TickCount;
        }

        public static void IssueOrder(OrderType order, Point vector2D = new Point())
        {
            if (Utils.IsGameInForeground())
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
                            Mouse.MoveTo(vector2D.X, vector2D.Y);
                            Mouse.MoveTo(vector2D.X, vector2D.Y);
                            Mouse.MoveTo(vector2D.X, vector2D.Y);
                            NativeImport.SendKey(0x16);
                            break;
                        }

                        Cursor.Position = vector2D;
                        NativeImport.SendKey(0x16);
                        break;
                    case OrderType.AutoAttack:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KeyOpeningBrackets);
                        break;
                    case OrderType.Stop:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KeyS);
                        break;
                }
        }

        private static void IssueMove()
        {
            Mouse.MouseRightDown();

            Mouse.MouseRightUp();
        }
    }
}