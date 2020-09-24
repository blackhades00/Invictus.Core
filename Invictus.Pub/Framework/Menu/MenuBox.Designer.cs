namespace InvictusSharp.Framework.Menu
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
            this.MenuContentPanel = new System.Windows.Forms.Panel();
            this.nightPanel1 = new ReaLTaiizor.Controls.NightPanel();
            this.dungeonHeaderLabel1 = new ReaLTaiizor.Controls.DungeonHeaderLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.OrbwalkerSettingButton = new System.Windows.Forms.Button();
            this.CoreSettingButton = new System.Windows.Forms.Button();
            this.SideMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.nightPanel1.SuspendLayout();
            this.SideMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuContentPanel
            // 
            this.MenuContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.MenuContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuContentPanel.Location = new System.Drawing.Point(144, 41);
            this.MenuContentPanel.Name = "MenuContentPanel";
            this.MenuContentPanel.Size = new System.Drawing.Size(232, 347);
            this.MenuContentPanel.TabIndex = 3;
            this.MenuContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuContentPanel_Paint);
            // 
            // nightPanel1
            // 
            this.nightPanel1.Controls.Add(this.dungeonHeaderLabel1);
            this.nightPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel1.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nightPanel1.Location = new System.Drawing.Point(3, 2);
            this.nightPanel1.Name = "nightPanel1";
            this.nightPanel1.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nightPanel1.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel1.Size = new System.Drawing.Size(373, 39);
            this.nightPanel1.TabIndex = 4;
            // 
            // dungeonHeaderLabel1
            // 
            this.dungeonHeaderLabel1.AutoSize = true;
            this.dungeonHeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonHeaderLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.dungeonHeaderLabel1.ForeColor = System.Drawing.Color.White;
            this.dungeonHeaderLabel1.Location = new System.Drawing.Point(138, 7);
            this.dungeonHeaderLabel1.Name = "dungeonHeaderLabel1";
            this.dungeonHeaderLabel1.Size = new System.Drawing.Size(86, 16);
            this.dungeonHeaderLabel1.TabIndex = 0;
            this.dungeonHeaderLabel1.Text = "INVICTUS";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "TargetSelector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // OrbwalkerSettingButton
            // 
            this.OrbwalkerSettingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OrbwalkerSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrbwalkerSettingButton.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrbwalkerSettingButton.ForeColor = System.Drawing.Color.White;
            this.OrbwalkerSettingButton.Location = new System.Drawing.Point(3, 52);
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
            this.CoreSettingButton.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F);
            this.CoreSettingButton.ForeColor = System.Drawing.Color.White;
            this.CoreSettingButton.Location = new System.Drawing.Point(3, 3);
            this.CoreSettingButton.Name = "CoreSettingButton";
            this.CoreSettingButton.Size = new System.Drawing.Size(137, 43);
            this.CoreSettingButton.TabIndex = 4;
            this.CoreSettingButton.Text = "Drawings";
            this.CoreSettingButton.UseVisualStyleBackColor = true;
            this.CoreSettingButton.Click += new System.EventHandler(this.CoreSettingButton_Click);
            // 
            // SideMenuPanel
            // 
            this.SideMenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SideMenuPanel.Controls.Add(this.CoreSettingButton);
            this.SideMenuPanel.Controls.Add(this.OrbwalkerSettingButton);
            this.SideMenuPanel.Controls.Add(this.button1);
            this.SideMenuPanel.Location = new System.Drawing.Point(0, 38);
            this.SideMenuPanel.Name = "SideMenuPanel";
            this.SideMenuPanel.Size = new System.Drawing.Size(143, 348);
            this.SideMenuPanel.TabIndex = 2;
            this.SideMenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SideMenuPanel_Paint);
            // 
            // MenuBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(377, 385);
            this.Controls.Add(this.nightPanel1);
            this.Controls.Add(this.MenuContentPanel);
            this.Controls.Add(this.SideMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MenuBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MenuBox_Load);
            this.nightPanel1.ResumeLayout(false);
            this.nightPanel1.PerformLayout();
            this.SideMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MenuContentPanel;
        private ReaLTaiizor.Controls.NightPanel nightPanel1;
        private ReaLTaiizor.Controls.DungeonHeaderLabel dungeonHeaderLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OrbwalkerSettingButton;
        private System.Windows.Forms.Button CoreSettingButton;
        private System.Windows.Forms.FlowLayoutPanel SideMenuPanel;
    }
}