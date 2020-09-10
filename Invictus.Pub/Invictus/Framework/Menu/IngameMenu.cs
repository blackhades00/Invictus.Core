﻿// <copyright file="IngameMenu.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Windows.Forms;

namespace Invictus.Core.Invictus.Framework.Menu
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
            OrbwalkerView orbView = new OrbwalkerView
            {
                Dock = DockStyle.Fill,
            };

            CoreSettingView coreView = new CoreSettingView
            {
                Dock = DockStyle.Fill,
            };

            TargetSelectorView targetSelectorView = new TargetSelectorView
            {
                Dock = DockStyle.Fill,
            };

            MenuBox.MenuContentPanelExport.Controls.Add(orbView);
            MenuBox.MenuContentPanelExport.Controls.Add(coreView);
            MenuBox.MenuContentPanelExport.Controls.Add(targetSelectorView);
        }
    }
}
