using System;
using System.Windows.Forms;

namespace InvictusSharp.Framework.Menu
{
    public partial class OrbView : UserControl
    {
        public OrbView()
        {
            InitializeComponent();

            this.ExtraWindupSlider.Value = (int)Properties.Settings.Default.Orbwalker_lasthitDelay;
        }

        private void OrbView_Load(object sender, EventArgs e)
        {

        }

        private void ExtraWindupSlider_ValueChanged()
        {
            Properties.Settings.Default.Orbwalker_lasthitDelay = ExtraWindupSlider.Value;
            Properties.Settings.Default.Save();
        }
    }
}
