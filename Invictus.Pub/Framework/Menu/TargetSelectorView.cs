// <copyright file="TargetSelectorView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace InvictusSharp.Framework.Menu
{
    public partial class TargetSelectorView : UserControl
    {
        public TargetSelectorView()
        {
            InitializeComponent();

            this.targetSelectorMode.Text = Properties.Settings.Default.TargetSelector_Mode;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void SaveTargetSelectorSettings()
        {
            Properties.Settings.Default.Save();
        }

        private void foreverComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TargetSelector_Mode = targetSelectorMode.GetItemText(targetSelectorMode.SelectedItem);
            SaveTargetSelectorSettings();
        }
    }
}