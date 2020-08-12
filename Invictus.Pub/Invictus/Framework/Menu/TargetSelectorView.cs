// <copyright file="TargetSelectorView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Menu
{
    using System;
    using System.Windows.Forms;

    public partial class TargetSelectorView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetSelectorView"/> class.
        /// </summary>
        public TargetSelectorView()
        {
            this.InitializeComponent();
        }

        private void TargetSelectorView_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "LowestHPTarget";
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Globals.TSMode = this.comboBox1.Text;
        }
    }
}
