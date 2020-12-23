// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputInjectorNet;
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
using Microsoft.VisualBasic.Logging;
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
                Orbwalker orbwalker = new Orbwalker();
                ObjectManager objManager = new ObjectManager();
             //   SkillPrediction sp = new SkillPrediction();
              //  HeroManager hm = new HeroManager();
                while (Engine.GetLocalObject() != 0 && EntryPoint.init)
                {
                  //  var test = Engine.GetLocalObject().GetAiManger().IsMoving();
                   // Logger.Log("" + test, Logger.eLoggerType.Debug);
                    Utils.Unload();
                    if (Utils.IsGameInForeground())
                    {

                        orbwalker.Orbwalk(objManager.GetTarget(), Properties.Settings.Default.Orbwalker_lasthitDelay);

                        /*
                                               var pred = sp.GetLinePrediction(hm.GetLowestHPTarget(1100f), 1100f, 1900f, 0.5f);
                                               if (pred != Vector2.Zero && Utils.IsKeyPressed(Keys.Space) && LocalChampionInfo.QInstance.IsSpellReady())
                                               {
                                                   var pos = pred;
                                                   var c = Cursor.Position;

                                                   InjectedInputMouseInfo input = new InjectedInputMouseInfo
                                                   {
                                                       DeltaX = (int)pos.X - c.X,
                                                       DeltaY = (int)pos.Y - c.Y,
                                                       MouseOptions = InjectedInputMouseOptions.Move,
                                                   };
                                                   Thread.Sleep(10);
                                                   InputInjector.InjectMouseInput(input);
                                                   Thread.Sleep(30);
                                                   NativeImport.SendKey(0x10);
                                                   Thread.Sleep(30);
                                                    input.DeltaX = (int)c.X - (int)pos.X;
                                                   input.DeltaY = (int)c.Y - (int)pos.Y;
                                                   InputInjector.InjectMouseInput(input);

                                                }
                        */
                        if (GetChampionModule.champModule != null)
                        {
                            GetChampionModule.champModule.OnTick();
                        }



                    }




                }
            });
        }
    }
}