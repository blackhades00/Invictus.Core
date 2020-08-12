namespace Invictus.Pub.Invictus.Framework.Menu
{
    partial class CoreSettingView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawAttackRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DrawAttackRangeCheckBox
            // 
            this.DrawAttackRangeCheckBox.AutoSize = true;
            this.DrawAttackRangeCheckBox.Checked = true;
            this.DrawAttackRangeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawAttackRangeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawAttackRangeCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawAttackRangeCheckBox.Location = new System.Drawing.Point(56, 43);
            this.DrawAttackRangeCheckBox.Name = "DrawAttackRangeCheckBox";
            this.DrawAttackRangeCheckBox.Size = new System.Drawing.Size(154, 22);
            this.DrawAttackRangeCheckBox.TabIndex = 0;
            this.DrawAttackRangeCheckBox.Text = "Draw Attack Range";
            this.DrawAttackRangeCheckBox.UseVisualStyleBackColor = true;
            this.DrawAttackRangeCheckBox.CheckedChanged += new System.EventHandler(this.DrawAttackRangeCheckBox_CheckedChanged);
            // 
            // CoreSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.DrawAttackRangeCheckBox);
            this.Name = "CoreSettingView";
            this.Size = new System.Drawing.Size(734, 412);
            this.Load += new System.EventHandler(this.CoreSettingView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DrawAttackRangeCheckBox;
    }
}
