using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invictus.Pub.Invictus.Framework.Menu;

namespace Invictus.Core.Invictus.Framework.Menu
{
    public partial class TargetSelectorView : UserControl
    {
        public TargetSelectorView()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TargetSelectorSettings.TSMode = this.targetSelectorMode.GetItemText(this.targetSelectorMode.SelectedItem);
        }
    }
}
