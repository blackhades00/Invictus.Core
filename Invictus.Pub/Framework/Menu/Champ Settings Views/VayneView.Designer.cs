namespace InvictusSharp.Framework.Menu.Champ_Settings_Views
{
    partial class VayneView
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
            this.SuspendLayout();
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(3, 35);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(43, 15);
            this.foreverLabel1.TabIndex = 4;
            this.foreverLabel1.Text = "Vayne";
            // 
            // VayneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.foreverLabel1);
            this.Name = "VayneView";
            this.Size = new System.Drawing.Size(189, 347);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
    }
}
