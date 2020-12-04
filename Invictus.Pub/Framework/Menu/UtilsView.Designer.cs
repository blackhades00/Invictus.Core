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
            // 
            // UtilsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
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
    }
}
