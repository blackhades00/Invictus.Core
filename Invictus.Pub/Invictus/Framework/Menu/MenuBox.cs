// <copyright file="MenuBox.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Menu
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using global::Invictus.Pub.Modules;

    public partial class MenuBox : Form
    {
        internal static Panel MenuContentPanelExport;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBox"/> class.
        /// </summary>
        public MenuBox()
        {
            this.InitializeComponent();
        }

        private void MenuBox_Load(object sender, EventArgs e)
        {
            this.SetMenuDesign();
            MenuContentPanelExport = this.MenuContentPanel;
            IngameMenu.LoadMenuContent();
        }

        private void SetMenuDesign()
        {
            this.OrbwalkerSettingButton.FlatAppearance.BorderSize = 1;
            this.OrbwalkerSettingButton.FlatAppearance.BorderColor = Color.FromArgb(142, 95, 197);

            this.CoreSettingButton.FlatAppearance.BorderSize = 1;
            this.CoreSettingButton.FlatAppearance.BorderColor = Color.FromArgb(142, 95, 197);
        }

        private void MenuTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeImport.ReleaseCapture();
                NativeImport.SendMessage(this.Handle, NativeImport.WM_NCLBUTTONDOWN, NativeImport.HTCAPTION, 0);
            }
        }

        private void OrbwalkerSettingButton_Click(object sender, EventArgs e)
        {
            this.MenuContentPanel.Controls["OrbwalkerView"].BringToFront();
        }

        private void CoreSettingButton_Click(object sender, EventArgs e)
        {
            this.MenuContentPanel.Controls["CoreSettingView"].BringToFront();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.MenuContentPanel.Controls["TargetSelectorView"].BringToFront();
        }

        private void MenuContentPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
