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

                while (Engine.GetLocalObject() != 0)
                {
                    Utils.Unload();
                    if (Utils.IsGameInForeground())
                    {
                        // var test = Engine.GetLocalObject().GetSpellBook().GetSpellClassInstance(SpellBook.SpellSlotId.Q).GetCharges();//
                        // Logger.Log(""+test,Logger.eLoggerType.Debug);

                        
                        orbwalker.Orbwalk(objManager.GetTarget(), Properties.Settings.Default.Orbwalker_lasthitDelay);

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