// <copyright file="OrbwalkerView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Menu
{
    using System;
    using System.Windows.Forms;

    public partial class OrbwalkerView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrbwalkerView"/> class.
        /// </summary>
        public OrbwalkerView()
        {
            this.InitializeComponent();
        }

        private void OrbwalkerView_Load(object sender, EventArgs e)
        {
            this.SetViewDesign();
        }

        private void SetViewDesign()
        {
        }
    }
}
