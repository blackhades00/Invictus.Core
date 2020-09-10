// <copyright file="OrbwalkerView.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace Invictus.Core.Invictus.Framework.Menu
{
    public partial class OrbwalkerView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrbwalkerView"/> class.
        /// </summary>
        public OrbwalkerView()
        {
            InitializeComponent();
        }

        private void OrbwalkerView_Load(object sender, EventArgs e)
        {
            SetViewDesign();
        }

        private void SetViewDesign()
        {
        }

        private void orbExtraWindup_Scroll(object sender, EventArgs e)
        {
            OrbSettings.OrbExtraWindup = (float)orbExtraWindup.Value;
        }
    }
}
