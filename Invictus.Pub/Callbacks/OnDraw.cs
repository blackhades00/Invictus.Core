// <copyright file="OnDraw.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.Features;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;
using Point = SharpDX.Point;

namespace InvictusSharp.Callbacks
{
    /// <summary>
    /// OnDraw Callback, all Drawing Functions are being called here.
    /// </summary>
    internal class OnDraw
    {
        // All drawings here!
        public void LoadCallback()
        {
            Draw.DrawMenu();
            if (Utils.IsGameInForeground())
            {
                Draw.DrawWatermark();

                if (Properties.Settings.Default.DrawAttackRange)
                    Draw.DrawAttackRange(Engine.GetLocalObject(), Color.White);

                Draw.DrawWard();

                if (Properties.Settings.Default.DrawSpellCD) Draw.DrawEnemyCooldowns();

                if (Properties.Settings.Default.DrawRecallTracker) Draw.DrawRecallTracker();

                Draw.DrawFoWTracker();

                if (AutoSmite.Loaded && Utils.IsKeyPressed(Keys.Y))
                    Draw.DrawSmite();

                if (GetChampionModule.champModule != null)
                    GetChampionModule.champModule.OnDraw();


                /*
                var currentSpell = Engine.GetLocalObject().GetSpellCastInfo();

                if (currentSpell.GetSpellEndPos() != Vector3.Zero)
                {
                    var width = currentSpell.GetSpellInfo().GetSpellData().GetSpellWidth();
                    Logger.Log("" + width, Logger.eLoggerType.Debug);

                    var test = currentSpell.GetSpellInfo().GetSpellData().GetCoefficient1();

                    var startPos = currentSpell.GetSpellStartPos();
                    var startPosW2s = Renderer.WorldToScreen(startPos);
                    var endPos = currentSpell.GetSpellEndPos();
                    var endPosW2s = Renderer.WorldToScreen(endPos);

                    DrawFactory.DrawCircleRange(startPos, 50f, Color.Orange, 1.5f);
                    DrawFactory.DrawCircleRange(endPos, 50f, Color.Orange, 1.5f);


                    DrawFactory.DrawLine(startPosW2s.X, startPosW2s.Y, endPosW2s.X, endPosW2s.Y, 1f, Color.Orange);
                    // DrawFactory.DrawLine(startPosW2s.X + width / 2, startPosW2s.Y + width / 2, endPosW2s.X + width / 2, endPosW2s.Y + width / 2, 1f, Color.White);
                    //  DrawFactory.DrawLine(startPosW2s.X, startPosW2s.Y, endPosW2s.X - width, endPosW2s.Y, 1f, Color.Red);
                }
                */
                /*
                for (int i = 0; i < OnProcessSpell.GetActiveSpells().Count; i++)
                {
                    var currentSpell = OnProcessSpell.GetActiveSpells()[i];
                    
                    if (currentSpell.GetSpellEndPos() != Vector3.Zero)
                    {
                        var width = currentSpell.GetSpellInfo().GetSpellData().GetSpellWidth();
                  //      Logger.Log(""+width,Logger.eLoggerType.Debug);

                        var startPos = currentSpell.GetSpellStartPos();
                        var startPosW2s = Renderer.WorldToScreen(startPos);

                        var endPos = currentSpell.GetSpellEndPos();
                        var endPosW2s = Renderer.WorldToScreen(endPos);
                        DrawFactory.DrawCircleRange(startPos, 50f, Color.Orange, 1.5f);
                        DrawFactory.DrawCircleRange(endPos, 50f, Color.Orange, 1.5f);

                        DrawFactory.DrawLine(startPosW2s.X, startPosW2s.Y, endPosW2s.X, endPosW2s.Y, width, Color.White);
                    }


                }
                */
            }
        }
    }
}
