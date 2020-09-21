// <copyright file="MenuBox.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Drawing;
using System.Windows.Forms;
using ReaLTaiizor;
namespace Invictus.Core.Invictus.Framework.Menu
{
    public partial class MenuBox : Form
    {
        internal static Panel MenuContentPanelExport;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBox"/> class.
        /// </summary>
        public MenuBox()
        {
            InitializeComponent();
        }

        private void MenuBox_Load(object sender, EventArgs e)
        {
            SetMenuDesign();
            MenuContentPanelExport = MenuContentPanel;
            IngameMenu.LoadMenuContent();
        }

        private void SetMenuDesign()
        {
            OrbwalkerSettingButton.FlatAppearance.BorderSize = 1;
            OrbwalkerSettingButton.FlatAppearance.BorderColor = Color.FromArgb(142, 95, 197);

            CoreSettingButton.FlatAppearance.BorderSize = 1;
            CoreSettingButton.FlatAppearance.BorderColor = Color.FromArgb(142, 95, 197);
        }

        private void MenuTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeImport.ReleaseCapture();
                NativeImport.SendMessage(Handle, NativeImport.WM_NCLBUTTONDOWN, NativeImport.HTCAPTION, 0);
            }
        }

        private void OrbwalkerSettingButton_Click(object sender, EventArgs e)
        {
            MenuContentPanel.Controls["OrbView"].BringToFront();
        }

        private void CoreSettingButton_Click(object sender, EventArgs e)
        {
            MenuContentPanel.Controls["DrawingsView"].BringToFront();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuContentPanel.Controls["TargetSelectorView"].BringToFront();
        }

        private void SideMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}