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
using InvictusSharp.Hacks.Drawings;
using Color = SharpDX.Color;

namespace InvictusSharp.Hacks.Orbwalker
{

    internal class Orbwalker
    {

        public float AAWindup;

        /// <summary>
        ///     The tick the most recent attack command was sent.
        /// </summary>
        public int LastAttackCommandT;

        /// <summary>
        /// The tick the most recent move command was sent.
        /// </summary>
        public float LastMoveCommandT;

        /// <summary>
        ///     <c>true</c> if the orbwalker will disable the next attack.
        /// </summary>
        public bool DisableNextAttack = false;

        /// <summary>
        ///     <c>true</c> if the auto attack missile was launched from the player.
        /// </summary>
        internal bool _missileLaunched;

        /// <summary>
        ///     The last target
        /// </summary>
        private int _lastTarget;

        private bool Attack = true;

        private bool Move = true;

        private Random rnd = new Random();

        public Orbwalker()
        {
            this.AAWindup = Windup.windupDict[Engine.GetLocalObject().GetChampionName()];
        }

        public void Orbwalk(
            int target,
            float extraWindup = 0f)
        {

           
            if (Utils.IsKeyPressed(Keys.Space) || Utils.IsKeyPressed(Keys.X) || Utils.IsKeyPressed(Keys.V))
            {
                // if (Engine.GetGameTimeTickCount() - LastAttackCommandT < 70 + Math.Min(60, Engine.GetPing())) return; //check if it works with last aa tick



                if (target != 0 && CanAttack())
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
                        MouseOptions = InjectedInputMouseOptions.MiddleDown,
                    };
                    InjectedInputMouseInfo input3 = new InjectedInputMouseInfo
                    {
                        MouseOptions = InjectedInputMouseOptions.MiddleUp,
                    };
                    InputInjector.InjectMouseInput(input2);
                    Thread.Sleep(30);
                    InputInjector.InjectMouseInput(input3);
                    input.DeltaX = c.X - position.X;
                    input.DeltaY = c.Y - position.Y;
                    InputInjector.InjectMouseInput(input);
                    Engine.LastAaTick = Environment.TickCount;
                    LastMoveCommandT = Environment.TickCount + GetWindupTime();
                    _lastTarget = target;

                }

                if (CanMove(extraWindup))
                {
                    IssueMove();
                    LastMoveCommandT = Environment.TickCount + rnd.Next(50, 80);
                }


            }
        }


        internal float GetAttackDelay()
        {
            return (int)(1000.0f / Engine.GetLocalObjectAttackSpeed());
            // return 1 / GetLocalObjectAttackSpeed() * 1000 ;
        }

        internal float GetWindupTime()
        {
            return (1 / Engine.GetLocalObjectAttackSpeed() * 1000) * this.AAWindup;
        }


        internal void ResetAutoAttackTimer()
        {
            Engine.LastAaTick = 0;
        }


        public bool CanAttack()
        {
            return Engine.LastAaTick + GetAttackDelay() + Engine.GetPing() / 2 < Environment.TickCount;
        }

        public bool CanMove(float extraWindup, bool disableMissileCheck = false)
        {
            return LastMoveCommandT < Environment.TickCount;
        }

        private void IssueMove()
        {
            Mouse.MouseRightDown();

            Mouse.MouseRightUp();
        }
    }
}