namespace Invictus.Core.Invictus.Framework.Menu
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
            this.dreamForm1 = new ReaLTaiizor.Forms.DreamForm();
            this.SuspendLayout();
            // 
            // ExtraWindupSlider
            // 
            this.ExtraWindupSlider.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ExtraWindupSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtraWindupSlider.DrawValueString = false;
            this.ExtraWindupSlider.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.ExtraWindupSlider.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ExtraWindupSlider.JumpToMouse = false;
            this.ExtraWindupSlider.Location = new System.Drawing.Point(3, 51);
            this.ExtraWindupSlider.Maximum = 120;
            this.ExtraWindupSlider.Minimum = 0;
            this.ExtraWindupSlider.MinimumSize = new System.Drawing.Size(47, 22);
            this.ExtraWindupSlider.Name = "ExtraWindupSlider";
            this.ExtraWindupSlider.Size = new System.Drawing.Size(106, 22);
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
            this.foreverLabel1.Location = new System.Drawing.Point(3, 37);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(87, 15);
            this.foreverLabel1.TabIndex = 1;
            this.foreverLabel1.Text = "Extra Windup";
            // 
            // dreamForm1
            // 
            this.dreamForm1.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.dreamForm1.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.dreamForm1.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamForm1.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.dreamForm1.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamForm1.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dreamForm1.Location = new System.Drawing.Point(0, 0);
            this.dreamForm1.Name = "dreamForm1";
            this.dreamForm1.Size = new System.Drawing.Size(189, 347);
            this.dreamForm1.TabIndex = 2;
            this.dreamForm1.TabStop = false;
            this.dreamForm1.Text = "Invictus";
            this.dreamForm1.TitleAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dreamForm1.TitleHeight = 25;
            // 
            // OrbView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.dreamForm1);
            this.Controls.Add(this.foreverLabel1);
            this.Controls.Add(this.ExtraWindupSlider);
            this.Name = "OrbView";
            this.Size = new System.Drawing.Size(189, 347);
            this.Load += new System.EventHandler(this.OrbView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.DungeonTrackBar ExtraWindupSlider;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Forms.DreamForm dreamForm1;
    }
}
