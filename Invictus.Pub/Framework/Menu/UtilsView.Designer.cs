namespace InvictusSharp.Framework.Menu
{
    partial class UtilsView
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
            this.ToggleAutoSmite = new ReaLTaiizor.Controls.HopeToggle();
            this.ToggleAutoIgnite = new ReaLTaiizor.Controls.HopeToggle();
            this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            this.SuspendLayout();
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(44, 26);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(72, 15);
            this.foreverLabel1.TabIndex = 3;
            this.foreverLabel1.Text = "Auto Smite";
            // 
            // ToggleAutoSmite
            // 
            this.ToggleAutoSmite.AutoSize = true;
            this.ToggleAutoSmite.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.ToggleAutoSmite.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ToggleAutoSmite.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoSmite.Checked = true;
            this.ToggleAutoSmite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleAutoSmite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleAutoSmite.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ToggleAutoSmite.HeadColorB = System.Drawing.Color.White;
            this.ToggleAutoSmite.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoSmite.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoSmite.Location = new System.Drawing.Point(-10, 23);
            this.ToggleAutoSmite.Name = "ToggleAutoSmite";
            this.ToggleAutoSmite.Size = new System.Drawing.Size(48, 20);
            this.ToggleAutoSmite.TabIndex = 4;
            this.ToggleAutoSmite.Text = "hopeToggle1";
            this.ToggleAutoSmite.UseVisualStyleBackColor = true;
            this.ToggleAutoSmite.CheckedChanged += new System.EventHandler(this.ToggleAutoSmite_CheckedChanged);
            this.ToggleAutoSmite.Click += new System.EventHandler(this.SaveSettings);
            // 
            // ToggleAutoIgnite
            // 
            this.ToggleAutoIgnite.AutoSize = true;
            this.ToggleAutoIgnite.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.ToggleAutoIgnite.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ToggleAutoIgnite.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoIgnite.Checked = true;
            this.ToggleAutoIgnite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleAutoIgnite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleAutoIgnite.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ToggleAutoIgnite.HeadColorB = System.Drawing.Color.White;
            this.ToggleAutoIgnite.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoIgnite.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ToggleAutoIgnite.Location = new System.Drawing.Point(-10, 49);
            this.ToggleAutoIgnite.Name = "ToggleAutoIgnite";
            this.ToggleAutoIgnite.Size = new System.Drawing.Size(48, 20);
            this.ToggleAutoIgnite.TabIndex = 5;
            this.ToggleAutoIgnite.Text = "hopeToggle1";
            this.ToggleAutoIgnite.UseVisualStyleBackColor = true;
            this.ToggleAutoIgnite.CheckedChanged += new System.EventHandler(this.ToggleAutoIgnite_CheckedChanged);
            this.ToggleAutoIgnite.Click += new System.EventHandler(this.SaveSettings);
            // 
            // foreverLabel2
            // 
            this.foreverLabel2.AutoSize = true;
            this.foreverLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel2.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel2.Location = new System.Drawing.Point(44, 52);
            this.foreverLabel2.Name = "foreverLabel2";
            this.foreverLabel2.Size = new System.Drawing.Size(102, 15);
            this.foreverLabel2.TabIndex = 6;
            this.foreverLabel2.Text = "Ignite if Killable";
            // 
            // UtilsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.foreverLabel2);
            this.Controls.Add(this.ToggleAutoIgnite);
            this.Controls.Add(this.ToggleAutoSmite);
            this.Controls.Add(this.foreverLabel1);
            this.Name = "UtilsView";
            this.Size = new System.Drawing.Size(189, 347);
            this.Load += new System.EventHandler(this.UtilsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.HopeToggle ToggleAutoSmite;
        private ReaLTaiizor.Controls.HopeToggle ToggleAutoIgnite;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
    }
}
