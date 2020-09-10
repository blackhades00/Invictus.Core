namespace Invictus.Core.Invictus.Framework.Menu
{
    partial class OrbwalkerView
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
            this.orbExtraWindup = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orbExtraWindup)).BeginInit();
            this.SuspendLayout();
            // 
            // orbExtraWindup
            // 
            this.orbExtraWindup.Location = new System.Drawing.Point(3, 78);
            this.orbExtraWindup.Maximum = 120;
            this.orbExtraWindup.Name = "orbExtraWindup";
            this.orbExtraWindup.Size = new System.Drawing.Size(173, 45);
            this.orbExtraWindup.TabIndex = 0;
            this.orbExtraWindup.TickStyle = System.Windows.Forms.TickStyle.None;
            this.orbExtraWindup.Scroll += new System.EventHandler(this.orbExtraWindup_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Extra Windup";
            // 
            // OrbwalkerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orbExtraWindup);
            this.Name = "OrbwalkerView";
            this.Size = new System.Drawing.Size(692, 472);
            this.Load += new System.EventHandler(this.OrbwalkerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orbExtraWindup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar orbExtraWindup;
        private System.Windows.Forms.Label label1;
    }
}
