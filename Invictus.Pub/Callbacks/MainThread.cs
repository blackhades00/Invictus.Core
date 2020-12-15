// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.Features;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Hacks.Prediction.Prediction;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;

namespace InvictusSharp.Callbacks
{
    internal class MainThread
    {

        internal static async void MainLoop()
        {
            Utils.SetZoom();
            await Task.Run(() =>
            {
                while (Engine.GetLocalObject() != 0)
                {
                    Utils.Unload();
                    if (Utils.IsGameInForeground())
                    {
                        Orbwalker.Orbwalk(ObjectManager.GetTarget(), Properties.Settings.Default.Orbwalker_lasthitDelay);
                        if (Utils.IsKeyPressed(Keys.Space))
                        {/*
                            if (Engine.GetLocalObject().GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.W)
                                .IsSpellReady())
                            {
                                var target = HeroManager.GetLowestHPTarget(3300f);
                                Logger.Log("" + target.GetChampionName(), Logger.eLoggerType.Debug);
                                var predict = SkillPrediction.GetLinePrediction(target, 3300f, 1750f, 0.4f);
                                if (predict != Vector2.Zero && target != 0)
                                {
                                    var p = Cursor.Position;
                                    Cursor.Position = new System.Drawing.Point((int)predict.X, (int)predict.Y);
                                    NativeImport.SendKey(0x11);
                                    Cursor.Position = p;
                                }

                              
                            }
                          */
                            if (GetChampionModule.champModule != null)
                            {
                                GetChampionModule.champModule.OnTick();
                            }
                        }
                        

                    }




                }
            });
        }
    }
}