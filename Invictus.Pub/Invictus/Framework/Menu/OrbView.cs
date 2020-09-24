using System;
using System.Windows.Forms;

namespace Invictus.Core.Invictus.Framework.Menu
{
    public partial class OrbView : UserControl
    {
        public OrbView()
        {
            InitializeComponent();

            this.ExtraWindupSlider.Value = (int)Properties.Settings.Default.Orbwalker_ExtraWindup;
        }

        private void OrbView_Load(object sender, EventArgs e)
        {

        }

        private void ExtraWindupSlider_ValueChanged()
        {
            Properties.Settings.Default.Orbwalker_ExtraWindup = ExtraWindupSlider.Value;
            Properties.Settings.Default.Save();
        }
    }
}
