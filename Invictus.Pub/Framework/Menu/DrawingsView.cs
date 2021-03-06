// <copyright file="CoreSettingView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace InvictusSharp.Framework.Menu
{
    public partial class DrawingsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingsView"/> class.
        /// </summary>
        public DrawingsView()
        {
            InitializeComponent();

            this.ToggleAttackRangeDrawings.Checked = Properties.Settings.Default.DrawAttackRange;
            this.ToggleCooldownTracker.Checked = Properties.Settings.Default.DrawSpellCD;
            this.ToggleRecallTracker.Checked = Properties.Settings.Default.DrawRecallTracker;
            this.ToggleZoomhack.Checked = Properties.Settings.Default.DrawZoomHack;

        }

        private void DrawingsView_Load(object sender, EventArgs e)
        {
        }

        private void SaveDrawingSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
     

        private void hopeToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleAttackRangeDrawings.Checked)
                Properties.Settings.Default.DrawAttackRange = true;
            else
                Properties.Settings.Default.DrawAttackRange = false;
        }

        private void hopeToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleCooldownTracker.Checked)
                Properties.Settings.Default.DrawSpellCD = true;
            else
                Properties.Settings.Default.DrawSpellCD = false;
        }

        private void ToggleRecallTracker_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleRecallTracker.Checked)
                Properties.Settings.Default.DrawRecallTracker = true;
            else
            {
                Properties.Settings.Default.DrawRecallTracker = false;
            }
        }

        private void hopeToggle1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ToggleZoomhack.Checked)
                Properties.Settings.Default.DrawZoomHack = true;
            else
                Properties.Settings.Default.DrawZoomHack = false;
        }
    }
}
