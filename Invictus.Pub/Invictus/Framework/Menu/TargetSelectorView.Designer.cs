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
            this.dreamForm1 = new ReaLTaiizor.Forms.DreamForm();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.targetSelectorMode = new ReaLTaiizor.Controls.ForeverComboBox();
            this.dreamForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dreamForm1
            // 
            this.dreamForm1.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.dreamForm1.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.dreamForm1.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamForm1.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.dreamForm1.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamForm1.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamForm1.Controls.Add(this.foreverLabel1);
            this.dreamForm1.Controls.Add(this.targetSelectorMode);
            this.dreamForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dreamForm1.Location = new System.Drawing.Point(0, 0);
            this.dreamForm1.Name = "dreamForm1";
            this.dreamForm1.Size = new System.Drawing.Size(189, 347);
            this.dreamForm1.TabIndex = 0;
            this.dreamForm1.TabStop = false;
            this.dreamForm1.Text = "TargetSelector Menu";
            this.dreamForm1.TitleAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dreamForm1.TitleHeight = 25;
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(7, 28);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(126, 15);
            this.foreverLabel1.TabIndex = 1;
            this.foreverLabel1.Text = "TargetSelector Mode";
            // 
            // targetSelectorMode
            // 
            this.targetSelectorMode.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.targetSelectorMode.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.targetSelectorMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.targetSelectorMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.targetSelectorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetSelectorMode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.targetSelectorMode.ForeColor = System.Drawing.Color.White;
            this.targetSelectorMode.FormattingEnabled = true;
            this.targetSelectorMode.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.targetSelectorMode.HoverFontColor = System.Drawing.Color.White;
            this.targetSelectorMode.ItemHeight = 18;
            this.targetSelectorMode.Location = new System.Drawing.Point(6, 47);
            this.targetSelectorMode.Name = "targetSelectorMode";
            this.targetSelectorMode.Size = new System.Drawing.Size(121, 24);
            this.targetSelectorMode.TabIndex = 0;
            // 
            // TargetSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.dreamForm1);
            this.Name = "TargetSelectorView";
            this.Size = new System.Drawing.Size(189, 347);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.dreamForm1.ResumeLayout(false);
            this.dreamForm1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.DreamForm dreamForm1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverComboBox targetSelectorMode;
    }
}
