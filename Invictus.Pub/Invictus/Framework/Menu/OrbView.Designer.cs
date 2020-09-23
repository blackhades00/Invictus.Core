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
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.OrbwalkerMenu = new ReaLTaiizor.Forms.DreamForm();
            this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            this.ExtraWindupSlider = new ReaLTaiizor.Controls.ForeverTrackBar();
            this.OrbwalkerMenu.SuspendLayout();
            this.SuspendLayout();
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
            // OrbwalkerMenu
            // 
            this.OrbwalkerMenu.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.OrbwalkerMenu.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.OrbwalkerMenu.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.OrbwalkerMenu.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.OrbwalkerMenu.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OrbwalkerMenu.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OrbwalkerMenu.Controls.Add(this.foreverLabel2);
            this.OrbwalkerMenu.Controls.Add(this.ExtraWindupSlider);
            this.OrbwalkerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrbwalkerMenu.Location = new System.Drawing.Point(0, 0);
            this.OrbwalkerMenu.Name = "OrbwalkerMenu";
            this.OrbwalkerMenu.Size = new System.Drawing.Size(189, 347);
            this.OrbwalkerMenu.TabIndex = 2;
            this.OrbwalkerMenu.TabStop = false;
            this.OrbwalkerMenu.Text = "Orbwalker Settings";
            this.OrbwalkerMenu.TitleAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OrbwalkerMenu.TitleHeight = 25;
            // 
            // foreverLabel2
            // 
            this.foreverLabel2.AutoSize = true;
            this.foreverLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel2.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel2.Location = new System.Drawing.Point(4, 32);
            this.foreverLabel2.Name = "foreverLabel2";
            this.foreverLabel2.Size = new System.Drawing.Size(87, 15);
            this.foreverLabel2.TabIndex = 1;
            this.foreverLabel2.Text = "Extra Windup";
            // 
            // ExtraWindupSlider
            // 
            this.ExtraWindupSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.ExtraWindupSlider.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.ExtraWindupSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtraWindupSlider.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ExtraWindupSlider.ForeColor = System.Drawing.Color.White;
            this.ExtraWindupSlider.HatchColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.ExtraWindupSlider.Location = new System.Drawing.Point(7, 51);
            this.ExtraWindupSlider.Maximum = 120;
            this.ExtraWindupSlider.Minimum = 0;
            this.ExtraWindupSlider.Name = "ExtraWindupSlider";
            this.ExtraWindupSlider.ShowValue = false;
            this.ExtraWindupSlider.Size = new System.Drawing.Size(96, 23);
            this.ExtraWindupSlider.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.ExtraWindupSlider.Style = ReaLTaiizor.Controls.ForeverTrackBar._Style.Slider;
            this.ExtraWindupSlider.TabIndex = 0;
            this.ExtraWindupSlider.Text = "ExtraWindupSlider";
            this.ExtraWindupSlider.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.ExtraWindupSlider.Value = 0;
            // 
            // OrbView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.OrbwalkerMenu);
            this.Controls.Add(this.foreverLabel1);
            this.Name = "OrbView";
            this.Size = new System.Drawing.Size(189, 347);
            this.Load += new System.EventHandler(this.OrbView_Load);
            this.OrbwalkerMenu.ResumeLayout(false);
            this.OrbwalkerMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Forms.DreamForm OrbwalkerMenu;
        private ReaLTaiizor.Controls.ForeverTrackBar ExtraWindupSlider;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
    }
}
