// <copyright file="CoreSettingView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace Invictus.Core.Invictus.Framework.Menu
{
    public partial class CoreSettingView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreSettingView"/> class.
        /// </summary>
        public CoreSettingView()
        {
            InitializeComponent();
        }

        private void CoreSettingView_Load(object sender, EventArgs e)
        {
        }

        private void DrawAttackRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DrawAttackRangeCheckBox.Checked)
            {
                TargetSelectorSettings.DrawAttackRange = true;
            }
            else
            {
                TargetSelectorSettings.DrawAttackRange = false;
            }
        }
    }
}
