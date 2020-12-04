// <copyright file="IngameMenu.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows.Forms;
using InvictusSharp.Framework.Menu.Champ_Settings_Views;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Framework.Menu
{
    /// <summary>
    /// Renders the IngameMenu.
    /// </summary>
    internal class IngameMenu
    {
        /// <summary>
        /// Loads menu context.
        /// </summary>
        internal static void LoadMenuContent()
        {
            
            var orbView = new OrbView
            {
                Dock = DockStyle.Fill
            };
            
            var coreView = new DrawingsView
            {
                Dock = DockStyle.Fill
            };

            var targetSelectorView = new TargetSelectorView
            {
                Dock = DockStyle.Fill
            };

            switch (Engine.GetLocalObject().GetChampionName())
            {
                case "Vayne":
                    var vayneView = new VayneView
                    {
                        Dock = DockStyle.Fill
                    };
                    MenuBox.MenuContentPanelExport.Controls.Add(vayneView);
                    break;
            }

            MenuBox.MenuContentPanelExport.Controls.Add(orbView);
            MenuBox.MenuContentPanelExport.Controls.Add(coreView);
            MenuBox.MenuContentPanelExport.Controls.Add(targetSelectorView);
        }
    }
}