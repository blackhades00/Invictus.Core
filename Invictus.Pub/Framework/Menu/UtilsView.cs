using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvictusSharp.Framework.Menu
{
    public partial class UtilsView : UserControl
    {
        public UtilsView()
        {
            InitializeComponent();

            this.ToggleAutoSmite.Checked = Properties.Settings.Default.ToggleAutoSmite;
            this.ToggleAutoIgnite.Checked = Properties.Settings.Default.ToggleAutoIgnite;
        }

        private void ToggleAutoSmite_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleAutoSmite.Checked)
                Properties.Settings.Default.ToggleAutoSmite = true;
            else
                Properties.Settings.Default.ToggleAutoSmite = false;
        }

        private void UtilsView_Load(object sender, EventArgs e)
        {

        }

        private void SaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void ToggleAutoIgnite_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleAutoIgnite.Checked)
                Properties.Settings.Default.ToggleAutoIgnite = true;
            else
                Properties.Settings.Default.ToggleAutoIgnite = false;
        }
    }
}
