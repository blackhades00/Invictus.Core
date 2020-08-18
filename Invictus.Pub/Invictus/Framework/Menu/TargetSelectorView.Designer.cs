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
            this.targetSelectorMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // targetSelectorMode
            // 
            this.targetSelectorMode.FormattingEnabled = true;
            this.targetSelectorMode.Items.AddRange(new object[] {
            "LowestHPTarget",
            "ClosestTarget"});
            this.targetSelectorMode.Location = new System.Drawing.Point(30, 76);
            this.targetSelectorMode.Name = "targetSelectorMode";
            this.targetSelectorMode.Size = new System.Drawing.Size(121, 21);
            this.targetSelectorMode.TabIndex = 0;
            this.targetSelectorMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TargetSelector Mode";
            // 
            // TargetSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetSelectorMode);
            this.Name = "TargetSelectorView";
            this.Size = new System.Drawing.Size(692, 472);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox targetSelectorMode;
        private System.Windows.Forms.Label label1;
    }
}
