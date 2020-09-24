namespace InvictusSharp.Framework.Menu
{
    partial class OrbView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExtraWindupSlider = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.SuspendLayout();
            // 
            // ExtraWindupSlider
            // 
            this.ExtraWindupSlider.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ExtraWindupSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtraWindupSlider.DrawValueString = true;
            this.ExtraWindupSlider.EmptyBackColor = System.Drawing.Color.White;
            this.ExtraWindupSlider.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ExtraWindupSlider.JumpToMouse = false;
            this.ExtraWindupSlider.Location = new System.Drawing.Point(3, 33);
            this.ExtraWindupSlider.Maximum = 91;
            this.ExtraWindupSlider.Minimum = 0;
            this.ExtraWindupSlider.MinimumSize = new System.Drawing.Size(47, 22);
            this.ExtraWindupSlider.Name = "ExtraWindupSlider";
            this.ExtraWindupSlider.Size = new System.Drawing.Size(106, 40);
            this.ExtraWindupSlider.TabIndex = 0;
            this.ExtraWindupSlider.TabStop = false;
            this.ExtraWindupSlider.Text = "dungeonTrackBar1";
            this.ExtraWindupSlider.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ExtraWindupSlider.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ExtraWindupSlider.Value = 0;
            this.ExtraWindupSlider.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By1;
            this.ExtraWindupSlider.ValueToSet = 0F;
            this.ExtraWindupSlider.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.ExtraWindupSlider_ValueChanged);
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(3, 15);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(75, 15);
            this.foreverLabel1.TabIndex = 1;
            this.foreverLabel1.Text = "lasthit delay";
            // 
            // OrbView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.foreverLabel1);
            this.Controls.Add(this.ExtraWindupSlider);
            this.Name = "OrbView";
            this.Size = new System.Drawing.Size(232, 347);
            this.Load += new System.EventHandler(this.OrbView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.DungeonTrackBar ExtraWindupSlider;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
    }
}
