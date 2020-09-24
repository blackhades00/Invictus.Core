namespace Invictus.Core.Invictus.Framework.Menu
{
    partial class TargetSelectorView
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
            this.targetSelectorMode = new ReaLTaiizor.Controls.ForeverComboBox();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.SuspendLayout();
            // 
            // targetSelectorMode
            // 
            this.targetSelectorMode.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.targetSelectorMode.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.targetSelectorMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.targetSelectorMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.targetSelectorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetSelectorMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetSelectorMode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.targetSelectorMode.ForeColor = System.Drawing.Color.White;
            this.targetSelectorMode.FormattingEnabled = true;
            this.targetSelectorMode.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.targetSelectorMode.HoverFontColor = System.Drawing.Color.White;
            this.targetSelectorMode.ItemHeight = 18;
            this.targetSelectorMode.Items.AddRange(new object[] {
            "LowestHPTarget",
            "ClosestTarget"});
            this.targetSelectorMode.Location = new System.Drawing.Point(3, 39);
            this.targetSelectorMode.Name = "targetSelectorMode";
            this.targetSelectorMode.Size = new System.Drawing.Size(131, 24);
            this.targetSelectorMode.TabIndex = 2;
            this.targetSelectorMode.TabStop = false;
            this.targetSelectorMode.SelectedIndexChanged += new System.EventHandler(this.foreverComboBox1_SelectedIndexChanged);
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(3, 21);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(39, 15);
            this.foreverLabel1.TabIndex = 3;
            this.foreverLabel1.Text = "Mode";
            // 
            // TargetSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.foreverLabel1);
            this.Controls.Add(this.targetSelectorMode);
            this.Name = "TargetSelectorView";
            this.Size = new System.Drawing.Size(189, 347);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.ForeverComboBox targetSelectorMode;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
    }
}
