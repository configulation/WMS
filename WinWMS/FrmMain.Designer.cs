namespace WinWMS
{
    partial class FrmMain
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
            this.WMS_Menus = new System.Windows.Forms.MenuStrip();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.角色管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBanQuan = new System.Windows.Forms.ToolStripStatusLabel();
            this.WMS_Tools = new System.Windows.Forms.ToolStrip();
            this.WMS_Pages = new System.Windows.Forms.TabControl();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.WMS_Menus.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // WMS_Menus
            // 
            this.WMS_Menus.AutoSize = false;
            this.WMS_Menus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(189)))), ((int)(((byte)(240)))));
            this.WMS_Menus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.WMS_Menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.WMS_Menus.Location = new System.Drawing.Point(0, 0);
            this.WMS_Menus.Name = "WMS_Menus";
            this.WMS_Menus.Size = new System.Drawing.Size(1227, 35);
            this.WMS_Menus.TabIndex = 0;
            this.WMS_Menus.Text = "menuStrip1";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.角色管理ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.系统管理ToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 31);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 角色管理ToolStripMenuItem
            // 
            this.角色管理ToolStripMenuItem.Name = "角色管理ToolStripMenuItem";
            this.角色管理ToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.角色管理ToolStripMenuItem.Text = "角色管理";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 31);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblLoginTime,
            this.toolStripStatusLabel3,
            this.lblAction,
            this.toolStripStatusLabel2,
            this.lblUName,
            this.toolStripStatusLabel6,
            this.lblBanQuan});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1227, 36);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 30);
            this.toolStripStatusLabel1.Text = "登录时间：";
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoginTime.ForeColor = System.Drawing.Color.Blue;
            this.lblLoginTime.Margin = new System.Windows.Forms.Padding(5, 4, 0, 2);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(161, 30);
            this.lblLoginTime.Text = "2022-10-25 10:24:30";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(84, 30);
            this.toolStripStatusLabel3.Text = "当前操作：";
            // 
            // lblAction
            // 
            this.lblAction.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAction.ForeColor = System.Drawing.Color.Purple;
            this.lblAction.Margin = new System.Windows.Forms.Padding(5, 4, 0, 2);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(39, 30);
            this.lblAction.Text = "首页";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 30);
            this.toolStripStatusLabel2.Text = "当前用户：";
            // 
            // lblUName
            // 
            this.lblUName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUName.ForeColor = System.Drawing.Color.Purple;
            this.lblUName.Margin = new System.Windows.Forms.Padding(5, 4, 0, 2);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(57, 30);
            this.lblUName.Text = "admin";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(84, 30);
            this.toolStripStatusLabel6.Text = "系统版权：";
            // 
            // lblBanQuan
            // 
            this.lblBanQuan.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBanQuan.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblBanQuan.Margin = new System.Windows.Forms.Padding(5, 4, 0, 2);
            this.lblBanQuan.Name = "lblBanQuan";
            this.lblBanQuan.Size = new System.Drawing.Size(69, 30);
            this.lblBanQuan.Text = "版权所有";
            // 
            // WMS_Tools
            // 
            this.WMS_Tools.AutoSize = false;
            this.WMS_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(238)))), ((int)(((byte)(251)))));
            this.WMS_Tools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.WMS_Tools.Location = new System.Drawing.Point(0, 35);
            this.WMS_Tools.Name = "WMS_Tools";
            this.WMS_Tools.Size = new System.Drawing.Size(1227, 34);
            this.WMS_Tools.TabIndex = 3;
            this.WMS_Tools.Text = "toolStrip1";
            // 
            // WMS_Pages
            // 
            this.WMS_Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WMS_Pages.Location = new System.Drawing.Point(0, 72);
            this.WMS_Pages.Name = "WMS_Pages";
            this.WMS_Pages.SelectedIndex = 0;
            this.WMS_Pages.Size = new System.Drawing.Size(1227, 511);
            this.WMS_Pages.TabIndex = 1;
            this.WMS_Pages.SizeChanged += new System.EventHandler(this.WMS_Pages_SizeChanged);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = global::WinWMS.Properties.Resources.close;
            this.picClose.Location = new System.Drawing.Point(1194, 35);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 31);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 583);
            this.Controls.Add(this.WMS_Pages);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.WMS_Tools);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.WMS_Menus);
            this.MainMenuStrip = this.WMS_Menus;
            this.Name = "FrmMain";
            this.Text = "仓储管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmMain_VisibleChanged);
            this.WMS_Menus.ResumeLayout(false);
            this.WMS_Menus.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip WMS_Menus;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 角色管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblLoginTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblAction;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblBanQuan;
        private System.Windows.Forms.ToolStrip WMS_Tools;
        private System.Windows.Forms.TabControl WMS_Pages;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblUName;
        private System.Windows.Forms.PictureBox picClose;
    }
}