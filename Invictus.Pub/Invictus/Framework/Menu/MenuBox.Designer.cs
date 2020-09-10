namespace Invictus.Core.Invictus.Framework.Menu
{
    partial class MenuBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuTopPanel = new System.Windows.Forms.Panel();
            this.ParadoxLabel = new System.Windows.Forms.Label();
            this.SideMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OrbwalkerSettingButton = new System.Windows.Forms.Button();
            this.CoreSettingButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuContentPanel = new System.Windows.Forms.Panel();
            this.MenuTopPanel.SuspendLayout();
            this.SideMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTopPanel
            // 
            this.MenuTopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.MenuTopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuTopPanel.Controls.Add(this.ParadoxLabel);
            this.MenuTopPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuTopPanel.Name = "MenuTopPanel";
            this.MenuTopPanel.Size = new System.Drawing.Size(699, 37);
            this.MenuTopPanel.TabIndex = 0;
            this.MenuTopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuTopPanel_MouseDown);
            // 
            // ParadoxLabel
            // 
            this.ParadoxLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ParadoxLabel.AutoSize = true;
            this.ParadoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParadoxLabel.ForeColor = System.Drawing.Color.White;
            this.ParadoxLabel.Location = new System.Drawing.Point(301, 9);
            this.ParadoxLabel.Name = "ParadoxLabel";
            this.ParadoxLabel.Size = new System.Drawing.Size(63, 20);
            this.ParadoxLabel.TabIndex = 0;
            this.ParadoxLabel.Text = "Invictus";
            // 
            // SideMenuPanel
            // 
            this.SideMenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(49)))));
            this.SideMenuPanel.Controls.Add(this.OrbwalkerSettingButton);
            this.SideMenuPanel.Controls.Add(this.CoreSettingButton);
            this.SideMenuPanel.Controls.Add(this.button1);
            this.SideMenuPanel.Location = new System.Drawing.Point(0, 38);
            this.SideMenuPanel.Name = "SideMenuPanel";
            this.SideMenuPanel.Size = new System.Drawing.Size(143, 335);
            this.SideMenuPanel.TabIndex = 2;
            // 
            // OrbwalkerSettingButton
            // 
            this.OrbwalkerSettingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrbwalkerSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrbwalkerSettingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrbwalkerSettingButton.ForeColor = System.Drawing.Color.White;
            this.OrbwalkerSettingButton.Location = new System.Drawing.Point(3, 3);
            this.OrbwalkerSettingButton.Name = "OrbwalkerSettingButton";
            this.OrbwalkerSettingButton.Size = new System.Drawing.Size(137, 43);
            this.OrbwalkerSettingButton.TabIndex = 3;
            this.OrbwalkerSettingButton.Text = "Orbwalker";
            this.OrbwalkerSettingButton.UseVisualStyleBackColor = true;
            this.OrbwalkerSettingButton.Click += new System.EventHandler(this.OrbwalkerSettingButton_Click);
            // 
            // CoreSettingButton
            // 
            this.CoreSettingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoreSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CoreSettingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoreSettingButton.ForeColor = System.Drawing.Color.White;
            this.CoreSettingButton.Location = new System.Drawing.Point(3, 52);
            this.CoreSettingButton.Name = "CoreSettingButton";
            this.CoreSettingButton.Size = new System.Drawing.Size(137, 43);
            this.CoreSettingButton.TabIndex = 4;
            this.CoreSettingButton.Text = "Drawings";
            this.CoreSettingButton.UseVisualStyleBackColor = true;
            this.CoreSettingButton.Click += new System.EventHandler(this.CoreSettingButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "TargetSelector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MenuContentPanel
            // 
            this.MenuContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuContentPanel.Location = new System.Drawing.Point(145, 39);
            this.MenuContentPanel.Name = "MenuContentPanel";
            this.MenuContentPanel.Size = new System.Drawing.Size(554, 334);
            this.MenuContentPanel.TabIndex = 3;
            this.MenuContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuContentPanel_Paint);
            // 
            // MenuBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(699, 372);
            this.Controls.Add(this.MenuContentPanel);
            this.Controls.Add(this.SideMenuPanel);
            this.Controls.Add(this.MenuTopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MenuBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MenuBox_Load);
            this.MenuTopPanel.ResumeLayout(false);
            this.MenuTopPanel.PerformLayout();
            this.SideMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuTopPanel;
        private System.Windows.Forms.FlowLayoutPanel SideMenuPanel;
        private System.Windows.Forms.Button OrbwalkerSettingButton;
        private System.Windows.Forms.Label ParadoxLabel;
        private System.Windows.Forms.Panel MenuContentPanel;
        private System.Windows.Forms.Button CoreSettingButton;
        private System.Windows.Forms.Button button1;
    }
}